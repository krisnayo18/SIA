using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace ClassLibraryTransaksi
{
    public class Koneksi
    {
        #region DATA MEMBER
        private string namaServer;
        private string namaDatabase;
        private string username;
        private string password;
        private MySqlConnection koneksiDB;
        #endregion

        #region PROPERTIES
        public string NamaServer
        {
            get { return namaServer; }
            set { namaServer = value; }
        }
        public string NamaDatabase
        {
            get { return namaDatabase; }
            set { namaDatabase = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            private get { return password; }
            set { password = value; }
        }
        public MySqlConnection KoneksiDB
        {
            get { return koneksiDB; }
            private set { koneksiDB = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public Koneksi()
        {
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;

            string hasilKonek = Connect();
        }

        public Koneksi(string server, string namaDB, string username, string pass)
        {
            NamaDatabase = namaDB;
            NamaServer = server;
            Username = username;
            Password = pass;
            string strCon = "server=" + NamaServer + "; database=" + NamaDatabase + "; uid=" + Username + "; pwd=" + Password;

            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;

            string hasilConnect = Connect();

            if (hasilConnect == "1")
            {
                UpdateAppConfig(strCon);
            }
        }
        #endregion

        #region METHOD
        public string Connect()
        {
            try
            {
                if (KoneksiDB.State == System.Data.ConnectionState.Open)
                {
                    KoneksiDB.Close();
                }
                KoneksiDB.Open();
                return "1";
            }
            catch (MySqlException e)
            {
                return "Koneksi gagal. Pesan Kesalahan: " + e.Message;
            }
        }

        public void UpdateAppConfig(string connectionString)
        {
            // Buka konfigurasi App.Config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Set App.Config pada nama tag koneksi dengan string koneksi yang dimasukkan pengguna
            config.ConnectionStrings.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString = connectionString;

            // Simpan App.Config yang telah diperbarui
            config.Save(ConfigurationSaveMode.Modified, true);

            // Reload App.Config dengan pengaturan yang baru
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void JalankanPerintahDML(string pSql)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            MySqlCommand c = new MySqlCommand(pSql, k.KoneksiDB);

            c.ExecuteNonQuery();
        }
        public static MySqlDataReader JalankanPerintahQuery(string pSql)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            MySqlCommand c = new MySqlCommand(pSql, k.KoneksiDB);

            MySqlDataReader hasil = c.ExecuteReader();

            return hasil;
        }

        public static string GetNamaServer()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;

            return con.DataSource;
        }

        public static string GetNamaDatabase()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;

            return con.Database;
        }
        #endregion
    }
}
