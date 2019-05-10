using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ClassLibraryJurnal
{
    public class Jurnal
    {
        #region Data Member
        private String idJurnal, keterangan, nomorBukti, jenis;
        private DateTime tanggal;
        private Periode periode;
        private Transaksi transaksi;
        private List<DetilJurnal> listDetilJurnal;

        #endregion

        #region Constructor

        public Jurnal(string idJurnal, string keterangan, string nomorBukti, string jenis, DateTime tanggal, Periode periode, Transaksi transaksi)
        {
            this.idJurnal = idJurnal;
            this.keterangan = keterangan;
            this.nomorBukti = nomorBukti;
            this.jenis = jenis;
            this.tanggal = tanggal;
            this.periode = periode;
            this.transaksi = transaksi;
            ListDetilJurnal = new List<DetilJurnal>();
        }
        public Jurnal()
        {
            this.idJurnal = "";
            this.keterangan = "";
            this.nomorBukti = "";
            this.jenis = "";
            this.tanggal = DateTime.Now;
            ListDetilJurnal = new List<DetilJurnal>();
        }
        #endregion

        #region Properties
        public string IdJurnal
        {
            get
            {
                return idJurnal;
            }

            set
            {
                idJurnal = value;
            }
        }

        public string Keterangan
        {
            get
            {
                return keterangan;
            }

            set
            {
                keterangan = value;
            }
        }

        public string NomorBukti
        {
            get
            {
                return nomorBukti;
            }

            set
            {
                nomorBukti = value;
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

        public Transaksi Transaksi
        {
            get
            {
                return transaksi;
            }

            set
            {
                transaksi = value;
            }
        }

        public List<DetilJurnal> ListDetilJurnal
        {
            get
            {
                return listDetilJurnal;
            }

            set
            {
                listDetilJurnal = value;
            }
        }
        #endregion

        #region Method
        public static string TambahData(Jurnal pJurnal)
        {
            //tambah ke jurnal
            string sql = "Insert into _jurnal(idJurnal, tanggal, nomorBukti, jenis, idPeriode, idTransaksi ) values ('" +
                        pJurnal.IdJurnal + "',  ' " +
                        pJurnal.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                        pJurnal.NomorBukti + "', '" +
                        pJurnal.Jenis + "' , '" +
                        pJurnal.Periode.IdPeriode + "' , '" +
                        pJurnal.Transaksi.IdTransaksi + "')";

            
            try
            {
                Koneksi.JalankanPerintahDML(sql);
                //tambah ke detiljurnal
                for(int i =0; i<pJurnal.ListDetilJurnal.Count; i++)
                {
                    string sql2 = "insert into _detilJurnal(idJurnal, nomorAkun," +
                                    " noUrut,debet,kredit)" + "values ('" +
                                    pJurnal.IdJurnal + "', '" +
                                    pJurnal.ListDetilJurnal[i].Akun.Nomor + "'," +
                                    pJurnal.ListDetilJurnal[i].NoUrut + "," +
                                    pJurnal.ListDetilJurnal[i].Debit + "," +
                                    pJurnal.ListDetilJurnal[i].Kredit + ")";
                    Koneksi.JalankanPerintahDML(sql2);

                 }
                
                return "1";
            }
            catch(MySqlException ex)
            {
                return ex.Message;
            }
        }

        public static string GenerateIdJurnal()
        {

            string sql = "select max(idJurnal) from _jurnal ";
            string pHasilIdJurnal = "1";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
        
                if (hasilData.Read() == true) //jika ada data
                {
                    string  idJurnalTerakhir = hasilData.GetValue(0).ToString();
                    if(idJurnalTerakhir != "")
                    pHasilIdJurnal = (int.Parse(idJurnalTerakhir) + 1).ToString();
                }

                return pHasilIdJurnal;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //method unutk menambahk isi listofdetiljurnal
        public void TambahDetilJurnalPenjualanTunai( int pGrandTotal, int pNoUrut, int pTotalHpp)
        {
            Akun akun1 = new Akun();
            akun1.Nomor = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.Nomor = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);

            Akun akun3 = new Akun();
            akun3.Nomor = "51";
            DetilJurnal detil3 = new DetilJurnal(akun3, 3, pTotalHpp, 0);

            ListDetilJurnal.Add(detil3);

            Akun akun4 = new Akun();
            akun4.Nomor = "15";
            DetilJurnal detil4 = new DetilJurnal(akun4, 4, 0, pTotalHpp);

            ListDetilJurnal.Add(detil4);
        }

        //method unutk menambahkan isi listofdetiljurnal
        //liat pada jurnal  nama akun, apakah di tempatkan di debet atau kredit
        public void TambahDetilJurnalPelunasanHutangTunai(int pHutang, int pDiskon)
        {
            Akun akun1 = new Akun();
            akun1.Nomor = "21";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pHutang, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.Nomor = "11";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pHutang-pDiskon);

            ListDetilJurnal.Add(detil2);

            Akun akun3 = new Akun();
            akun3.Nomor = "13";
            DetilJurnal detil3 = new DetilJurnal(akun3, 3, 0, pDiskon);

            ListDetilJurnal.Add(detil3);
        }
        #endregion


    }
}
