using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
   public class Laporan
    {
        #region Data Member
        private string idLaporan, judul;
        private Periode periode;
        private List<LaporanAkun> listLaporanAkun;
        #endregion

        #region Constructor
        public Laporan(string idLaporan, string judul, Periode periode)
        {
            this.idLaporan = idLaporan;
            this.judul = judul;
            this.periode = periode;
            ListLaporanAkun = new List<LaporanAkun>();
        }
        public Laporan()
        {
            IdLaporan = "";
            Judul = "";
            ListLaporanAkun = new List<LaporanAkun>();
        }
        #endregion

        #region Properties
        public string IdLaporan
        {
            get
            {
                return idLaporan;
            }

            set
            {
                idLaporan = value;
            }
        }

        public string Judul
        {
            get
            {
                return judul;
            }

            set
            {
                judul = value;
            }
        }

        public Periode Periode
        {
            get
            {
                return periode;
            }

            set
            {
                periode = value;
            }
        }

        public List<LaporanAkun> ListLaporanAkun
        {
            get
            {
                return listLaporanAkun;
            }

            set
            {
                listLaporanAkun = value;
            }
        }



        #endregion

        #region Method

        //Laporan saldo akhir Buku Besar
        public static string BacaDataBukuBesar(string pKriteria, string pNilaiKriteria, List<Laporan> listLaporan)
        {
            string sql = "";

            if (pKriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel notapenjualan 
                sql = "select * from vsaldoakhir";
            }
            else
            {
                sql = " select * from vsaldoakhir WHERE "
                        + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }
            try
            {
                //data reader 1 = memperoleh semua data di tabel jurnal
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listLaporan.Clear();//kosongi isi list terlebih dahulu
                while (hasilData.Read() == true)
                {
                    //buat object laporan
                    Laporan laporan = new Laporan();
                    //simpan data  kelompok di idlaporan  
                    laporan.IdLaporan = hasilData.GetValue(0).ToString();
                    laporan.Judul = hasilData.GetValue(2).ToString();
                    

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData.GetValue(3).ToString();

                    //tambahkan ke list
                    laporan.Periode = period;
                    listLaporan.Add(laporan);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        //Laporan Laba Rugi
        public static int HitungLabaRugi()
        {
            int totalpend = HitungTotalPendapatan();
            int totalBiaya = HitungTotalBiaya();
            int labaRugi = totalpend - totalBiaya;
            return labaRugi;
        }
        public static int HitungTotalBiaya()
        {
            int totalBiaya = 0;
            string sql = " SELECT SUM(SaldoAkhir) AS TotalBiaya FROM vsaldoakhir WHERE kelompok = 'B' ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalBiaya =int.Parse( hasilData.GetValue(0).ToString());
                }
                return totalBiaya;
            }
            catch (MySqlException ex)
            {
                return int.Parse(ex.Message);
            }
        }
        public static int HitungTotalPendapatan()
        {
            int totalPendapatan = 0;
            string sql = " SELECT SUM(SaldoAkhir) AS TotalPendapatan FROM vsaldoakhir WHERE kelompok = 'P' ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalPendapatan = int.Parse(hasilData.GetValue(0).ToString());
                }
                return totalPendapatan;
            }
            catch (MySqlException ex)
            {
                return int.Parse(ex.Message);
            }
        }

        public static string BacaDataLabaRugi(string pKriteria, string pNilaiKriteria, List<Laporan> listLaporan)
        {
            string sql = "";

            if (pKriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel notapenjualan 
                sql = "SELECT * FROM vsaldoakhir WHERE kelompok IN('P', 'B')";
            }
            else
            {
                sql = " SELECT * FROM vsaldoakhir WHERE kelompok IN('P', 'B') and  "
                        + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }
            try
            {
                //data reader 1 = memperoleh semua data di tabel jurnal
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listLaporan.Clear();//kosongi isi list terlebih dahulu
                while (hasilData.Read() == true)
                {
                    //buat object laporan
                    Laporan laporan = new Laporan();
                    //simpan data  kelompok di idlaporan  
                    laporan.IdLaporan = hasilData.GetValue(0).ToString();
                    //simpan nama akun di judul
                    laporan.Judul = hasilData.GetValue(2).ToString();

                    Periode period = new Periode();
                    //tambahkan saldoakhir pada idperiode ( saldo akhir pada index ke 2)
                    period.IdPeriode = hasilData.GetValue(3).ToString();

                    //tambahkan ke list
                    laporan.Periode = period;
                    listLaporan.Add(laporan);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        //Laporan Ekuitas
        public static int HitungEkuitasAkhir()
        {
            //hasil query prive (jika ada, di project prive= 0)
            int prive = 0;
            int ekuitasAkhir = TampilkanModalAwal() + HitungLabaRugi() - prive;
            return ekuitasAkhir;
        }
        public static int TampilkanModalAwal()
        {
            int modalAwal = 0;
            string sql = " SELECT saldoAwal FROM _periodeakun WHERE nomor = '31'";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    modalAwal =int.Parse( hasilData.GetValue(0).ToString());
                }
                return modalAwal;
            }
            catch (MySqlException ex)
            {
                return int.Parse(ex.Message);
            }
        }

        public static string BacaDataEkuitas(string pKriteria, string pNilaiKriteria, List<Laporan> listLaporan)
        {
            string sql = "";

            if (pKriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel notapenjualan 
                sql = "SELECT * FROM vsaldoakhir WHERE kelompok = 'E' ";
            }
            else
            {
                sql = " SELECT * FROM vsaldoakhir WHERE kelompok = 'E' and "
                        + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }
            try
            {
                //data reader 1 = memperoleh semua data di tabel jurnal
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listLaporan.Clear();//kosongi isi list terlebih dahulu
                while (hasilData.Read() == true)
                {
                    //buat object laporan
                    Laporan laporan = new Laporan();
                    //simpan data  kelompok di idlaporan  
                    laporan.IdLaporan = hasilData.GetValue(0).ToString();
                    //simpan nama akun di judul
                    laporan.Judul = hasilData.GetValue(2).ToString();

                    Periode period = new Periode();
                    //tambahkan saldoakhir pada idperiode ( saldo akhir pada index ke 2)
                    period.IdPeriode = hasilData.GetValue(3).ToString();

                    //tambahkan ke list
                    laporan.Periode = period;
                    listLaporan.Add(laporan);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }


        //Laporan Neraca
        public static string BacaDataNeraca(string pKriteria, string pNilaiKriteria, List<Laporan> listLaporan)
        {
            string sql = "";

            if (pKriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel notapenjualan 
                sql = "SELECT * FROM vsaldoakhir WHERE kelompok IN ('A', 'K', 'E')";
            }
            else
            {
                sql = "SELECT * FROM vsaldoakhir WHERE kelompok IN ('A', 'K', 'E') and "
                        + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }
            try
            {
                //data reader 1 = memperoleh semua data di tabel jurnal
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listLaporan.Clear();//kosongi isi list terlebih dahulu
                while (hasilData.Read() == true)
                {
                    //buat object laporan
                    Laporan laporan = new Laporan();
                    //simpan data  kelompok di idlaporan  
                    laporan.IdLaporan = hasilData.GetValue(0).ToString();
                    laporan.Judul = hasilData.GetValue(2).ToString();

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData.GetValue(3).ToString();

                    //tambahkan ke list
                    laporan.Periode = period;
                    listLaporan.Add(laporan);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        public static int HitungTotalAktiva()
        {
            int totalAktiva = 0;
            string sql = " SELECT SUM(SaldoAkhir) AS TotalAktiva FROM vsaldoakhir WHERE kelompok = 'A' ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalAktiva = int.Parse(hasilData.GetValue(0).ToString());
                }
                return totalAktiva;
            }
            catch (MySqlException ex)
            {
                return int.Parse(ex.Message);
            }
        }

        public static int HitungTotalPasiva()
        {
            int totalPasiva = 0;
            string sql = " SELECT SUM(SaldoAkhir) + " + HitungLabaRugi() + "  AS TotalPasiva FROM vsaldoakhir WHERE kelompok IN('K', 'E') ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalPasiva =int.Parse( hasilData.GetValue(0).ToString());
                }
                return totalPasiva;
            }
            catch (MySqlException ex)
            {
                return int.Parse(ex.Message);
            }
        }

        public static int tampilHutang()
        {
            int hutang = 0;
            string sql = "SELECT saldoakhir FROM vsaldoakhir WHERE nama = 'hutang'";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    hutang = int.Parse(hasilData.GetValue(0).ToString());
                }
                return hutang;
            }catch(MySqlException ex)
            {
                return int.Parse(ex.Message);
            }
        }

        #endregion
    }
}
