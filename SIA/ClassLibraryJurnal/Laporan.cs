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
                    laporan.Judul = hasilData.GetValue(1).ToString();

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData.GetValue(2).ToString();

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
            int totalpend = int.Parse(HitungTotalPendapatan());
            int totalBiaya = int.Parse(HitungTotalBiaya());
            int labaRugi = totalpend - totalBiaya;
            return labaRugi;
        }
        public static string HitungTotalBiaya()
        {
            string totalBiaya = "";
            string sql = " SELECT SUM(SaldoAkhir) AS TotalBiaya FROM vsaldoakhir WHERE kelompok = 'B' ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalBiaya = hasilData.GetValue(0).ToString();
                }
                return totalBiaya;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
        public static string HitungTotalPendapatan()
        {
            string totalPendapatan = "";
            string sql = " SELECT SUM(SaldoAkhir) AS TotalPendapatan FROM vsaldoakhir WHERE kelompok = 'P' ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalPendapatan = hasilData.GetValue(0).ToString();
                }
                return totalPendapatan;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
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
                    laporan.Judul = hasilData.GetValue(1).ToString();

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData.GetValue(2).ToString();

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
        public static string BacaDataEkuitas(string pKriteria, string pNilaiKriteria, List<Laporan> listLaporan)
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
                    laporan.Judul = hasilData.GetValue(1).ToString();

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData.GetValue(2).ToString();

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
                sql = "SELECT * FROM vsaldoakhir WHERE kelompok IN ('ASET', 'KEWAJIBAN', 'EKUITAS')";
            }
            else
            {
                sql = "SELECT * FROM vsaldoakhir WHERE kelompok IN ('ASET', 'KEWAJIBAN', 'EKUITAS') and "
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
                    laporan.Judul = hasilData.GetValue(1).ToString();

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData.GetValue(2).ToString();

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

        public static string HitungTotalAktiva()
        {
            string totalAktiva = "";
            string sql = " SELECT SUM(SaldoAkhir) AS TotalAktiva FROM vsaldoakhir WHERE kelompok = 'ASET' ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalAktiva =hasilData.GetValue(0).ToString();
                }
                return totalAktiva;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        public static string HitungTotalPasiva()
        {
            string totalPasiva = "";
            string sql = " SELECT SUM(SaldoAkhir) + " + HitungLabaRugi() + "  AS TotalAktiva FROM vsaldoakhir WHERE kelompok IN('KEWAJIBAN', 'EKUITAS') ";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                while (hasilData.Read() == true)
                {
                    totalPasiva = hasilData.GetValue(0).ToString();
                }
                return totalPasiva;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}
