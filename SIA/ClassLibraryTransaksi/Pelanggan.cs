using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Pelanggan
    {
        #region Data Member
        private int idPelanggan;
        private string  nama, alamat, telepon;

        #endregion

        #region Constructor
        public Pelanggan()
        {
            IdPelanggan = 0;
            Nama = "";
            Alamat = "";
            Telepon = "";
        }
        public Pelanggan(int idPelanggan, string nama, string alamat, string telepon)
        {
            this.IdPelanggan = idPelanggan;
            this.nama = nama;
            this.alamat = alamat;
            this.telepon = telepon;
        }
        #endregion

        #region Properties
        public string Alamat
        {
            get
            {
                return alamat;
            }

            set
            {
                alamat = value;
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

        public string Telepon
        {
            get
            {
                return telepon;
            }

            set
            {
                telepon = value;
            }
        }

        public int IdPelanggan
        {
            get
            {
                return idPelanggan;
            }

            set
            {
                idPelanggan = value;
            }
        }

        #endregion

        #region Method
        public static string BacaData(string pKriteria, string pNilaiKriteria, List<Pelanggan> listHasilData)
        {
            string sql = "";

            if (pKriteria == "")
            {
                sql = "SELECT * FROM pelanggan";
            }
            else
            {
                sql = "SELECT * FROM pelanggan WHERE " + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true)
                {
                    Pelanggan pelanggan = new Pelanggan((int)hasilData.GetValue(0), hasilData.GetValue(1).ToString(), hasilData.GetValue(2).ToString(), hasilData.GetValue(3).ToString());

                    listHasilData.Add(pelanggan);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }

        public static string TambahData(Pelanggan pg)
        {
            string sql = "INSERT INTO Pelanggan(idPelanggan, nama, alamat, telepon) VALUES ('" + pg.IdPelanggan + "', '" + pg.Nama.Replace("'", "\\'") + "', '" + pg.Alamat + "', '" + pg.Telepon + "')";

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
        public static string UbahData(Pelanggan pg)
        {
            string sql = "UPDATE Pelanggan SET Nama = '" + pg.Nama.Replace("'", "\\'") + "', Alamat= '" + pg.Alamat + "', Telepon= '" + pg.Telepon + "' WHERE idPelanggan = " + pg.IdPelanggan;

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
        public static string HapusData(Pelanggan pg)
        {
            string sql = "DELETE FROM Pelanggan WHERE idPelanggan = " + pg.IdPelanggan;

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

        public static string GenerateCode(out int pHasilKode)
        {
            string sql = "SELECT MAX(idPelanggan) FROM Pelanggan ";
            pHasilKode = 0;

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                if (hasilData.Read() == true)
                {
                    if (hasilData.GetValue(0).ToString() != "")
                    {
                        int kodeTerbaru = int.Parse(hasilData.GetValue(0).ToString()) + 1;

                        pHasilKode = kodeTerbaru;
                    }
                    else
                    {
                        pHasilKode = 1;
                    }
                }
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
