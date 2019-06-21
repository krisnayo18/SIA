using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
    public class NotaPembelian
    {
        #region Data Member
        private string noNotaPembelian, status, keterangan;
        private double diskon;
        private int totalHarga;
        private DateTime tglBatasPelunasan, tglBatasDiskon, tglBeli;
        private Supplier supplier;
        private List<DetilNotaBeli> listNotaBeliDetil;
        #endregion

        #region Constructor
        public NotaPembelian()
        {
            NoNotaPembelian = "";
            Status = "";
            Keterangan = "";
            Diskon = 0;
            TotalHarga = 0;
            TglBatasPelunasan = DateTime.Now;
            TglBatasDiskon = DateTime.Now;
            TglBeli = DateTime.Now;
            ListNotaBeliDetil = new List<DetilNotaBeli>();
        }
        public NotaPembelian(string noNotaPembelian, string status, string keterangan, double diskon, int totalHarga, DateTime tglBatasPelunasan, DateTime tglBatasDiskon, DateTime tglBeli, Supplier supplier)
        {
            this.noNotaPembelian = noNotaPembelian;
            this.status = status;
            this.keterangan = keterangan;
            this.diskon = diskon;
            this.totalHarga = totalHarga;
            this.tglBatasPelunasan = tglBatasPelunasan;
            TglBatasDiskon = tglBatasDiskon;
            this.tglBeli = tglBeli;
            this.supplier = supplier;
            ListNotaBeliDetil = new List<DetilNotaBeli>();
        }
        #endregion

        #region Properties
        public string NoNotaPembelian
        {
            get
            {
                return noNotaPembelian;
            }

            set
            {
                noNotaPembelian = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
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

        public double Diskon
        {
            get
            {
                return diskon;
            }

            set
            {
                diskon = value;
            }
        }

        public int TotalHarga
        {
            get
            {
                return totalHarga;
            }

            set
            {
                totalHarga = value;
            }
        }

        public DateTime TglBatasPelunasan
        {
            get
            {
                return tglBatasPelunasan;
            }

            set
            {
                tglBatasPelunasan = value;
            }
        }

        public DateTime TglBatasDiskon
        {
            get
            {
                return tglBatasDiskon;
            }

            set
            {
                tglBatasDiskon = value;
            }
        }

        public DateTime TglBeli
        {
            get
            {
                return tglBeli;
            }

            set
            {
                tglBeli = value;
            }
        }

        public Supplier Supplier
        {
            get
            {
                return supplier;
            }

            set
            {
                supplier = value;
            }
        }

        public List<DetilNotaBeli> ListNotaBeliDetil
        {
            get
            {
                return listNotaBeliDetil;
            }

          private  set
            {
                listNotaBeliDetil = value;
            }
        }

        #endregion

        #region Method
        public void TambahDetilBarang(Barang pBarang, int pJumlah, int pHargaJual)
        {
            DetilNotaBeli dnb = new DetilNotaBeli(pBarang, pJumlah, pHargaJual);
            ListNotaBeliDetil.Add(dnb);


        }
        public static string TambahData(NotaPembelian pNotaBeli)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // perintah sql 1 = untuk menambahkan data ke tabel nota pembelian 
                string sql1 = "INSERT INTO notapembelian(noNotaPembelian, diskon,  totalHarga, tglBatasPelunasan, tglBatasDiskon, tglBeli, status, keterangan, idsupplier) VALUES ('" +
                    pNotaBeli.NoNotaPembelian+ "', " +
                    pNotaBeli.Diskon + ", " +
                    pNotaBeli.TotalHarga + ", '" +
                    pNotaBeli.TglBatasPelunasan.ToString("yyyy-MM-dd ") + "', '" +
                    pNotaBeli.TglBatasDiskon.ToString("yyyy-MM-dd ") + "', '" +
                    pNotaBeli.TglBeli.ToString("yyyy-MM-dd ") + "', '" +
                    pNotaBeli.Status + "', '" +
                    pNotaBeli.Keterangan + "', " +
                    pNotaBeli.Supplier.IdSupplier + ")";

                try
                {
                    //jalankan perintah untuk menambahkan  ke tabel notapembelian
                    Koneksi.JalankanPerintahDML(sql1);
                    //menambahkan semua barang yang dibeli ke dalam detilnotabeli
                    for (int i = 0; i < pNotaBeli.ListNotaBeliDetil.Count; i++)
                    {
                        //perintah sql2 = untuk menambahkan barang barang yang dibeli ke tabel detilnotabeli
                        string sql2 = "INSERT INTO detilnotabeli(noNotaPembelian, kodeBarang, jumlah, hargaBeli) VALUES ('" +
                            pNotaBeli.NoNotaPembelian + "', '" +
                            pNotaBeli.ListNotaBeliDetil[i].Barang.KodeBarang + "', " +
                            pNotaBeli.ListNotaBeliDetil[i].Jumlah + ", " +
                            pNotaBeli.ListNotaBeliDetil[i].HargaBeli + ")";

                        //menjalankan perintah untuk menambahkan  ke tabel notabelidetil
                        Koneksi.JalankanPerintahDML(sql2);

                        //panggil method untuk menambah stok/quantity barang yang dibeli
                        string hasilUpdateBrng = Barang.UbahStokBeli(pNotaBeli.ListNotaBeliDetil[i].Barang.KodeBarang, pNotaBeli.ListNotaBeliDetil[i].Jumlah);
                        string hasilUbahHargaBeli = Barang.UbahHargaBeliTerbaru(pNotaBeli.ListNotaBeliDetil[i].Barang.KodeBarang, pNotaBeli.ListNotaBeliDetil[i].HargaBeli);
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

        public static string GenerateNoNota(out string pHasilNoNota)
        {
            //perintah sql = mendapatkan nourut nota terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(noNotaPembelian, 9, 3) AS noUrutTransaksi " +
                         "FROM notaPembelian WHERE Date(tglBeli) = Date(CURRENT_DATE) " +
                         "ORDER BY noNotaPembelian DESC LIMIT 1";
            pHasilNoNota = "";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutTransTerbaru = "";
                //cek apakah sudah ada transaksi  pada tanggal  hari ini (data reader dari sql  diatas bisa terbca atau tidak )
                if (hasilData.Read())//jika berhasil membaca data (sudah ada transaksi pada hari ini)
                {
                    int noUrutTrans = int.Parse(hasilData.GetValue(0).ToString()) + 1; //dapatkan no urut transaksi terbaru 
                    noUrutTransTerbaru = noUrutTrans.ToString().PadLeft(3, '0'); // jika nourutTransaksi pada hari ini 
                }
                else //jika belum ada transaksi hari ini
                {
                    noUrutTransTerbaru = "001";
                }
                //generate nomor nota terbaru dengan format yyyymmddxxx (y tahun, m bulan, d hari , dan xxx no urut transaksi tgl tsb)
                string tahun = DateTime.Now.Year.ToString();//dapatkan tahun dari tanggal kompter
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');//dapatkan bulan
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');//dapatkan hari

                //generate nomor nota terbaru sesuai format terbaru
                pHasilNoNota = tahun + bulan + tanggal + noUrutTransTerbaru.ToString();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public static string BacaData(string kriteria, string nilaiKriteria, List<NotaPembelian> listNotaBeli)
        {
            string sql1 = "";

            if (kriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  tabel nota pembelian
                sql1 = "select * from vnotapembelian";
            }
            else
            {
                sql1 = "SELECT * FROM vnotapembelian WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                //data reader 1 = memperoleh semua data dari tabel notaPembelian
                MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
                listNotaBeli.Clear();//kosongi isi list terlebih dahulu

                while (hasilData1.Read())
                {

                    //mendapatkan  nomornota, status ,dll
                    string nomorNota = hasilData1.GetValue(0).ToString(); // nonotapembelian
                    double diskon = double.Parse(hasilData1.GetValue(4).ToString()); // diskon
                    int totalHarga = int.Parse(hasilData1.GetValue(5).ToString()); 
                    DateTime tglBatasPelunasan = DateTime.Parse(hasilData1.GetValue(6).ToString());
                    DateTime tglBatasDiskon = DateTime.Parse(hasilData1.GetValue(7).ToString());
                    DateTime tglBeli = DateTime.Parse(hasilData1.GetValue(8).ToString());
                    string status = hasilData1.GetValue(9).ToString();
                    string keterangan = hasilData1.GetValue(10).ToString();

                    //supplier yang melakukan transaksi
                    //mendapatkan idsupplier, nama, dan alamat 
                    string idSup = hasilData1.GetValue(1).ToString();
                    string namaSup = hasilData1.GetValue(2).ToString();
                    string alamatSup = hasilData1.GetValue(3).ToString();

                    //buat object bertipe Supplier
                    Supplier spl = new Supplier();
                    //tambahkan 3 data dibawah
                    spl.IdSupplier = idSup;
                    spl.Nama = namaSup;
                    spl.Alamat = alamatSup;

                    //nota beli
                    //buat object notapembelian dan tambahkan data
                    NotaPembelian nota = new NotaPembelian(nomorNota, status, keterangan, diskon, totalHarga,
                                                            tglBatasPelunasan, tglBatasDiskon, tglBeli, spl);

                    //DETAIL nota Beli
                    //query utk detail nota Beli dati tiap nota beli
                    //sql2 untuk mendapatkan barang yang ada di nota  (dar tabel detilnotabeli)
                    string sql2 = "SELECT DNB.kodeBarang, B.Nama, DNB.Jumlah , DNB.HargaBeli FROM NotaPembelian N INNER JOIN " +
                                   "detilNotaBeli DNB ON N.noNotaPembelian = DNB.noNotaPembelian INNER JOIN Barang B ON " +
                                   "DNB.KodeBarang = B.KodeBarang WHERE N.noNotaPembelian = '" + nomorNota + "'";

                    //memperoleh semua data barang nota ditabel detilnotabeli
                    MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                    while (hasilData2.Read())
                    {
                        //mendapatkan  kode dan nama barang yang dibeli
                        string kodeBrg = hasilData2.GetValue(0).ToString();
                        string namaBrg = hasilData2.GetValue(1).ToString();
                        //buat object barang dan tambahkan
                        Barang brg = new Barang();
                        brg.KodeBarang = kodeBrg;
                        brg.Nama = namaBrg;

                        //mendapatkan harga beli dan jumlah transaksi 
                        int hargaBeli = int.Parse(hasilData2.GetValue(3).ToString());
                        int jumlah = int.Parse(hasilData2.GetValue(2).ToString());

                        //buat object bertipe detilnotabeli dan tambahkan 
                        //ingat baik baik agar fk tidak duplicate
                        DetilNotaBeli detilNota = new DetilNotaBeli(brg, jumlah, hargaBeli);

                        //simpan detil barang ke nota
                        nota.TambahDetilBarang(brg, jumlah, hargaBeli);
                    }
                    //simpan ke list
                    listNotaBeli.Add(nota);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        public static string CetakNota(string pKriteria, string pNilaiKriteria, string pNamaFile)
        {
            try
            {
                List<NotaPembelian> listNotaBeli = new List<NotaPembelian>();

                string hasilBaca = NotaPembelian.BacaData(pKriteria, pNilaiKriteria, listNotaBeli);

                StreamWriter file = new StreamWriter(pNamaFile);

                for (int i = 0; i < listNotaBeli.Count; i++)
                {
                    file.WriteLine("");
                    file.WriteLine("TOKO MAJU MAKMUR UNTUNG SELALU");
                    file.WriteLine("Jl. Raya Kalirungkut Surabaya");
                    file.WriteLine("Telp. (031) - 12345678");
                    file.WriteLine("=".PadRight(50, '='));

                    //Header
                    file.WriteLine("No.Nota : " + listNotaBeli[i].NoNotaPembelian);
                    file.WriteLine("Tanggal : " + listNotaBeli[i].TglBeli);
                    file.WriteLine("");
                    file.WriteLine("Supplier : " + listNotaBeli[i].Supplier.Nama);
                    file.WriteLine("Alamat   : " + listNotaBeli[i].Supplier.Alamat);
                    file.WriteLine("");
                    //file.WriteLine("Pegawai Pembelian : " + listNotaBeli[i]..Nama);
                    file.WriteLine("=".PadRight(50, '='));

                    //Tampilkan barang yg terjual
                    long grandTotal = 0;
                    for (int j = 0; j < listNotaBeli[i].ListNotaBeliDetil.Count; j++)
                    {
                        string nama = listNotaBeli[i].ListNotaBeliDetil[j].Barang.Nama;

                        if (nama.Length > 30)
                        {
                            nama = nama.Substring(0, 30);
                        }

                        int jmlh = listNotaBeli[i].ListNotaBeliDetil[j].Jumlah;
                        long harga = listNotaBeli[i].ListNotaBeliDetil[j].HargaBeli;
                        long subTotal = jmlh * harga;

                        file.Write(nama.PadRight(30, ' '));
                        file.Write(jmlh.ToString().PadRight(3, ' '));
                        file.Write(harga.ToString("0,###").PadLeft(7, ' '));
                        file.Write(subTotal.ToString("0,###").PadLeft(10, ' '));
                        file.WriteLine("");
                        //hitung grand total
                        grandTotal = grandTotal + (jmlh * harga);
                    }
                    file.WriteLine("=".PadRight(50, '='));
                    file.WriteLine("TOTAL : " + grandTotal.ToString("0,###"));
                    file.WriteLine("=".PadRight(50, '='));
                    file.WriteLine("");
                }
                file.Close();

                //cetak ke printer
                Cetak c = new Cetak(pNamaFile, "Courier New", 9, 10, 10, 10, 10);
                c.CetakKePrinter("tulisan");
                return "1";
            }
            catch (MySqlException e)
            {
                return e.Message;
            }
        }
        #endregion
    }
}
