using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
   public  class JobOrder
    {
        #region Data Member
        private string kodeJobOrder;
        private int quantity, directLabor, directMaterial, overheadProduksi;
        private DateTime tglMulai, tglSelesai;
        private Barang barang;
        private NotaPenjualan notaPenjualan;
        private List<DetilJobOrder> listDetilJobOrder;
        #endregion

        #region Constructor
        public JobOrder()
        {
            KodeJobOrder = "";
            Quantity = 0;
            DirectLabor = 0;
            DirectMaterial = 0;
            OverheadProduksi = 0;
            TglMulai = DateTime.Now;
            TglSelesai = DateTime.Now;
            ListDetilJobOrder = new List<DetilJobOrder>();
            //barang dan nota penjualan aggregation, tidak boleh di new didalam class

        }
        public JobOrder(string kodeJobOrder, int quantity, int directLabor, int directMaterial, int overheadProduksi, DateTime tglMulai, DateTime tglSelesai, Barang barang, NotaPenjualan notaPenjualan)
        {
            this.kodeJobOrder = kodeJobOrder;
            this.quantity = quantity;
            this.directLabor = directLabor;
            this.directMaterial = directMaterial;
            this.overheadProduksi = overheadProduksi;
            this.tglMulai = tglMulai;
            this.tglSelesai = tglSelesai;
            this.barang = barang;
            this.notaPenjualan = notaPenjualan;
            ListDetilJobOrder = new List<DetilJobOrder>();
        }
        #endregion

        #region Properties
        public string KodeJobOrder
        {
            get
            {
                return kodeJobOrder;
            }

            set
            {
                kodeJobOrder = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public int DirectLabor
        {
            get
            {
                return directLabor;
            }

            set
            {
                directLabor = value;
            }
        }

        public int DirectMaterial
        {
            get
            {
                return directMaterial;
            }

            set
            {
                directMaterial = value;
            }
        }

        public int OverheadProduksi
        {
            get
            {
                return overheadProduksi;
            }

            set
            {
                overheadProduksi = value;
            }
        }

        public DateTime TglMulai
        {
            get
            {
                return tglMulai;
            }

            set
            {
                tglMulai = value;
            }
        }

        public DateTime TglSelesai
        {
            get
            {
                return tglSelesai;
            }

            set
            {
                tglSelesai = value;
            }
        }

        public Barang Barang
        {
            get
            {
                return barang;
            }

            set
            {
                barang = value;
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

        public List<DetilJobOrder> ListDetilJobOrder
        {
            get
            {
                return listDetilJobOrder;
            }

            set
            {
                listDetilJobOrder = value;
            }
        }

        #endregion

        #region Method
        public void TambahDetilJobOrder(Karyawan pKaryawan,  string pSatuan, int pGajiPerSatuan)
        {
            DetilJobOrder djo = new DetilJobOrder(pKaryawan, pSatuan,pGajiPerSatuan);
            ListDetilJobOrder.Add(djo);


        }
        //method untuk mengubah data direct material saat penerimaan bahan baku
        public static string UpdateDirectMaterial(JobOrder pJob)
        {
            string sql = "UPDATE jobOrder SET directMaterial = " +
                        pJob.DirectMaterial + " where kodeJobOrder = '" + pJob.KodeJobOrder  + "'";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql: " + sql;
            }
        }
        // method untuk mengubah data  overhead produksi saat ada barang tambahan
        public static string UpdateOverheadProduksi(JobOrder pJob)
        {
            string sql = "UPDATE jobOrder SET overheadProduksi = " +
                        pJob.DirectMaterial + " where kodeJobOrder = '" + pJob.KodeJobOrder + "'";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql: " + sql;
            }
        }
        public static string TambahData(JobOrder pJobOrder)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // perintah sql 1 = untuk menambahkan data ke tabel Job Order
                string sql1 = "INSERT INTO JobOrder(kodeJobOrder, quantity,  directLabor, directMaterial, overheadProduksi, tglMulai, tglSelesai, kodeBarang, " +
                    " noNotaPenjualan) VALUES ('" +
                    pJobOrder.KodeJobOrder + "', " +
                    pJobOrder.Quantity + ", " +
                    pJobOrder.DirectLabor + ", " +
                    pJobOrder.DirectMaterial + ", " +
                    pJobOrder.OverheadProduksi + ", '" +
                    pJobOrder.TglMulai.ToString("yyyy-MM-dd ") + "', '" +
                    pJobOrder.TglSelesai.ToString("yyyy-MM-dd ") + "', '" +
                    pJobOrder.Barang.KodeBarang + "', '" +
                    pJobOrder.NotaPenjualan.NoNotaPenjualan+ "')";

                try
                {
                    //jalankan perintah untuk menambahkan  ke tabel JobOrder
                    Koneksi.JalankanPerintahDML(sql1);
                    //menambahkan data karyawan yang harus dibayar atau gajikaryawan yang terlibat
                    for (int i = 0; i < pJobOrder.ListDetilJobOrder.Count; i++)
                    {
                        //perintah sql2 = untuk menambahkan ke tabel detiljoborder
                        string sql2 = "INSERT INTO detilJobOrder(kodeJobOrder, idKaryawan, satuan, gajiPerSatuan) VALUES ('" +
                            pJobOrder.KodeJobOrder + "', " +
                            pJobOrder.ListDetilJobOrder[i].Karyawan.IdKaryawan+ ", '" +
                            pJobOrder.ListDetilJobOrder[i].Satuan + "', " +
                            pJobOrder.ListDetilJobOrder[i].GajiPerSatuan + ")";

                        //menjalankan perintah untuk menambahkan  ke tabel detilJobOrder
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

        public static string GenerateKodeJobOrder(out string pHasilKodeJobOrder)
        {
            pHasilKodeJobOrder = "";

            //perintah sql = mendapatkan nourut nota terakhir ditanggal hari ini(tanggal komputer)
            // format job order J###
            //ambil urutan mulai yang 2, sebanyak 3 digit  tampilkan sebagai nourutJoborder 
            //gunakan desc  untuk mendapatkan urutan yang paling besar
            string sql = "SELECT SUBSTRING(kodeJobOrder, 2, 3) AS noUrutJobOrder " + 
                         " FROM jobOrder ORDER BY kodeJoborder DESC LIMIT 1";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutJobOrderTerbaru = "";
                //cek apakah sudah ada Job order di db
                if (hasilData.Read())//jika ada data
                {
                    int noUrutJobOrder = int.Parse(hasilData.GetValue(0).ToString()) + 1; //dapatkan no urut joborder terbaru
                    noUrutJobOrderTerbaru = noUrutJobOrder.ToString().PadLeft(3,'0'); // menampilkan 3 digit 00noUrutJobOrder
                }
                else //jika belum ada data
                {
                    noUrutJobOrderTerbaru = "001";
                }
                //generate kode JObOrder terbaru sesuai format terbaru
                pHasilKodeJobOrder = "J" + noUrutJobOrderTerbaru.ToString();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static string BacaData(string kriteria, string nilaiKriteria, List<JobOrder> listJobOrder)
        {
            string sql1 = "";

            if (kriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel JobOrder 
                sql1 = "SELECT J.kodeJobOrder, B.kodeBarang, B.nama as Item, B.hargaBeliTerbaru, J.quantity, B.satuan, J.directMaterial, J.directLabor, " +
                       " J.overheadProduksi, J.tglMulai, J.tglSelesai, J.noNotaPenjualan FROM notapenjualan NP inner join " +
                       " joborder J on NP.noNotaPenjualan = J.noNotaPenjualan inner join barang B on B.kodeBarang = J.kodebarang order by kodejoborder DESC ";
            }
            else
            {
                sql1 = "SELECT J.kodeJobOrder, B.kodeBarang, B.nama as Item, B.hargaBeliTerbaru, J.quantity, B.satuan, J.directMaterial, J.directLabor, " +
                       " J.overheadProduksi, J.tglMulai, J.tglSelesai, J.noNotaPenjualan FROM notapenjualan NP inner join " +
                       " joborder J on NP.noNotaPenjualan = J.noNotaPenjualan inner join barang B on B.kodeBarang = J.kodebarang " + 
                       kriteria + " LIKE '%" + nilaiKriteria + "%' order by kodejoborder DESC";
            }

            try
            {
                //data reader 1 = memperoleh semua data di tabel job order
                MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
                listJobOrder.Clear();//kosongi isi list terlebih dahulu
                while (hasilData1.Read()) 
                {

                    //mendapatkan  kodeJobOrder, quantity , satuan, dll
                    string kodeJob = hasilData1.GetValue(0).ToString();
                    int pQuantity = int.Parse(hasilData1.GetValue(4).ToString());
                    int pMaterial = int.Parse(hasilData1.GetValue(6).ToString());
                    int pLabor = int.Parse(hasilData1.GetValue(7).ToString());
                    int pOver = int.Parse(hasilData1.GetValue(8).ToString());
                    DateTime pMulai = DateTime.Parse(hasilData1.GetValue(9).ToString());
                    DateTime pSelesai = DateTime.Parse(hasilData1.GetValue(10).ToString());

                    //tambahkan no nota
                    string noNota = hasilData1.GetValue(11).ToString();
                    NotaPenjualan nota = new NotaPenjualan();
                    nota.NoNotaPenjualan = noNota;

                    //barang  yang akan dibuat
                    //mendapatkan kode barang, nama, harga 
                    string kodeBrng = hasilData1.GetValue(1).ToString();
                    string namaBrng = hasilData1.GetValue(2).ToString();
                    int harga =int.Parse(hasilData1.GetValue(3).ToString());
                    string pSatuan = hasilData1.GetValue(5).ToString();

                    //buat object bertipe barang
                    Barang barang = new Barang();
                    //tambahkan 4 data dibawah
                    barang.KodeBarang = kodeBrng;
                    barang.Nama = namaBrng;
                    barang.HargaBeliTerbaru = harga;
                    barang.Satuan = pSatuan;

                    //job order
                    //buat object joborder dan tambahkan data
                    JobOrder job = new JobOrder(kodeJob, pQuantity, pLabor, pMaterial, pOver, pMulai, pSelesai,barang,nota);

                    //DETAIL Job Order
                    //query utk detail Job Order 
                    //sql2 untuk menghitung directlabor
                    string sql2 = "SELECT K.idkaryawan, K.Nama, K.gender, K.notelepon, DJO.satuan, DJO.gajiPerSatuan FROM joborder JO INNER JOIN " +
                                   "detilJobOrder DJO ON JO.kodejoborder = DJO.kodejoborder INNER JOIN karyawan K ON " +
                                   "DJO.idkaryawan = K.idkaryawan WHERE JO.kodejobOrder = '" + kodeJob + "'";

                    //memperoleh semua data  
                    MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                    while (hasilData2.Read())
                    {
                        //mendapatkan  id dan nama karyawan yang bekerja 
                        string idKary = hasilData2.GetValue(0).ToString();
                        string namaKary = hasilData2.GetValue(1).ToString();
                        string pGender = hasilData2.GetValue(2).ToString();
                        string noTelp = hasilData2.GetValue(3).ToString();

                        //buat object Karyawan dan tambahkan
                        Karyawan K = new Karyawan();
                        K.IdKaryawan = idKary;
                        K.Nama = namaKary;
                        K.Gender = pGender;
                        K.NoTelepon = noTelp;

                        //mendapatkan satuan dan Gaji persatuan transaksi 
                        string pSat = hasilData2.GetValue(4).ToString();
                        int gajiSatuan = int.Parse(hasilData2.GetValue(5).ToString());

                        //buat object bertipe detilJoborder dan tambahkan 
                        //ingat baik baik agar fk tidak duplicate
                        DetilJobOrder detilJob = new DetilJobOrder(K,pSat,gajiSatuan);

                        //simpan 
                        job.TambahDetilJobOrder(K, pSat, gajiSatuan);
                    }
                    //simpan ke list
                    listJobOrder.Add(job);
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
