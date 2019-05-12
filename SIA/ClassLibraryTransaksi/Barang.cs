using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public class Barang
    {
        #region Data Member
        private string kodeBarang, nama, jenis, satuan;
        private int quantity, hargaBeliTerbaru, hargaJual;
        #endregion

        #region Constructor
        public Barang(string kodeBarang, string nama, string jenis, string satuan, int quantity, int hargaBeliTerbaru, int hargaJual)
        {
            this.kodeBarang = kodeBarang;
            this.nama = nama;
            this.jenis = jenis;
            this.satuan = satuan;
            this.quantity = quantity;
            this.hargaBeliTerbaru = hargaBeliTerbaru;
            this.hargaJual = hargaJual;
        }
        public Barang()
        {
            this.kodeBarang = "";
            this.nama = "";
            this.jenis = "";
            this.satuan = "";
            this.quantity = 0;
            this.hargaBeliTerbaru = 0;
            this.hargaJual = 0;
        }


        #endregion

        #region Properties
        public int HargaBeliTerbaru
        {
            get
            {
                return hargaBeliTerbaru;
            }

            set
            {
                hargaBeliTerbaru = value;
            }
        }

        public int HargaJual
        {
            get
            {
                return hargaJual;
            }

            set
            {
                hargaJual = value;
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

        public string KodeBarang
        {
            get
            {
                return kodeBarang;
            }

            set
            {
                kodeBarang = value;
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

        public string Satuan
        {
            get
            {
                return satuan;
            }

            set
            {
                satuan = value;
            }
        }

        #endregion

        #region Method
        public static string TambahData(Barang bar)
        {
            string sql = "INSERT INTO barang (kodeBarang, Nama, quantity, jenis, hargaBeliTerbaru, HargaJual, satuan ) VALUES ('" +
                         bar.KodeBarang + "', '" + 
                         bar.Nama.Replace("'", "\\") /*untuk dapat menambahkan tanda "'" ke data base*/ + "', '" +
                         bar.Quantity + "', '" +
                         bar.Jenis + "', '" +
                         bar.HargaBeliTerbaru + "', '" +
                         bar.HargaJual + "','" +
                         bar.Satuan + "')";

            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }
        public static string UbahData(Barang bar)
        {
            string sql = "UPDATE barang SET Nama= '" +
                        bar.Nama + "', jenis= '" + 
                        bar.Jenis + "', hargaBeliTerbaru =" +
                        bar.HargaBeliTerbaru +", HargaJual= " +
                        bar.HargaJual + "', satuan='" +
                        bar.Satuan + "' WHERE KodeBarang = '" +
                        bar.KodeBarang + "'";

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
        public static string HapusData(Barang bar)
        {
            string sql = "DELETE FROM barang WHERE KodeBarang = '" + bar.KodeBarang + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Barang> listHasilData)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * from barang";
            }
            else
            {
                sql = "SELECT * from barang WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                listHasilData.Clear();

                while (hasilData.Read() == true)
                {
                    Barang br = new Barang();
                    br.KodeBarang = hasilData.GetValue(0).ToString();
                    br.Nama = hasilData.GetValue(1).ToString();
                    br.Quantity = int.Parse(hasilData.GetValue(2).ToString());
                    br.Jenis = hasilData.GetValue(3).ToString();
                    br.HargaBeliTerbaru = int.Parse(hasilData.GetValue(4).ToString());
                    br.HargaJual = int.Parse(hasilData.GetValue(5).ToString());
                    br.Satuan = hasilData.GetValue(6).ToString();

                    listHasilData.Add(br);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }
        public static string GenerateCode(out string pHasilKode)
        {
            string sql = "SELECT MAX(RIGHT(KodeBarang, 3)) FROM barang" ;
            pHasilKode = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                if (hasilData.Read() == true)
                {
                    if (hasilData.GetValue(0).ToString() != "")
                    {
                        int kodeTerbaru = int.Parse(hasilData.GetValue(0).ToString()) + 1;

                        pHasilKode = kodeTerbaru.ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        pHasilKode = "001";
                    }
                }
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string UbahStokTerjual(string pKodeBarang, int pJumlahTerjual)
        {
            //perintah sql = untuk mengurangi quantity/stok barang yang sudah terjual
            string sql = "UPDATE barang SET quantity = quantity - " + pJumlahTerjual + " WHERE kodeBarang='" + pKodeBarang + "'";

            try
            {
                Koneksi.JalankanPerintahDML(sql);

                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string UbahStokBeli(string pKodeBarang, int pJumlahBeli)
        {
            string sql = "UPDATE Barang SET quantity = quantity + " + pJumlahBeli + " WHERE KodeBarang='" + pKodeBarang + "'";

            try
            {
                Koneksi.JalankanPerintahDML(sql);

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
