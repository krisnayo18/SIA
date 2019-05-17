using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class Pelunasan
    {


        #region Data Member
        private string caraPembayaran, noPelunasan;
        private NotaPenjualan notaPenjualan;
        private DateTime tanggal;
        private int nominal;
        #endregion

        #region Constructor
        public Pelunasan( string noPelunasan, NotaPenjualan notaPenjualan,  DateTime tanggal, string caraPembayaran, int nominal)
        {
            this.caraPembayaran = caraPembayaran;
            this.noPelunasan = noPelunasan;
            this.notaPenjualan = notaPenjualan;
            this.tanggal = tanggal;
            this.nominal = nominal;
        }
        public Pelunasan()
        {
            this.caraPembayaran = "";
            this.noPelunasan = "" ;
            this.tanggal = DateTime.Now;
            this.nominal = 0;
        }
        #endregion

        #region Properties
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

        public string NoPelunasan
        {
            get
            {
                return noPelunasan;
            }

            set
            {
                noPelunasan = value;
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

        #endregion

        #region Method
        public static string TambahData(Pelunasan pPelunasan, NotaPenjualan pNota)
        {
            //sql1 untuk menambahkan data ke tabel pelunasan
            string sql = "Insert into pelunasan(noPelunasan, tgl, caraPembayaran, nominal, noNotaPenjualan) values ('" +
                        pPelunasan.noPelunasan + "',  '" +
                        pPelunasan.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                        pPelunasan.CaraPembayaran + "'," +
                        pPelunasan.Nominal + ", '" +
                        pPelunasan.NotaPenjualan.NoNotaPenjualan + "')";
            try
            {
                //jalankan perintah sql untuk menambahkan ke tabel 
                Koneksi.JalankanPerintahDML(sql);

                //sql2 untuk mengubah status notapenjualan yang belum lunas atau P menjadi L
                string sql2 = "UPDATE notapenjualan SET  status ='" +
                       pNota.Status + "' WHERE  noNotaPenjualan = '" +
                    pNota.NoNotaPenjualan + "'";

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
        public static string BacaData(string pKriteria, string pNilaiKriteria, List<Pelunasan> listHasilData)
        {
            string sql = "";

            if (pKriteria == "")
            {
                sql = "SELECT P.noPelunasan, NP.noNotaPenjualan, P.tgl, P.caraPembayaran, P.nominal,  NP.status , NP.totalHarga FROM "
                    + " notaPenjualan NP  inner join pelunasan P  where NP.status = 'P'" ; 


            }
            else
            {
                sql = "SELECT P.noPelunasan, NP.noNotaPenjualan, P.tgl, P.caraPembayaran, P.nominal,  NP.status , NP.totalHarga FROM "
                    + "notaPenjualan NP  inner join pelunasan P  where NP.status = 'P' and "
                      + pKriteria + " LIKE '%" + 
                       pNilaiKriteria + "%'";
                
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true)
                {

                    string noPelunasan = hasilData.GetValue(0).ToString();
                    DateTime tanggal = DateTime.Parse(hasilData.GetValue(2).ToString());
                    string caraPemb = hasilData.GetValue(3).ToString();
                    int nominal = int.Parse(hasilData.GetValue(4).ToString());
                        
                    NotaPenjualan NP = new NotaPenjualan();
                    NP.NoNotaPenjualan = hasilData.GetValue(1).ToString();
                    NP.Status = hasilData.GetValue(5).ToString();
                    NP.TotalHarga =int.Parse(hasilData.GetValue(6).ToString());

                    Pelunasan pelunasan = new Pelunasan(noPelunasan, NP, tanggal, caraPemb, nominal);
                
                    listHasilData.Add(pelunasan);
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
        #endregion
    }
}
