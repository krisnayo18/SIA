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
        private Pembayaran()
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

            private set
            {
                notaPembelian = value;
            }
        }

        #endregion

        #region Method
        public static string GenerateNoNota(out string pHasilNoPemb)
        {
            //perintah sql = mendapatkan nourut nota terakhir ditanggal hari ini(tanggal komputer)
            string sql = "SELECT SUBSTRING(noPelunasan, 9, 3) AS noUrutPemb " +
                         "FROM pelunasan WHERE Date(tgl) = Date(CURRENT_DATE) " +
                         "ORDER BY noPelunasan DESC LIMIT 1";
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
                sql = "select * from notapembelian where status ='B' ";


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

                    NotaPembelian nota = new NotaPembelian();
                    nota.NoNotaPembelian = nomornota;
                    nota.Status = status;
                    nota.TotalHarga = nominal;

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
