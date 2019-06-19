using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
    public class SuratJalan
    {
        #region Data Member
        private string noSuratJalan, jenis, keterangan;
        private DateTime tgl;
        private SuratPermintaan suratPermintaan;
        private List<DetilSuratJalan> listDetilSuratJalan;
        #endregion

        #region Constructor
        public SuratJalan()
        {
            NoSuratJalan = "";
            Jenis = "";
            Keterangan = "";
            Tgl = DateTime.Now;
            ListDetilSuratJalan = new List<DetilSuratJalan>();
        }
        public SuratJalan(string noSuratJalan, string jenis, string keterangan, DateTime tgl, SuratPermintaan suratPermintaan)
        {
            this.noSuratJalan = noSuratJalan;
            this.jenis = jenis;
            this.keterangan = keterangan;
            this.tgl = tgl;
            this.suratPermintaan = suratPermintaan;
            this.listDetilSuratJalan = new List<DetilSuratJalan>();
        }
        #endregion

        #region Properties
        public string NoSuratJalan
        {
            get
            {
                return noSuratJalan;
            }

            set
            {
                noSuratJalan = value;
            }
        }

        public string Jenis
        {
            get
            {
                return jenis;
            }

            set
            {
                jenis = value;
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

        public DateTime Tgl
        {
            get
            {
                return tgl;
            }

            set
            {
                tgl = value;
            }
        }

        public List<DetilSuratJalan> ListDetilSuratJalan
        {
            get
            {
                return listDetilSuratJalan;
            }

            set
            {
                listDetilSuratJalan = value;
            }
        }

        public SuratPermintaan SuratPermintaan
        {
            get
            {
                return suratPermintaan;
            }

            set
            {
                suratPermintaan = value;
            }
        }

        #endregion

        #region Method
        public void TambahDetilBarang(Barang pBarang, int pJumlah)
        {
            DetilSuratJalan dsj = new DetilSuratJalan(pBarang, pJumlah);
            ListDetilSuratJalan.Add(dsj);
        }
        public static string TambahData(SuratJalan pSuratJalan)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // perintah sql 1 = untuk menambahkan data ke tabel surat Jalan
                string sql1 = "INSERT INTO suratJalan(noSuratJalan,jenis, tgl,  keterangan, nosuratpermintaan) VALUES ('" +
                    pSuratJalan.NoSuratJalan + "', '" +
                    pSuratJalan.Jenis + "', '" +
                    pSuratJalan.Tgl.ToString("yyyy-MM-dd ") + "', '" +
                    pSuratJalan.Keterangan + "', '" +
                    pSuratJalan.SuratPermintaan.NoSuratPermintaan + "')";

                try
                {
                    //jalankan perintah untuk menambahkan  ke tabel suratjalan
                    Koneksi.JalankanPerintahDML(sql1);
                    //menambahkan semua barang yang akan di kirim, ke dalam detilsuratjalan
                    for (int i = 0; i < pSuratJalan.ListDetilSuratJalan.Count; i++)
                    {
                        //perintah sql2 = untuk menambahkan barang barang yang dikirim ke tabel detilsuratjalan
                        string sql2 = "INSERT INTO detilsuratjalan(nosuratjalan, kodebarang, jumlah) VALUES ('" +
                            pSuratJalan.NoSuratJalan + "', '" +
                            pSuratJalan.ListDetilSuratJalan[i].Barang.KodeBarang + "', " +
                            pSuratJalan.ListDetilSuratJalan[i].Jumlah + ")";

                        //menjalankan perintah untuk menambahkan  ke tabel detilsuratjalan
                        Koneksi.JalankanPerintahDML(sql2);

                        //ubah stok barang
                        if(pSuratJalan.Jenis == "M") // jika barang  dikirim ke gudang (job order telah selesai)
                        {
                            Barang.UbahStokBeli(pSuratJalan.ListDetilSuratJalan[i].Barang.KodeBarang, pSuratJalan.ListDetilSuratJalan[i].Jumlah);
                        }
                        else //jika barang di ambil dari gudang untuk keperluan job order
                        {
                            Barang.UbahStokTerjual(pSuratJalan.ListDetilSuratJalan[i].Barang.KodeBarang, pSuratJalan.ListDetilSuratJalan[i].Jumlah); 
                        }
                    }
                    //jika semua perinth dml berhasil dijalankan
                    tranScope.Complete();
                    return "1";
                }
                catch (Exception e)
                {
                    //jika ada kegagalan perintah dml
                    tranScope.Dispose();
                    return e.Message;
                }
            }
        }
        public static string GenerateNoSuratJalan(out string pHasilNoSurat)
        {
            //perintah sql = mendapatkan no surat Jalan terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(noSuratJalan, 9, 3) AS noUrutSurat " +
                         "FROM suratjalan WHERE Date(tgl) = Date(CURRENT_DATE) " +
                         "ORDER BY noSuratJalan DESC LIMIT 1";
            pHasilNoSurat = "";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutSuratTerbaru = "";
                //cek apakah sudah ada surat  pada tanggal  hari ini (data reader dari sql  diatas bisa terbca atau tidak )
                if (hasilData.Read())//jika berhasil membaca data (sudah ada surat pada hari ini)
                {
                    int noUrutSurat = int.Parse(hasilData.GetValue(0).ToString()) + 1; //dapatkan no urut surat terbaru 
                    noUrutSuratTerbaru = noUrutSurat.ToString().PadLeft(3, '0'); // jika nourutsurat pada hari ini 
                }
                else //jika belum ada surat hari ini
                {
                    noUrutSuratTerbaru = "001";
                }
                //generate nomor surat terbaru dengan format yyyymmddxxx (y tahun, m bulan, d hari , dan xxx no urut surat tgl tsb)
                string tahun = DateTime.Now.Year.ToString();//dapatkan tahun dari tanggal kompter
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');//dapatkan bulan
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');//dapatkan hari

                //generate nomor surat terbaru sesuai format terbaru
                pHasilNoSurat = tahun + bulan + tanggal + noUrutSuratTerbaru.ToString();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static string BacaData(string kriteria, string nilaiKriteria, List<SuratJalan> listSuratJalan)
        {
            string sql1 = "";

            if (kriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel surat jalan
                sql1 = "select * from suratjalan order by noSuratJalan desc";
            }
            else
            {
                sql1 = "select * from suratjalan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' order by noSuratJalan desc";
            }

            try
            {
                //data reader 1 = memperoleh semua data di tabel surat jalan
                MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
                listSuratJalan.Clear();//kosongi isi list terlebih dahulu

                while (hasilData1.Read())
                {

                    //mendapatkan  nosurat ,dll
                    string nomorSurat = hasilData1.GetValue(0).ToString();
                    string pJenis = hasilData1.GetValue(1).ToString();
                    DateTime tgl = DateTime.Parse(hasilData1.GetValue(2).ToString());
                    string ket = hasilData1.GetValue(3).ToString();

                    //permintaan seusai surat permintaan
                    //mendapatkan no surat permintaan
                    string noSuratPermintaan = hasilData1.GetValue(4).ToString();

                    //buat object bertipe surat permintaan
                    SuratPermintaan suratPermintaan = new SuratPermintaan();
                    //tambahkan  data 
                    suratPermintaan.NoSuratPermintaan = noSuratPermintaan;

                    //surat jalan
                    //buat object surat jalan dan tambahkan data
                    SuratJalan surat = new SuratJalan(nomorSurat, pJenis, ket, tgl, suratPermintaan);

                    //DETAIL surat Jalan
                    //query utk detail suratJalan dari tiap surat jalan
                    //sql2 untuk mendapatkan barang yang akan dikirim 
                    string sql2 = "SELECT DSJ.kodeBarang, B.Nama, DSJ.Jumlah FROM suratJalan SJ INNER JOIN " +
                                   "detilsuratJalan DSJ ON SJ.nosuratjalan = DSJ.nosuratjalan INNER JOIN Barang B ON " +
                                   "DSJ.KodeBarang = B.KodeBarang WHERE SJ.nosuratjalan = '" + nomorSurat + "'";

                    //memperoleh semua data barang nota ditabel detilsuratjalan
                    MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                    while (hasilData2.Read())
                    {
                        //mendapatkan  kode dan nama barang yang terjual 
                        string kodeBrg = hasilData2.GetValue(0).ToString();
                        string namaBrg = hasilData2.GetValue(1).ToString();
                        //buat object barang dan tambahkan
                        Barang brg = new Barang();
                        brg.KodeBarang = kodeBrg;
                        brg.Nama = namaBrg;

                        //mendapatkan jumlah 
                        int jumlah = int.Parse(hasilData2.GetValue(2).ToString());

                        //buat object bertipe detilsurat dan tambahkan 
                        //ingat baik baik agar fk tidak duplicate
                        DetilSuratJalan detilSurat = new DetilSuratJalan(brg, jumlah);

                        //simpan detil barang 
                        surat.TambahDetilBarang(brg, jumlah);
                    }
                    //simpan ke list
                    listSuratJalan.Add(surat);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
