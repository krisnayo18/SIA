using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Pembayaran
    {
        #region Data Member
        private string idPembayaran, caraPembayaran;
        private DateTime tgl;
        private int nominal;
        private NotaPembelian notaPembelian;
        #endregion

        #region Constructor
        public Pembayaran()
        {
            IdPembayaran = "";
            CaraPembayaran = "";
            Tgl = DateTime.Now;
            Nominal = 0;
        }
        public Pembayaran(string idPembayaran, string caraPembayaran, DateTime tgl, int nominal, NotaPembelian notaPembelian)
        {
            this.idPembayaran = idPembayaran;
            this.caraPembayaran = caraPembayaran;
            this.tgl = tgl;
            this.nominal = nominal;
            this.notaPembelian = notaPembelian;
        }
        #endregion

        #region Properties
        public string IdPembayaran
        {
            get
            {
                return idPembayaran;
            }

            set
            {
                idPembayaran = value;
            }
        }

        public string CaraPembayaran
        {
            get
            {
                return caraPembayaran;
            }

            set
            {
                caraPembayaran = value;
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

        public int Nominal
        {
            get
            {
                return nominal;
            }

            set
            {
                nominal = value;
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
        public static string TambahData(Pembayaran pPemb, NotaPembelian pNota)
        {
            //sql1 untuk menambahkan data ke tabel pembayaran
            string sql = "Insert into pembayaran(idPembayaran, tgl, caraPembayaran, nominal, noNotaPembelian) values ('" +
                        pPemb.IdPembayaran + "',  '" +
                        pPemb.Tgl.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                        pPemb.CaraPembayaran + "'," +
                        pPemb.Nominal + ", '" +
                        pPemb.NotaPembelian.NoNotaPembelian + "')";
            try
            {
                //jalankan perintah sql untuk menambahkan ke tabel 
                Koneksi.JalankanPerintahDML(sql);

                //sql2 untuk mengubah status notapenjualan yang belum lunas atau P menjadi L
                string sql2 = "UPDATE notapembelian SET  status ='" +
                       pNota.Status + "' WHERE  noNotaPembelian = '" +
                    pNota.NoNotaPembelian + "'";

                //jalankan sql2 untuk menambhkan ke detiljurnal
                Koneksi.JalankanPerintahDML(sql2);



                //jika semua perintah sql berhasil dijalankan
                return "1";
            }
            catch (MySqlException ex)
            {
                //jika ada kegagalan perintah
                return ex.Message;
            }
        }
        public static string BacaData(string pKriteria, string pNilaiKriteria, List<Pembayaran> listHasilData)
        {
            string sql = "";

            if (pKriteria == "")
            {
                sql = " select P.idPembayaran, P.tgl, P.caraPembayaran, P.nominal, NP.noNotaPembelian, NP.diskon FROM pembayaran P inner join " +
                      " notapembelian NP on P.nonotapembelian = NP.nonotapembelian ";


            }
            else
            {
                sql = "  select P.idPembayaran, P.tgl, P.caraPembayaran, P.nominal, NP.noNotaPembelian, NP.diskon FROM pembayaran P inner join " +
                      " notapembelian NP on P.nonotapembelian = NP.nonotapembelian where " 
                      + pKriteria + " LIKE '%" +
                       pNilaiKriteria + "%'";

            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();

                while (hasilData.Read() == true)
                {

                    string idpemb = hasilData.GetValue(0).ToString();
                    DateTime tanggal = DateTime.Parse(hasilData.GetValue(1).ToString());
                    string caraPemb = hasilData.GetValue(2).ToString();
                    int nominal = int.Parse(hasilData.GetValue(3).ToString());


                    NotaPembelian nota = new NotaPembelian();
                    nota.NoNotaPembelian = hasilData.GetValue(4).ToString();
                    Pembayaran pembayaran = new Pembayaran(idpemb, caraPemb, tanggal, nominal,nota);
                    listHasilData.Add(pembayaran);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }
        public static string GenerateNoNota(out string pHasilNoPemb)
        {
            //perintah sql = mendapatkan nourut nota terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(idpembayaran, 9, 3) AS noUrutPemb " +
                         "FROM pembayaran WHERE Date(tgl) = Date(CURRENT_DATE) " +
                         "ORDER BY idpembayaran DESC LIMIT 1";
            pHasilNoPemb = "";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutPembTerbaru = "";
                //cek apakah sudah ada transaksi  pada tanggal  hari ini (data reader dari sql  diatas bisa terbca atau tidak )
                if (hasilData.Read() == true)//jika berhasil membaca data (sudah ada transaksi pada hari ini)
                {
                    int noUrutPemb = int.Parse(hasilData.GetValue(0).ToString()) + 1; //dapatkan no urut Pemb terbaru 
                    noUrutPembTerbaru = noUrutPemb.ToString().PadLeft(3, '0'); // jika nourutPemba pada hari ini 
                }
                else //jika belum ada transaksi hari ini
                {
                    noUrutPembTerbaru = "001";
                }
                //generate nomor nota terbaru dengan format yyyymmddxxx (y tahun, m bulan, d hari , dan xxx no urut transaksi tgl tsb)
                string tahun = DateTime.Now.Year.ToString();//dapatkan tahun dari tanggal kompter
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');//dapatkan bulan
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');//dapatkan hari

                //generate nomor nota terbaru sesuai format terbaru
                pHasilNoPemb = tahun + bulan + tanggal + noUrutPembTerbaru.ToString();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public static string BacaDataPembayaran(string pKriteria, string pNilaiKriteria, List<NotaPembelian> listNotaBeli)
        {
            string sql = "";
            if (pKriteria == "")
            {
                sql = "select * from notapembelian where status ='B'";


            }
            else
            {
                sql = " select * from notapembelian where status ='B' and "
                      + pKriteria + " LIKE '%" +
                       pNilaiKriteria + "%'";

            }
            try
            {

                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listNotaBeli.Clear();//kosongi isi list terlebih dahulu

                while (hasilData.Read())
                {

                    string nomornota = hasilData.GetValue(0).ToString();
                    int nominal = int.Parse(hasilData.GetValue(2).ToString());
                    string status = hasilData.GetValue(6).ToString();
                    double disc = double.Parse(hasilData.GetValue(1).ToString());
                    DateTime btsDisc = DateTime.Parse(hasilData.GetValue(4).ToString());

                    NotaPembelian nota = new NotaPembelian();
                    nota.NoNotaPembelian = nomornota;
                    nota.Status = status;
                    nota.TotalHarga = nominal;
                    nota.Diskon = disc;
                    nota.TglBatasDiskon = btsDisc;
                    listNotaBeli.Add(nota);
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
