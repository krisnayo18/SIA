using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
    public class Pengiriman
    {

        #region Data Member
        private string kodePengiriman, jenisPengiriman, nama, keterangan;
        private DateTime tglKirim;
        private int biayaKirim;
        private NotaPenjualan notaPenjualan;
        private Ekspedisi ekspedisi;
        #endregion

        #region Constructor
        public Pengiriman()
        {
            KodePengiriman = "";
            JenisPengiriman = "";
            Nama = "";
            Keterangan = "";
            TglKirim = DateTime.Now;
            BiayaKirim = 0;
        }
        public Pengiriman(string kodePengiriman, string jenisPengiriman, string nama, string keterangan, DateTime tglKirim, int biayaKirim, NotaPenjualan notaPenjualan, Ekspedisi ekspedisi)
        {
            this.kodePengiriman = kodePengiriman;
            this.jenisPengiriman = jenisPengiriman;
            this.nama = nama;
            this.keterangan = keterangan;
            this.tglKirim = tglKirim;
            this.biayaKirim = biayaKirim;
            this.notaPenjualan = notaPenjualan;
            this.ekspedisi = ekspedisi;
        }
        #endregion

        #region Properties
        public string KodePengiriman
        {
            get
            {
                return kodePengiriman;
            }

            set
            {
                kodePengiriman = value;
            }
        }

        public string JenisPengiriman
        {
            get
            {
                return jenisPengiriman;
            }

            set
            {
                jenisPengiriman = value;
            }
        }

        public string Nama
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
            }
        }

        public string Keterangan
        {
            get
            {
                return keterangan;
            }

            set
            {
                keterangan = value;
            }
        }

        public DateTime TglKirim
        {
            get
            {
                return tglKirim;
            }

            set
            {
                tglKirim = value;
            }
        }

        public int BiayaKirim
        {
            get
            {
                return biayaKirim;
            }

            set
            {
                biayaKirim = value;
            }
        }

        public NotaPenjualan NotaPenjualan
        {
            get
            {
                return notaPenjualan;
            }

            set
            {
                notaPenjualan = value;
            }
        }

        public Ekspedisi Ekspedisi
        {
            get
            {
                return ekspedisi;
            }

            set
            {
                ekspedisi = value;
            }
        }

        #endregion

        #region Method
        public static string TambahData(Pengiriman pPengiriman)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                //sql1 untuk menambahkan data ke tabel nota penjualan
                string sql = "Insert into pengiriman(kodePengiriman, jenispengiriman, biayakirim,tglkirim,nama,keterangan,noNotaPenjualan,idEkspedisi) values ('" +
                        pPengiriman.KodePengiriman + "',  '" +
                        pPengiriman.JenisPengiriman + "'," +
                        pPengiriman.BiayaKirim + ",'" +
                        pPengiriman.TglKirim.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                        pPengiriman.Nama + "','" +
                        pPengiriman.Keterangan + "','" +
                        pPengiriman.NotaPenjualan.NoNotaPenjualan + "', '" +
                        pPengiriman.Ekspedisi.IdEkspedisi + "')";
                try
                {
                    //jalankan perintah sql untuk menambahkan ke tabel 
                    Koneksi.JalankanPerintahDML(sql);

                    tranScope.Complete();
                    return "1";
                }
                catch (MySqlException ex)
                {
                    //jika ada kegagalan perintah
                    tranScope.Dispose();
                    return ex.Message;
                }
            }
        }
        public static string GenerateNoNota(out string pHasilKodePeng)
        {
            //perintah sql = mendapatkan nourut nota terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(kodePengiriman, 9, 3) AS noUrutPengiriman " +
                         "FROM pengiriman WHERE Date(tglkirim) = Date(CURRENT_DATE) " +
                         "ORDER BY kodepengiriman DESC LIMIT 1";
            pHasilKodePeng = "";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutPengirimanTerbaru = "";
                //cek apakah sudah ada transaksi  pada tanggal  hari ini (data reader dari sql  diatas bisa terbca atau tidak )
                if (hasilData.Read() == true)//jika berhasil membaca data (sudah ada transaksi pada hari ini)
                {
                    int noUrutPemb = int.Parse(hasilData.GetValue(0).ToString()) + 1; //dapatkan no urut Pemb terbaru 
                    noUrutPengirimanTerbaru = noUrutPemb.ToString().PadLeft(3, '0'); // jika nourutPemba pada hari ini 
                }
                else //jika belum ada transaksi hari ini
                {
                    noUrutPengirimanTerbaru = "001";
                }
                //generate nomor nota terbaru dengan format yyyymmddxxx (y tahun, m bulan, d hari , dan xxx no urut transaksi tgl tsb)
                string tahun = DateTime.Now.Year.ToString();//dapatkan tahun dari tanggal kompter
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');//dapatkan bulan
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');//dapatkan hari

                //generate nomor nota terbaru sesuai format terbaru
                pHasilKodePeng = tahun + bulan + tanggal + noUrutPengirimanTerbaru;
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public static string BacaData(string pKriteria, string pNilaiKriteria, List<Pengiriman> listHasilData)
        {
            string sql = "";

            if (pKriteria == "")
            {
                sql = " select P.kodepengiriman, P.jenisPengiriman, P.biayakirim, P.tglKirim, P.nama, P.keterangan, P.noNotaPenjualan, " + 
                      "E.idEkspedisi, E.nama from pengiriman P inner join notaPenjualan NP  on P.noNotaPenjualan = NP.noNotaPenjualan " +
                      " inner join Ekspedisi E on P.idEkspedisi = E.idEkspedisi order by P.kodepengiriman desc";


            }
            else
            {
                sql = " select P.kodepengiriman, P.jenisPengiriman, P.biayakirim, P.tglKirim, P.nama, P.keterangan, P.noNotaPenjualan, " +
                      "E.idEkspedisi, E.nama from pengiriman P inner join notaPenjualan NP  on P.noNotaPenjualan = NP.noNotaPenjualan " +
                      " inner join Ekspedisi E on P.idEkspedisi = E.idEkspedisi where " + pKriteria + " LIKE '%" + pNilaiKriteria + "%' order by P.kodepengiriman desc";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();

                while (hasilData.Read() == true)
                {
                    NotaPenjualan nota = new NotaPenjualan();
                    nota.NoNotaPenjualan = hasilData.GetValue(6).ToString();

                    Ekspedisi eks = new Ekspedisi();
                    eks.IdEkspedisi = hasilData.GetValue(7).ToString();
                    eks.Nama = hasilData.GetValue(8).ToString();

                    string kodePeng = hasilData.GetValue(0).ToString();
                    string pJenis = hasilData.GetValue(1).ToString();
                    int biaya = int.Parse(hasilData.GetValue(2).ToString());
                    DateTime tanggal = DateTime.Parse(hasilData.GetValue(3).ToString());
                    string nama = hasilData.GetValue(4).ToString();
                    string ket = hasilData.GetValue(5).ToString();

                    Pengiriman peng = new Pengiriman(kodePeng,pJenis,nama,ket,tanggal,biaya, nota, eks);                  

                    listHasilData.Add(peng);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }
        #endregion
    }
}
