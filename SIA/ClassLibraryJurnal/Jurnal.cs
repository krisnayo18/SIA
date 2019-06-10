using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ClassLibraryJurnal
{
    public class Jurnal
    {
        #region Data Member
        private int idJurnal;
        private string   nomorBukti, jenis;
        private DateTime tanggal;
        private Periode periode;
        private Transaksi transaksi;
        private List<DetilJurnal> listDetilJurnal;


       


        #endregion

        #region Constructor

        public Jurnal(int idJurnal,  string nomorBukti, string jenis, DateTime tanggal, Periode periode, Transaksi transaksi)
        {
            this.idJurnal = idJurnal;
            
            this.nomorBukti = nomorBukti;
            this.jenis = jenis;
            this.tanggal = tanggal;
            this.periode = periode;
            this.transaksi = transaksi;
            ListDetilJurnal = new List<DetilJurnal>();
        }
        public Jurnal()
        {
            this.idJurnal = 0;
            this.nomorBukti = "";
            this.jenis = "";
            this.tanggal = DateTime.Now;
            ListDetilJurnal = new List<DetilJurnal>();
        }
        #endregion

        #region Properties
        public int IdJurnal
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

            private set
            {
                listDetilJurnal = value;
            }
        }
        #endregion

        #region Method
        public void TambahDetilJurnal( Akun pAkun, int pDebet, int pKredit)
        {
            DetilJurnal dj = new DetilJurnal(pAkun, 0, pDebet, pKredit);

            ListDetilJurnal.Add(dj);


        }
        public static string TambahData(Jurnal pJurnal)
        {
            //sql1 untuk menambahkan data ke tabel _jurnal
            string sql = "Insert into _jurnal(idJurnal, tanggal,  nomorBukti,  jenis, idPeriode, idTransaksi ) values ('" +
                        pJurnal.IdJurnal + "',  ' " +
                        pJurnal.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "', '" +
                        
                        pJurnal.NomorBukti + "', '" +
                        pJurnal.Jenis + "' , '" +
                        pJurnal.Periode.IdPeriode + "' , '" +
                        pJurnal.Transaksi.IdTransaksi + "')";            
            try
            {
                //jalankan perintah sql untuk menambahkan ke tabel _jurnal
                Koneksi.JalankanPerintahDML(sql);

                //menambahkan transaksi yang dilakukan di jurnal  ke detiljurnal
                for(int i =0; i<pJurnal.ListDetilJurnal.Count; i++)
                {
                    //sql2 untuk menambahkan ke  tabel detiljurnal
                    string sql2 = "insert into _detilJurnal(idJurnal, nomor," +
                                    " noUrut,debet,kredit)" + "values ('" +
                                    pJurnal.IdJurnal + "', '" +
                                    pJurnal.ListDetilJurnal[i].Akun.NomorAkun + "'," +
                                    pJurnal.ListDetilJurnal[i].NoUrut + "," +
                                    pJurnal.ListDetilJurnal[i].Debit + "," +
                                    pJurnal.ListDetilJurnal[i].Kredit + ")";

                    //jalankan sql2 untuk menambhkan ke detiljurnal
                    Koneksi.JalankanPerintahDML(sql2);
                 }
                //jika semua perintah sql berhasil dijalankan
                return "1";
            }
            catch(MySqlException ex)
            {
                //jika ada kegagalan perintah
                return ex.Message;
            }
        }

        public static string GenerateIdJurnal()
        {
            // perintah sql untuk mengambil angka terbesar di kolom idjurnal
            string sql = "select max(idJurnal) from _jurnal ";

            int pIdJurnalTerbaru = 1;
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
        
                if (hasilData.Read() == true) //jika ada data
                {
                    string  idJurnalTerakhir = hasilData.GetValue(0).ToString(); // mendapatkan idjurnal terakhir di db

                    if(idJurnalTerakhir != "") // jika idjurnal terakhir tidak 0 
                    {
                         pIdJurnalTerbaru = int.Parse(idJurnalTerakhir) + 1;
                    }

                }

                return pIdJurnalTerbaru.ToString();
            }
            catch (MySqlException e)
            {
                return e.Message;
            }
        }

     
        //method untuk menambahkan isi listdetiljurnal
        //ada 9 transaksi sesuai project lihat file project jurnal umum
        //karena ada transaksi yang sama maka cukup buat satu method saja
        //liat pada jurnal  nama akun, apakah di tempatkan di debet atau kredit

        //untuk  membeli bahan baku secara kredit T0001 dan T0002
        public void TambahDetilJurnalPembelianBarangKredit(int pGrandTotal)
        {
            //akun untuk sediaan bertambah
            Akun akun1 = new Akun();
            akun1.NomorAkun = "13";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            //akun untuk hutang bertambah 
            Akun akun2 = new Akun();
            akun2.NomorAkun = "21";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);
        }
        //untuk pembelian secara tunai
        public void TambahDetilJurnalPembelianBarangTunai(int pGrandTotal)
        {
            //akun untuk sediaan bertambah              
            Akun akun1 = new Akun();
            akun1.NomorAkun = "13";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            //akun untuk kas berkurang     
            Akun akun2 = new Akun();
            akun2.NomorAkun = "11";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);
        }
        //untuk  menerima bahan baku dari gudang T0004
        public void TambahDetilJurnalMenerimaBahanBaku(int pGrandTotal)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);
        }

        //untuk menghitung biaya tenaga kerja langsung
        public void TambahDetilJurnalMenghitungBiayaTK(int pGrandTotal)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);
        }

        //untuk membayar tenaga kerja secara tunai 
        public void TambahDetilJurnalPembayaranTK(int pGrandTotal)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);
        }

        //untuk menyelesaikan produksi job order
        public void TambahDetilJurnalPenyelesaianProduksi(int pGrandTotal)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);
        }

        //untuk menjual barang dagangan secara tunai KR001
        public void TambahDetilJurnalPenjualanBarangTunai( int pGrandTotal,  int pTotalHpp)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);

            Akun akun3 = new Akun();
            akun3.NomorAkun = "51";
            DetilJurnal detil3 = new DetilJurnal(akun3, 3, pTotalHpp, 0);

            ListDetilJurnal.Add(detil3);

            Akun akun4 = new Akun();
            akun4.NomorAkun = "15";
            DetilJurnal detil4 = new DetilJurnal(akun4, 4, 0, pTotalHpp);

            ListDetilJurnal.Add(detil4);
        }
        //untuk menjual barang dagangan secara kredit
        public void TambahDetilJurnalPenjualanBarangKredit(int pGrandTotal, int pTotalHpp)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "12";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "41";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pGrandTotal);

            ListDetilJurnal.Add(detil2);

            Akun akun3 = new Akun();
            akun3.NomorAkun = "51";
            DetilJurnal detil3 = new DetilJurnal(akun3, 3, pTotalHpp, 0);

            ListDetilJurnal.Add(detil3);

            Akun akun4 = new Akun();
            akun4.NomorAkun = "15";
            DetilJurnal detil4 = new DetilJurnal(akun4, 4, 0, pTotalHpp);

            ListDetilJurnal.Add(detil4);
        }

        //untuk melunasi hutang secara tunai T0006
        public void TambahDetilJurnalPelunasanHutangTunai(int pHutang, int pDiskon)
        {
            Akun akun1 = new Akun();
            akun1.NomorAkun = "21";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pHutang, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "11";
            DetilJurnal detil2 = new DetilJurnal(akun2, 2, 0, pHutang-pDiskon);

            ListDetilJurnal.Add(detil2);

            Akun akun3 = new Akun();
            akun3.NomorAkun = "13";
            DetilJurnal detil3 = new DetilJurnal(akun3, 3, 0, pDiskon);

            ListDetilJurnal.Add(detil3);
        }
        //untuk pelunasan piutang 
        public void TambahDetilJurnalPelunasanPiutangTunai(int pPiutang)
        {
            //kas bertambah 
            // piutang berkurang
            Akun akun1 = new Akun();
            akun1.NomorAkun = "11";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pPiutang, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun3 = new Akun();
            akun3.NomorAkun = "12";
            DetilJurnal detil3 = new DetilJurnal(akun3, 2, 0, pPiutang);

            ListDetilJurnal.Add(detil3);
        }

        public static string BacaData(string pKriteria, string pNilaiKriteria, List<Jurnal> listJurnal)
        {
            string sql1 = "";

            if (pKriteria == "")
            {
                //tuliskan perintah sql1 = untuk menampilkan semua data  ditabel notapenjualan 
                sql1 = "select * from vLaporanDaftarJurnal";
            }
            else
            {
                sql1 = " select * from vLaporanDaftarJurnal WHERE "
                        + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }
            try
            {
                //data reader 1 = memperoleh semua data di tabel jurnal
                MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
                listJurnal.Clear();//kosongi isi list terlebih dahulu
                while (hasilData1.Read() == true)
                {
                    //buat object jurnal
                    Jurnal j = new Jurnal();
                    
                    j.IdJurnal = int.Parse(hasilData1.GetValue(0).ToString());
                    j.Tanggal = DateTime.Parse(hasilData1.GetValue(1).ToString());
                    j.NomorBukti = hasilData1.GetValue(6).ToString();
                    //tambahkan nama akun pada jenis (nama akun pada index ke 3)                  
                    j.Jenis = hasilData1.GetValue(3).ToString();

                    Transaksi trans = new Transaksi();
                    trans.Keterangan = hasilData1.GetValue(2).ToString();
                    //tambahkan debet pada id transaksi (debet di index ke 4 pada vlaporandaftarjural)
                    trans.IdTransaksi = hasilData1.GetValue(4).ToString();

                    Periode period = new Periode();
                    //tambahkan kredit pada idperiode ( kredit pada index ke 5)
                    period.IdPeriode = hasilData1.GetValue(5).ToString();

                    //tambahkan ke list
                    j.Transaksi = trans;
                    j.Periode = period;
                    listJurnal.Add(j);
                }
                return "1";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

        #endregion


    }
}
