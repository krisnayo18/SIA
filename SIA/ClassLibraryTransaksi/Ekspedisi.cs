using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Ekspedisi
    {
        #region Data Member
        private string idEkspedisi, nama, alamat, noTelepon;
        private int harga;
        #endregion

        #region Constructor
        public Ekspedisi()
        {
            IdEkspedisi = "";
            Nama = "";
            Alamat = "";
            NoTelepon = "";
            Harga = 0;
        }

        public Ekspedisi(string idEkspedisi, string nama, string alamat, string noTelepon, int harga)
        {
            this.idEkspedisi = idEkspedisi;
            this.nama = nama;
            this.alamat = alamat;
            this.noTelepon = noTelepon;
            this.harga = harga;
        }
        #endregion

        #region Properties
        public string IdEkspedisi
        {
            get
            {
                return idEkspedisi;
            }

            set
            {
                idEkspedisi = value;
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

        public string NoTelepon
        {
            get
            {
                return noTelepon;
            }

            set
            {
                noTelepon = value;
            }
        }

        public int Harga
        {
            get
            {
                return harga;
            }

            set
            {
                harga = value;
            }
        }

        #endregion

        #region Method
        public static string BacaData(string kriteria, string nilaiKriteria, List<Ekspedisi> listHasilData)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * from ekspedisi";
            }
            else
            {
                sql = "SELECT * from ekspedisi WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                listHasilData.Clear();

                while (hasilData.Read() == true)
                {
                    Ekspedisi eks = new Ekspedisi();
                    eks.IdEkspedisi = hasilData.GetValue(0).ToString();
                    eks.Nama = hasilData.GetValue(1).ToString();
                    eks.Alamat = hasilData.GetValue(2).ToString();
                    eks.noTelepon = hasilData.GetValue(3).ToString();
                    eks.Harga = int.Parse(hasilData.GetValue(4).ToString());
                   
                    listHasilData.Add(eks);
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
