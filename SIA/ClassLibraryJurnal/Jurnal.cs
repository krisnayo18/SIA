using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ClassLibraryJurnal
{
    public class Jurnal
    {
        #region Data Member
        private string idJurnal,  nomorBukti, jenis;
        private DateTime tanggal;
        private Periode periode;
        private Transaksi transaksi;
        private List<DetilJurnal> listDetilJurnal;


        //percobaan
        private DetilJurnal detilJurnal;


        #endregion

        #region Constructor

        public Jurnal(string idJurnal,  string nomorBukti, string jenis, DateTime tanggal, Periode periode, Transaksi transaksi)
        {
            this.idJurnal = idJurnal;
            
            this.nomorBukti = nomorBukti;
            this.jenis = jenis;
            this.tanggal = tanggal;
            this.periode = periode;
            this.transaksi = transaksi;
            ListDetilJurnal = new List<DetilJurnal>();
        }
        public Jurnal(string idJurnal, DateTime tanggal, Transaksi transaksi, DetilJurnal detil, string nomorBukti)
        {
            this.idJurnal = idJurnal;
            this.nomorBukti = nomorBukti;
            this.tanggal = tanggal;
            this.transaksi = transaksi;
            this.DetilJurnal = detil;

 
        }
        public Jurnal()
        {
            this.idJurnal = "";
            
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

        public DetilJurnal DetilJurnal
        {
            get
            {
                return detilJurnal;
            }

            set
            {
                detilJurnal = value;
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

            string pIdJurnalTerbaru = "1";
            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
        
                if (hasilData.Read() == true) //jika ada data
                {
                    string  idJurnalTerakhir = hasilData.GetValue(0).ToString(); // mendapatkan idjurnal terakhir di db

                    if(idJurnalTerakhir != "") // jika idjurnal terakhir tidak 0 
                    {
                        pIdJurnalTerbaru = (int.Parse(idJurnalTerakhir) + 1).ToString();
                    }

                }

                return pIdJurnalTerbaru;
            }
            catch (Exception e)
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
            Akun akun1 = new Akun();
            akun1.NomorAkun = "13";
            DetilJurnal detil1 = new DetilJurnal(akun1, 1, pGrandTotal, 0);

            ListDetilJurnal.Add(detil1);

            Akun akun2 = new Akun();
            akun2.NomorAkun = "21";
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
                    string pIdJurnal = hasilData1.GetValue(0).ToString();
                    string pNomorBukti = hasilData1.GetValue(6).ToString();
                    DateTime pTanggal = DateTime.Parse(hasilData1.GetValue(1).ToString());

                    //mendapatkan kredit dan debit
                    int Debet = int.Parse(hasilData1.GetValue(4).ToString());
                    int Kredit = int.Parse(hasilData1.GetValue(5).ToString());


                    Transaksi trans = new Transaksi();
                    trans.Keterangan = hasilData1.GetValue(2).ToString();

                    //mendapatkan  nama akun 
                    string namaAkun = hasilData1.GetValue(3).ToString();
                    Akun pAkun = new Akun();
                    pAkun.Nama = namaAkun;
                    
                    //buat object akun dan tambahkan
                    DetilJurnal detil = new DetilJurnal();
                    detil.Akun = pAkun;
                    detil.Debit = Debet;
                    detil.Kredit = Kredit;

                    Jurnal jurnal = new Jurnal(pIdJurnal, pTanggal, trans,detil, pNomorBukti);

                    //buat object bertipe detiljurnal dan tambahkan
                    //ingat baik baik agar fk tidak duplicate
                    //DetilJurnal dj = new DetilJurnal(akun, 0, Debet, Kredit);

                    //simpan detil jurnal ke jurnal
                    //jurnal.TambahDetilJurnal(akun, Debet, Kredit);

                    listJurnal.Add(jurnal);
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
