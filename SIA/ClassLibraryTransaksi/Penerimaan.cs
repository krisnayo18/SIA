using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
   public  class Penerimaan
    {
        #region Data Member
        private string kodePenerimaan, jenisPengiriman, nama, keterangan;
        private int biayaKirim;
        private DateTime tglTerima;
        private NotaPembelian notaPembelian;
        #endregion

        #region Constructor
        public Penerimaan()
        {
            KodePenerimaan = "";
            JenisPengiriman = "";
            Nama = "";
            Keterangan = "";
            BiayaKirim = 0;
            TglTerima = DateTime.Now;
        }

        public Penerimaan(string kodePengiriman, string jenisPengiriman, string nama, string keterangan, int biayaKirim, DateTime tglTerima, NotaPembelian notaPembelian)
        {
            this.kodePenerimaan = kodePengiriman;
            this.jenisPengiriman = jenisPengiriman;
            this.nama = nama;
            this.keterangan = keterangan;
            this.biayaKirim = biayaKirim;
            this.tglTerima = tglTerima;
            this.notaPembelian = notaPembelian;
        }
        #endregion

        #region Properties
        public string KodePenerimaan
        {
            get
            {
                return kodePenerimaan;
            }

            set
            {
                kodePenerimaan = value;
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

        public DateTime TglTerima
        {
            get
            {
                return tglTerima;
            }

            set
            {
                tglTerima = value;
            }
        }

        public NotaPembelian NotaPembelian
        {
            get
            {
                return notaPembelian;
            }

            set
            {
                notaPembelian = value;
            }
        }

        #endregion

        #region Method
        public static string TambahData(Penerimaan pPenerimaan)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                //sql1 untuk menambahkan data ke tabel nota penjualan
                string sql = "Insert into penerimaan(kodePenerimaan, jenispengiriman, biayakirim,tglTerima,nama,keterangan,noNotaPembelian) values ('" +
                        pPenerimaan.KodePenerimaan + "',  '" +
                        pPenerimaan.JenisPengiriman + "'," +
                        pPenerimaan.BiayaKirim + ",'" +
                        pPenerimaan.TglTerima.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                        pPenerimaan.Nama + "','" +
                        pPenerimaan.Keterangan + "','" +
                        pPenerimaan.NotaPembelian.NoNotaPembelian + "')";
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
        public static string GenerateNoNota(out string pHasilKodePenerimaan)
        {
            //perintah sql = mendapatkan nourut nota terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(kodePenerimaan, 9, 3) AS noUrutPenerimaan " +
                         "FROM penerimaan WHERE Date(tglTerima) = Date(CURRENT_DATE) " +
                         "ORDER BY kodepenerimaan DESC LIMIT 1";
            pHasilKodePenerimaan = "";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutPenerimaanTerbaru = "";
                //cek apakah sudah ada transaksi  pada tanggal  hari ini (data reader dari sql  diatas bisa terbca atau tidak )
                if (hasilData.Read() == true)//jika berhasil membaca data (sudah ada transaksi pada hari ini)
                {
                    int noUrutPemb = int.Parse(hasilData.GetValue(0).ToString()) + 1; //dapatkan no urut Pemb terbaru 
                    noUrutPenerimaanTerbaru = noUrutPemb.ToString().PadLeft(3, '0'); // jika nourutPemba pada hari ini 
                }
                else //jika belum ada transaksi hari ini
                {
                    noUrutPenerimaanTerbaru = "001";
                }
                //generate nomor nota terbaru dengan format yyyymmddxxx (y tahun, m bulan, d hari , dan xxx no urut transaksi tgl tsb)
                string tahun = DateTime.Now.Year.ToString();//dapatkan tahun dari tanggal kompter
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');//dapatkan bulan
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');//dapatkan hari

                //generate nomor nota terbaru sesuai format terbaru
                pHasilKodePenerimaan = tahun + bulan + tanggal + noUrutPenerimaanTerbaru.ToString();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public static string BacaData(string pKriteria, string pNilaiKriteria, List<Penerimaan> listHasilData)
        {
            string sql = "";

            if (pKriteria == "")
            {
                sql = " select * from penerimaan order by kodepenerimaan desc";


            }
            else
            {
                sql = " select * from penerimaan where " + pKriteria + " LIKE '%" + pNilaiKriteria + "%' order by kodepenerimaan desc";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();

                while (hasilData.Read() == true)
                {
                    NotaPembelian nota = new NotaPembelian();
                    nota.NoNotaPembelian = hasilData.GetValue(6).ToString();

                    string kodePen = hasilData.GetValue(0).ToString();
                    string pJenis = hasilData.GetValue(1).ToString();
                    int biaya = int.Parse(hasilData.GetValue(2).ToString());
                    DateTime tanggal = DateTime.Parse(hasilData.GetValue(3).ToString());
                    string nama = hasilData.GetValue(4).ToString();
                    string ket = hasilData.GetValue(5).ToString();

                    Penerimaan pen = new Penerimaan(kodePen, pJenis, nama, ket, biaya, tanggal, nota);

                    listHasilData.Add(pen);
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
