using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibraryTransaksi
{
    public class NotaPenjualan
    {

        #region Data Member
        private string noNotaPenjualan, status, keterangan;
        private double diskon;
        private int totalHarga;
        private DateTime tglBatasPelunasan, tglBatasDiskon, tglJual;
        private Pelanggan pelanggan;
        private List<DetilNotaJual> listNotaJualDetil;

        #endregion

        #region Constructor 
        public NotaPenjualan(string noNotaPenjualan, string status, string keterangan, double diskon, int totalHarga, DateTime tglBatasPelunasan, DateTime tglBatasDiskon,  DateTime pTglJual, Pelanggan pelanggan)
        {
            this.noNotaPenjualan = noNotaPenjualan;
            this.status = status;
            this.keterangan = keterangan;
            this.diskon = diskon;
            this.totalHarga = totalHarga;
            this.tglBatasPelunasan = tglBatasPelunasan;
            this.tglBatasDiskon = tglBatasDiskon;
            this.tglJual = pTglJual;
            this.pelanggan = pelanggan;
            ListNotaJualDetil = new List<DetilNotaJual>();
        }
        public NotaPenjualan()
        {
            NoNotaPenjualan = "";
            Status = "";
            Keterangan = "";
            Diskon = 0;
            TotalHarga = 0;
            TglBatasPelunasan = DateTime.Now;
            TglBatasDiskon = DateTime.Now;
            TglJual = DateTime.Now;
            ListNotaJualDetil = new List<DetilNotaJual>();
        }
        #endregion

        #region Properties
        public string NoNotaPenjualan
        {
            get
            {
                return noNotaPenjualan;
            }

            set
            {
                noNotaPenjualan = value;
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


        public Pelanggan Pelanggan
        {
            get
            {
                return pelanggan;
            }

            set
            {
                pelanggan = value;
            }
        }

        public List<DetilNotaJual> ListNotaJualDetil
        {
            get
            {
                return listNotaJualDetil;
            }

            set
            {
                listNotaJualDetil = value;
            }
        }

        public DateTime TglJual
        {
            get
            {
                return tglJual;
            }

            set
            {
                tglJual = value;
            }
        }



        #endregion

        #region Method
        public void TambahDetilBarang(Barang pBarang, int pJumlah, int pHargaJual)
        {
            DetilNotaJual dnj = new DetilNotaJual(pBarang, pJumlah, pHargaJual);
            ListNotaJualDetil.Add(dnj);


        }
        public static string TambahData(NotaPenjualan pNotaJual)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                string sql1 = "INSERT INTO notapenjualan(noNotaPenjualan, diskon,  totalHarga, tglBatasPelunasan, tglBatasDiskon, tglJual, status, keterangan, idPelanggan) VALUES ('" + 
                    pNotaJual.NoNotaPenjualan + "', " +
                    pNotaJual.Diskon + ", " + 
                    pNotaJual.TotalHarga + ", '" +
                    pNotaJual.TglBatasPelunasan.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                    pNotaJual.TglBatasPelunasan.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                    pNotaJual.TglJual.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                    pNotaJual.Status + "', '"+
                    pNotaJual.Keterangan + "', " +
                    pNotaJual.Pelanggan.IdPelanggan + ")";

                try
                {
                    Koneksi.JalankanPerintahDML(sql1);

                    for (int i = 0; i < pNotaJual.ListNotaJualDetil.Count; i++)
                    {
                        string sql2 = "INSERT INTO detilNotaJual(noNotaPenjualan, kodeBarang, jumlah, hargaJual) VALUES ('" + 
                            pNotaJual.NoNotaPenjualan + "', '" + 
                            pNotaJual.ListNotaJualDetil[i].Barang.KodeBarang + "', " + 
                            pNotaJual.ListNotaJualDetil[i].Jumlah + ", " + 
                            pNotaJual.ListNotaJualDetil[i].HargaJual + ")";

                        Koneksi.JalankanPerintahDML(sql2);

                        string hasilUpdateBrng = Barang.UbahStokTerjual(pNotaJual.ListNotaJualDetil[i].Barang.KodeBarang, pNotaJual.ListNotaJualDetil[i].Jumlah);
                    }
                    tranScope.Complete();
                    return "1";
                }
                catch (Exception e)
                {
                    return e.Message;
                    tranScope.Dispose();
                }
            }

        }
        public static string GenerateNoNota(out string pHasilNoNota)
        {
            string sql = "SELECT SUBSTRING(NoNotaPenjualan, 9, 3) AS noUrutTransaksi " +
                         "FROM notaPenjualan WHERE Date(tglJual) = Date(CURRENT_DATE) " +
                         "ORDER BY noNotaPenjualan DESC LIMIT 1";
            pHasilNoNota = "";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                string noUrutTransTerbaru = "";
                if (hasilData.Read() == true)
                {
                    int noUrutTrans = int.Parse(hasilData.GetValue(0).ToString()) + 1;
                    noUrutTransTerbaru = noUrutTrans.ToString().PadLeft(3, '0');
                }
                else
                {
                    noUrutTransTerbaru = "001";
                }
                string tahun = DateTime.Now.Year.ToString();
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');

                pHasilNoNota = tahun + bulan + tanggal + noUrutTransTerbaru.ToString();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public static string BacaData(string kriteria, string nilaiKriteria, List<NotaPenjualan> listNotaJual)
        {
            string sql1 = "";

            if (kriteria == "")
            {
                sql1 = "SELECT N.noNotaPenjualan, N.idPelanggan, P.nama AS NamaPelanggan, P.alamat AS AlamatPelanggan, N.diskon,  N.totalHarga, N.tglBatasPelunasan, N.tglBatasDiskon, N.tglJual, N.status, N.keterangan FROM " +
                       "NotaPenjualan N INNER JOIN Pelanggan P ON N.idPelanggan = P.idPelanggan ORDER BY N.NoNotaPenjualan DESC";
            }
            else
            {
                sql1 = "SELECT N.noNotaPenjualan, N.idPelanggan, P.nama AS NamaPelanggan, P.alamat AS AlamatPelanggan, N.diskon,  N.totalHarga, N.tglBatasPelunasan, N.tglBatasDiskon, N.tglJual, N.status, N.keterangan FROM " +
                        "NotaPenjualan N INNER JOIN Pelanggan P ON N.idPelanggan = P.idPelanggan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' ORDER BY N.NoNotaPenjualan DESC";
            }

            try
            {
                MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
                listNotaJual.Clear();

                while (hasilData1.Read() == true)
                {

                    //nomor & tgl nota
                    string nomorNota = hasilData1.GetValue(0).ToString();
                    string status = hasilData1.GetValue(9).ToString();
                    string keterangan = hasilData1.GetValue(10).ToString();
                    double diskon = double.Parse(hasilData1.GetValue(4).ToString());
                    int totalHarga = int.Parse(hasilData1.GetValue(5).ToString());
                    DateTime tglBatasPelunasan = DateTime.Parse(hasilData1.GetValue(6).ToString());
                    DateTime tglBatasDiskon = DateTime.Parse(hasilData1.GetValue(7).ToString());
                    DateTime tglJual = DateTime.Parse(hasilData1.GetValue(8).ToString());

                    //pelanggan
                    int idPlg = int.Parse(hasilData1.GetValue(1).ToString());
                    string namaPlg = hasilData1.GetValue(2).ToString();
                    string alamatPlg = hasilData1.GetValue(3).ToString();
                    Pelanggan plg = new Pelanggan();
                    plg.IdPelanggan = idPlg;
                    plg.Nama = namaPlg;
                    plg.Alamat = alamatPlg;

                    NotaPenjualan nota = new NotaPenjualan( nomorNota,  status,  keterangan,  diskon, totalHarga,  tglBatasPelunasan,tglBatasDiskon, tglJual, plg);

                    //DETAIL
                    //query utk detail nota jual
                    string sql2 = "SELECT ND.KodeBarang, B.Nama, ND.Jumlah , ND.HargaJual FROM NotaPenjualan N INNER JOIN detilNotaJual ND ON N.NoNotaPenjualan = ND.NoNotaPenjualan INNER JOIN Barang B ON ND.KodeBarang = B.KodeBarang WHERE N.NoNotaPenjualan = '" + nomorNota + "'";
                    MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);
                    while (hasilData2.Read() == true)
                    {
                        //barang
                        string kodeBrg = hasilData2.GetValue(0).ToString();
                        string namaBrg = hasilData2.GetValue(1).ToString();
                        Barang brg = new Barang();
                        brg.KodeBarang = kodeBrg;
                        brg.Nama = namaBrg;

                        //harga dan jumlah
                        int hargaJual = int.Parse(hasilData2.GetValue(3).ToString());
                        int jumlah = int.Parse(hasilData2.GetValue(2).ToString());

                        //NotaJualDetil detilNota = new NotaJualDetil(brg, jumlah, hargaJual);

                        //simpan di nota
                        nota.TambahDetilBarang(brg, jumlah, hargaJual);
                    }

                    listNotaJual.Add(nota);
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
