using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class Karyawan
    {
        #region Data Member
        private string idKaryawan, nama, gender, alamat, noTelepon;
        private int gaji;
        #endregion

        #region Constructor
        public Karyawan()
        {
            IdKaryawan = "";
            Nama = "";
            Gender = "";
            Alamat = "";
            NoTelepon = "";
            Gaji = 0;
        }
        public Karyawan(string idKaryawan, string nama, string gender, string alamat, string noTelepon, int gaji)
        {
            IdKaryawan = idKaryawan;
            Nama = nama;
            Gender = gender;
            Alamat = alamat;
            NoTelepon = noTelepon;
            Gaji = gaji;
        }
        #endregion

        #region Properties
        public string IdKaryawan
        {
            get
            {
                return idKaryawan;
            }

            set
            {
                idKaryawan = value;
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

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
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

        public int Gaji
        {
            get
            {
                return gaji;
            }

            set
            {
                gaji = value;
            }
        }

        #endregion

        #region METHODS
        public static string BuatUserBaru(Karyawan pKaryawan, string pNamaServer)
        {
            string sql = "CREATE USER '" + pKaryawan.Nama + "'@'" + pNamaServer + "' IDENTIFIED BY 's4'";

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

        public static string BeriHakAkses(Karyawan pKaryawan, string pNamaServer, string pNamaDatabase)
        {
            string sql = "GRANT ALL PRIVILEGES ON " + pNamaDatabase + ".* TO '" + pKaryawan.Nama + "'@'" + pNamaServer + "'" + " WITH GRANT OPTION";

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

        public static string UbahPasswordUser(Karyawan pKaryawan, string pNamaServer)
        {
            string sql = "UPDATE mysql.user SET Password = PASSWORD('s4') WHERE USER = '" + pKaryawan.Nama + "' AND Host = '" + pNamaServer + "'";


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

        public static string HapusUser(Karyawan pKaryawan, string pNamaServer)
        {
            string sql = "DROP USER '" + pKaryawan.Nama + "'@'" + pNamaServer + "'";

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

        public static string TambahData(Karyawan pKaryawan)
        {
            string sql = "INSERT INTO Karyawan (idKaryawan, nama, gender, alamat, noTelepon, gaji) VALUES ('" + pKaryawan.IdKaryawan + "', '" + pKaryawan.Nama.Replace("'", "\\") + "', '" + pKaryawan.Gender + "', '" + pKaryawan.Alamat + "', " + pKaryawan.NoTelepon + ", '" + pKaryawan.Gaji + "')";

            try
            {
                Koneksi.JalankanPerintahDML(sql);

                string namaServer = Koneksi.GetNamaServer();
                string namaDatabase = Koneksi.GetNamaDatabase();

                string hasilBuatUser = Karyawan.BuatUserBaru(pKaryawan, namaServer);

                if (hasilBuatUser != "1")
                {
                    return "Gagal membuat user baru. Pesan kesalahan: " + hasilBuatUser;
                }
                else
                {
                    string hasilHakAkses = Karyawan.BeriHakAkses(pKaryawan, namaServer, namaDatabase);

                    if (hasilHakAkses != "1")
                    {
                        return "Gagal memberikan hak akses user baru. Pesan kesalahan: " + hasilHakAkses;
                    }
                    else
                    {
                        return "1";
                    }
                }
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }
        public static string UbahData(Karyawan pKaryawan)
        {
            string sql = "UPDATE Karyawan SET Nama = '" + pKaryawan.Nama + "', gender='" + pKaryawan.Gender + "', alamat='" + pKaryawan.Alamat + "', noTelepon=" + pKaryawan.NoTelepon + ", gaji='" + pKaryawan.Gaji + "' WHERE idPegawai ='" + pKaryawan.IdKaryawan + "'";

            try
            {
                Koneksi.JalankanPerintahDML(sql);

                string namaServer = Koneksi.GetNamaServer();
                string hasilUbahUser = Karyawan.UbahPasswordUser(pKaryawan, namaServer);

                if (hasilUbahUser != "1")
                {
                    return "Gagal merubah password baru. Pesan kesalahan: " + hasilUbahUser;
                }
                else
                {
                    return "1";
                }
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql: " + sql;
            }
        }
        public static string HapusData(Karyawan pKaryawan)
        {
            string sql = "DELETE FROM Karyawan WHERE idPegawai = '" + pKaryawan.IdKaryawan + "'";

            try
            {
                Koneksi.JalankanPerintahDML(sql);

                string namaServer = Koneksi.GetNamaServer();
                string hasilDropUser = Karyawan.HapusUser(pKaryawan, namaServer);

                if (hasilDropUser != "1")
                {
                    return "Gagal menghapus akun user. Pesan kesalahan: " + hasilDropUser;
                }
                else
                {
                    return "1";
                }
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql: " + sql;
            }
        }

        public static string BacaData(string kriteria, string nilaiKriteria, List<Karyawan> listHasilData)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * from karyawan";
            }
            else
            {
                sql = "SELECT * from karyawan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                listHasilData.Clear();

                while (hasilData.Read() == true)
                {
                    Karyawan kr = new Karyawan();
                    kr.IdKaryawan = hasilData.GetValue(0).ToString();
                    kr.Nama = hasilData.GetValue(1).ToString();
                    kr.Gender = hasilData.GetValue(1).ToString();
                    kr.Alamat = hasilData.GetValue(3).ToString();
                    kr.NoTelepon = hasilData.GetValue(4).ToString();
                    kr.Gaji = int.Parse(hasilData.GetValue(5).ToString());

                    listHasilData.Add(kr);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message + ". Perintah sql : " + sql;
            }
        }
        public static string GenerateCode(out int pHasilKode)
        {
            string sql = "SELECT MAX(idKaryawan) FROM karyawan ";
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
