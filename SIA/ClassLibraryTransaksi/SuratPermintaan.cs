using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
    public class SuratPermintaan
    {
        #region Data Member
        private string noSuratPermintaan, keterangan;
        private DateTime tanggal;
        private JobOrder jobOrder;
        private List<DetilSuratPermintaan> listDetilSuratPermintaan;
        #endregion

        #region Constructor
        public SuratPermintaan()
        {
            NoSuratPermintaan = "";
            Keterangan = "";
            Tanggal = DateTime.Now;
            ListDetilSuratPermintaan = new List<DetilSuratPermintaan>();
        }
        public SuratPermintaan(string noSuratPermintaan, string keterangan, DateTime tanggal, JobOrder jobOrder)
        {
            this.noSuratPermintaan = noSuratPermintaan;
            this.keterangan = keterangan;
            this.tanggal = tanggal;
            this.jobOrder = jobOrder;
            this.listDetilSuratPermintaan = new List<DetilSuratPermintaan>();
        }
        #endregion

        #region Properties
        public string NoSuratPermintaan
        {
            get
            {
                return noSuratPermintaan;
            }

            set
            {
                noSuratPermintaan = value;
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

        public DateTime Tanggal
        {
            get
            {
                return tanggal;
            }

            set
            {
                tanggal = value;
            }
        }

        public JobOrder JobOrder
        {
            get
            {
                return jobOrder;
            }

            set
            {
                jobOrder = value;
            }
        }

        public List<DetilSuratPermintaan> ListDetilSuratPermintaan
        {
            get
            {
                return listDetilSuratPermintaan;
            }

            set
            {
                listDetilSuratPermintaan = value;
            }
        }

        #endregion

        #region Method
        public void TambahDetilBarang(Barang pBarang, int pJumlah)
        {
            DetilSuratPermintaan dsp = new DetilSuratPermintaan(pBarang, pJumlah);
           ListDetilSuratPermintaan.Add(dsp);
        }
        public static string TambahData(SuratPermintaan pSuratPermintaan)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // perintah sql 1 = untuk menambahkan data ke tabel surat permintaan 
                string sql1 = "INSERT INTO suratPermintaan(noSuratPermintaan, tanggal,  keterangan, kodeJobOrder) VALUES ('" +
                    pSuratPermintaan.NoSuratPermintaan + "', '" +
                    pSuratPermintaan.Tanggal.ToString("yyyy-MM-dd ") + "', '" +
                    pSuratPermintaan.Keterangan + "', '" +
                    pSuratPermintaan.JobOrder.KodeJobOrder + "')";

                try
                {
                    //jalankan perintah untuk menambahkan  ke tabel suratpermintaan
                    Koneksi.JalankanPerintahDML(sql1);
                    //menambahkan semua barang yang diminta ke dalam detilsuratpermintaan
                    for (int i = 0; i < pSuratPermintaan.ListDetilSuratPermintaan.Count; i++)
                    {
                        //perintah sql2 = untuk menambahkan barang barang yang diminta ke tabel detilsuratpermintaan
                        string sql2 = "INSERT INTO detilsuratpermintaan(kodebarang, nosuratpermintaan, jumlah) VALUES ('" +
                            pSuratPermintaan.ListDetilSuratPermintaan[i].Barang.KodeBarang + "', '" +
                            pSuratPermintaan.NoSuratPermintaan + "', " +
                            pSuratPermintaan.ListDetilSuratPermintaan[i].Jumlah + ")";

                        //menjalankan perintah untuk menambahkan  ke tabel detilsuratpermintaan
                        Koneksi.JalankanPerintahDML(sql2); 
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

        public static string GenerateNoSuratPermintaan(out string pHasilNoSurat)
        {
            //perintah sql = mendapatkan no surat permintaan terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(nosuratpermintaan, 9, 3) AS noUrutSurat " +
                         "FROM suratpermintaan WHERE Date(tanggal) = Date(CURRENT_DATE) " +
                         "ORDER BY nosuratpermintaan DESC LIMIT 1";
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

        public static string BacaData(string kriteria, string nilaiKriteria, List<SuratPermintaan> listSuratPermintaan)
        {
            string sql1 = "";

            if (kriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel suratpermintaan
                sql1 = "select SP.noSuratPermintaan, SP.tanggal, SP.keterangan, SP.kodejoborder, JO.quantity, JO.directlabor, " +
                       " JO.directmaterial, JO.overheadproduksi from suratpermintaan SP inner join joborder JO on SP.kodejoborder = JO.kodejoborder " +
                       " order by noSuratPermintaan desc";
            }
            else
            {
                sql1 = "select SP.noSuratPermintaan, SP.tanggal, SP.keterangan, SP.kodejoborder, JO.quantity, JO.directlabor, " +
                       " JO.directmaterial, JO.overheadproduksi from suratpermintaan SP inner join joborder JO on SP.kodejoborder = JO.kodejoborder " +
                       "  where " + kriteria + " LIKE '%" + nilaiKriteria + "%' order by noSuratPermintaan desc";
            }

            try
            {
                //data reader 1 = memperoleh semua data di tabelsurat permintaan
                MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
                listSuratPermintaan.Clear();//kosongi isi list terlebih dahulu

                while (hasilData1.Read())
                {

                    //mendapatkan  nosurat ,dll
                    string nomorSurat = hasilData1.GetValue(0).ToString();
                    DateTime tgl = DateTime.Parse(hasilData1.GetValue(1).ToString());
                    string ket = hasilData1.GetValue(2).ToString();

                    //permintaan dari job order 
                    //mendapatkan kode job order
                    string kodeJob = hasilData1.GetValue(3).ToString();
                    int pquantity =int.Parse(hasilData1.GetValue(4).ToString());
                    int labor = int.Parse(hasilData1.GetValue(5).ToString());
                    int material = int.Parse(hasilData1.GetValue(6).ToString());
                    int over = int.Parse(hasilData1.GetValue(7).ToString());

                    //buat object bertipe joborder
                    JobOrder job = new JobOrder();
                    //tambahkan  data 
                    job.KodeJobOrder = kodeJob;
                    job.Quantity = pquantity;
                    job.DirectLabor = labor;
                    job.DirectMaterial = material;
                    job.OverheadProduksi = over;

                    //Surat Permintaan
                    //buat object surat Permintaan dan tambahkan data
                    SuratPermintaan surat = new SuratPermintaan(nomorSurat, ket, tgl,  job);

                    //DETAIL surat permintaan
                    //query utk detail suratpermintaan dari tiap surat
                    //sql2 untuk mendapatkan barang yang akan di gunakan 
                    string sql2 = "SELECT DSP.kodeBarang, B.Nama,  DSP.Jumlah FROM suratpermintaan SP INNER JOIN " +
                                   "detilsuratpermintaan DSP ON SP.nosuratpermintaan = DSP.nosuratpermintaan INNER JOIN Barang B ON " +
                                   "DSP.KodeBarang = B.KodeBarang WHERE SP.nosuratpermintaan = '" + nomorSurat + "'";

                    //memperoleh semua data barang ditabel detilsuratpermintaan
                    MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                    while (hasilData2.Read())
                    {
                        //mendapatkan  kode dan nama barang yang akan digunakan
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
                        DetilSuratPermintaan detilSurat = new DetilSuratPermintaan(brg, jumlah);

                        //simpan detil barang 
                        surat.TambahDetilBarang(brg, jumlah);
                    }
                    //simpan ke list
                    listSuratPermintaan.Add(surat);
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
