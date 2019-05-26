using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    public class Periode
    {
        #region Data Member
        private string idPeriode;
        private DateTime tglAwal, tglAkhir;
        private List<PeriodeAkun> listPeriodeAkun;

        public Periode(string idPeriode, DateTime tglAwal, DateTime tglAkhir)
        {
            this.idPeriode = idPeriode;
            this.tglAwal = tglAwal;
            this.tglAkhir = tglAkhir;
            listPeriodeAkun = new List<PeriodeAkun>();
        }
        public Periode()
        {
            this.idPeriode = "";
            this.tglAwal = DateTime.Now;
            this.tglAkhir = DateTime.Now;
            listPeriodeAkun = new List<PeriodeAkun>();
        }
        #endregion

        #region Properties
        public string IdPeriode
        {
            get
            {
                return idPeriode;
            }

            set
            {
                idPeriode = value;
            }
        }

        public DateTime TglAwal
        {
            get
            {
                return tglAwal;
            }

            set
            {
                tglAwal = value;
            }
        }

        public DateTime TglAkhir
        {
            get
            {
                return tglAkhir;
            }

            set
            {
                tglAkhir = value;
            }
        }

        internal List<PeriodeAkun> ListPeriodeAkun
        {
            get
            {
                return listPeriodeAkun;
            }

            set
            {
                listPeriodeAkun = value;
            }
        }

        #endregion

        #region Method
        public static Periode GetPeriodeTerbaru()
        {
            //ambil data dari periode
            string sql = "select * from _periode where idPeriode = (select max(idPeriode) from _periode)";


            MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

            Periode hasilPeriode = null;
            if (hasilData.Read() == true) //jika ada data
            {
                string idPeriode = hasilData.GetValue(0).ToString();
                DateTime tglAwal = DateTime.Parse(hasilData.GetValue(1).ToString());
                DateTime tglAkhir = DateTime.Parse(hasilData.GetValue(2).ToString());
                hasilPeriode = new Periode(idPeriode, tglAwal, tglAkhir);
            }
            return hasilPeriode;


        }

        #region Tutup Periode Akuntansi
        //Langkah-langkah tutup periode akuntansi

        //1. update saldoakhir di tabel periode akun
        //check apakah saldoakhir sesuai dengan bukubesar
        public static string UpdateSaldoAkhir()
        {
            string sql = "UPDATE _periodeakun pa set pa.saldoAkhir = (select v.SaldoAkhir from vsaldoakhir v where v.nomor = pa.nomor)";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //2. Posting jurnal penutup
        #region Jurnal Penutup
        public static string JurnalPenutup()
        {
            string status = "";
            try
            {
                status = PenutupanPendapatan();
                if (status == "1")
                {
                    status = PenutupanBiaya();
                    if(status == "1")
                    {
                        status = PenutupanModalDanLR();
                        //jika ada penutupan modal dan prive buat method dan tambahkan dibawah
                    }
                }
                return status;
            }
            catch (MySqlException x)
            {
                return x.Message;
            }

        }
        //2.1 Penutupan pendapatan
        #region Penutupan Pendapatan
        //Tambahkan di tabel transaksi dengan  idtransaksi = 901 dan keterangan = penutupan pendapatan
        public static string PenutupanPendapatan()
        {
            string status = ""; 
            string periodeterbaru = GetPeriodeTerbaru().IdPeriode;
            string idjurnalterbaru = Jurnal.GenerateIdJurnal();
            try
            {
                status = InsertJurnalPP(idjurnalterbaru, periodeterbaru);
                if (status == "1") // jika berhasil insert ke jurnal
                {
                    status = InsertDJKreditPP(idjurnalterbaru);
                    if (status == "1") // jika insert ke detiljurnal berhasil
                    {
                        status = InsertDJDebetPP(idjurnalterbaru);
                        if (status == "1") // jika insert ke detiljurnal berhasil
                        {
                            // status hasil dari insert ihtisar apabila berhasil 
                            //status =1, jika gagal = mysqlexception
                            status = IhtisarLabaRugiPP(idjurnalterbaru);
                        }
                        else //jika gagal
                        {
                            status = "gagal insert ke detil jurnal yang debit";
                        }
                    }
                    else //jika tidak 
                    {
                        status = "gagal insert ke detil jurnal yang kredit";
                    }
                }
                else // jika gagal
                {
                    status = "gagal insert ke jurnal";
                }
                return status;
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        //2.1.1 insert ke tabel jurnal 
        public static string InsertJurnalPP(string pIdJurnal, string pidPeriode)
        {
            string sql = "insert into _jurnal (idjurnal, tanggal, nomorbukti, jenis, idperiode, idtransaksi) values " +
              "('" + pIdJurnal + "',current_date(),'-', 'JT', '" + pidPeriode + "','901')";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //2.1.2 insert ke tabel detiljurnal
        //2.1.2.1 Insert semua pendapatan yg saldo normalnya di sisi kredit
        public static string InsertDJKreditPP(string pIdJurnal)
        {
            string sql = "INSERT INTO _detiljurnal(idJurnal, nomor, noUrut, debet, kredit) " +
                      "SELECT '" + pIdJurnal + "', V.nomor, 1, V.SaldoAkhir, 0 FROM vsaldoakhir V INNER JOIN _akun A " +
                      "ON V.nomor = A.nomor WHERE V.kelompok = 'P' AND A.saldoNormal = -1";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        //2.1.2.1 Insert semua pendapatan yg saldo normalnya di sisi debet
        public static string InsertDJDebetPP(string pIdJurnal)
        {
            string sql = "INSERT INTO _detiljurnal(idJurnal, nomor, noUrut, debet, kredit)" +
                        "SELECT '" + pIdJurnal+ "', V.nomor, 1, 0, V.SaldoAkhir FROM vsaldoakhir V INNER JOIN _akun A " +
                        "ON V.nomor = A.nomor WHERE V.kelompok = 'P' AND A.saldoNormal = 1";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //2.1.2.1 Insert ihtisar laba rugi
        //Tambahkan dulu nama akun Ihtisar Laba Rugi di tabel _akun
        public static string IhtisarLabaRugiPP(string pIdJurnal)
        {

            //Tambahkan dulu akun Ihtisar Laba Rugi di tabel _akun
            int totalpend = Laporan.HitungTotalPendapatan();
            string sql = "INSERT INTO _detiljurnal(idJurnal, nomor, noUrut, debet, kredit)" +
                         "VALUES('" + pIdJurnal + "', '00', 2, 0, " + totalpend + ")"; 
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        #endregion

        //2.2 Penutupan Biaya
        #region Penutupan Biaya
        //Tambahkan di tabel transaksi dengan  idtransaksi = 902 dan keterangan = penutupan Biaya
        public static string PenutupanBiaya()
        {
            string status = "";
            string periodeterbaru = GetPeriodeTerbaru().IdPeriode;
            string idjurnalterbaru = Jurnal.GenerateIdJurnal();
            try
            {
                status = InsertJurnalPB(idjurnalterbaru, periodeterbaru);
                if (status == "1") // jika berhasil insert ke jurnal
                {
                    status = IhtisarLabaRugiPB(idjurnalterbaru); 
                    if (status == "1") //  apabila berhasil  insert ihtisar laba rugi
                    {
                        // status hasil dari insert semua akun biaya ke detiljurnal apabila berhasil 
                        //status =1, jika gagal = mysqlexception
                        status = InsertDJBiaya(idjurnalterbaru);
                    }
                    else //jika gagal insert ihtisar
                    {
                        status = "gagal insert ke detil jurnal ihtisar laba rugi";
                    }
                }
                else // jika gagal
                {
                    status = "gagal insert ke jurnal";
                }
                return status;
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        //2.2.1 Insert ke tabel _jurnal
        public static string InsertJurnalPB(string pIdJurnal, string pidPeriode)
        {
            string sql = "insert into _jurnal (idjurnal, tanggal, nomorbukti, jenis, idperiode, idtransaksi) values " +
              "('" + pIdJurnal + "',current_date(),'-', 'JT', '" + pidPeriode + "','902')";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //2.2.2 Insert ke tabel _detiljurnal
        //2.2.2.1 Insert ihtisar laba rugi
        //check dulu nama  akun  Ihtisar Laba Rugi di tabel _akun apakah ada, jika tidak ada tambahkan
        public static string IhtisarLabaRugiPB(string pIdJurnal)
        {
            int totalBiaya = Laporan.HitungTotalBiaya();
            string sql = "INSERT INTO _detiljurnal(idJurnal, nomor, noUrut, debet, kredit)" +
                         "VALUES('" + pIdJurnal + "', '00', 1, " + totalBiaya + ", 0)";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        //2.2.2.2 Insert semua akun biaya ke detiljurnal
        public static string InsertDJBiaya(string pIdJurnal)
        {
            int totalBiaya = Laporan.HitungTotalBiaya();
            string sql = "INSERT INTO _detiljurnal(idJurnal,nomor,noUrut,debet,kredit) " +
                         "SELECT '" + pIdJurnal + "', V.nomor, 2, 0, V.SaldoAkhir FROM vsaldoakhir V " +
                         "INNER JOIN _akun A ON V.nomor = A.nomor WHERE V.kelompok = 'B'";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        #endregion

        //2.3 Penutupan modal dan laba rugi
        #region Penutupan Modal dan Laba Rugi
        //Tambahkan di tabel transaksi dengan  idtransaksi = 903 dan keterangan = penutupan modal dan laba rugi
        public static string PenutupanModalDanLR()
        {
            string status = "";
            string periodeterbaru = GetPeriodeTerbaru().IdPeriode;
            string idjurnalterbaru = Jurnal.GenerateIdJurnal();
            try
            {
                status = InsertJurnalPMLR(idjurnalterbaru, periodeterbaru);
                if (status == "1") // jika berhasil insert ke jurnal
                {
                    status = IhtisarLabaRugiPMLR(idjurnalterbaru);
                    if (status == "1") //  apabila berhasil  insert ihtisar laba rugi PMLR
                    {
                        // status hasil dari insert modal ke detiljurnal apabila berhasil 
                        //status =1, jika gagal = mysqlexception
                        status = InsertModalPMLR(idjurnalterbaru);
                    }
                    else //jika gagal insert ihtisar PMLR
                    {
                        status = "gagal insert ke detil jurnal ihtisar laba rugi ";
                    }
                }
                else // jika gagal
                {
                    status = "gagal insert ke jurnal";
                }
                return status;
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        //2.2.1 Insert ke tabel _jurnal
        public static string InsertJurnalPMLR(string pIdJurnal, string pidPeriode)
        {
            string sql = "insert into _jurnal (idjurnal, tanggal, nomorbukti, jenis, idperiode, idtransaksi) values " +
              "('" + pIdJurnal + "',current_date(),'-', 'JT', '" + pidPeriode + "','903')";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //2.3.2 Insert ke tabel _detiljurnal
        //2.3.2.1 Insert ihtisar laba rugi
        //check dulu nama  akun  Ihtisar Laba Rugi di tabel _akun apakah ada, jika tidak ada tambahkan
        public static string IhtisarLabaRugiPMLR(string pIdJurnal)
        {
            int totalBiaya = Laporan.HitungTotalBiaya();
            int totalpend = Laporan.HitungTotalPendapatan();
            int hasil = totalpend - totalBiaya;
            string sql = "INSERT INTO _detiljurnal(idJurnal, nomor, noUrut, debet, kredit)" +
                         "VALUES('" + pIdJurnal + "', '00', 1, " + hasil + ", 0)";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //2.3.2.2 Insert modal
        public static string InsertModalPMLR(string pIdJurnal)
        {
            int totalBiaya = Laporan.HitungTotalBiaya();
            int totalpend = Laporan.HitungTotalPendapatan();
            int hasil = totalpend - totalBiaya;
            string sql = "INSERT INTO _detiljurnal(idJurnal, nomor, noUrut, debet, kredit)" +
                         "VALUES('" + pIdJurnal + "', '31', 2, 0," + hasil + ")";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }
        #endregion

        //2.4 Penutupan modal dan prive
        // Karena tidak ada akun prive maka step ini tidak perlu dibuat
        #region Penutupan Modal dan prive
        #endregion

        #endregion

        ////3. Tambah/buat periode baru di tabel _periode
        public static string BuatPeriodeBaru()
        {
            int periodeterbaru = int.Parse(GetPeriodeTerbaru().IdPeriode);
            string periodebaru = (periodeterbaru + 1).ToString() ;
            //tgl awal dan tgl akhir sesuaikan dengan data yang ada di database
            //karena periode setiap akhir bulan maka tgl awal = 1 dan tgl akhir = 30/31 (sesuai bulan)
            string sql = "INSERT INTO _periode(idPeriode,tglAwal,tglAkhir)" +
                         "VALUES('" +  periodebaru + "', '2015-03-01', '2015-03-31')";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //4. Tambah/insert akun2 di periode baru tsb di tabel _periodeakun
        public static string InsertAkunBaru()
        {
            string periodeterbaru = GetPeriodeTerbaru().IdPeriode;
            string sql = "INSERT INTO _periodeakun(idperiode,nomor,saldoAwal,saldoAkhir)" +
                         "SELECT '" + periodeterbaru + "', V.nomor, V.SaldoAkhir, 0 " +
                         "FROM vsaldoakhir V";
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException x)
            {
                return x.Message;
            }
        }

        //lakukan 4 langkah diatas secara menggunakan method tutupperiode
        public static string TutupPeriode()
        {
            string status = "";
            try
            {
                status = UpdateSaldoAkhir();
                if(status == "1")
                {
                    status = JurnalPenutup();
                    if(status == "1")
                    {
                        status = BuatPeriodeBaru();
                        if(status == "1")
                        {
                            status = InsertAkunBaru();
                        }
                    }
                }
                else
                {
                    status = "gagal update";
                }
                
                return status;
            }
            catch (MySqlException x)
            {
                return x.Message;
            }

        }
        #endregion

        #endregion

    }
}
