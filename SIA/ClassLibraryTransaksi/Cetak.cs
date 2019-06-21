using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace ClassLibraryTransaksi
{
    public class Cetak
    {
        #region Data Member

        private Font jenisFont;

        #endregion

        #region Constructor
        public Cetak(string namaFile)
        {
            FileCetak = new StreamReader(namaFile);
            JenisFont = new Font("Arial", 10);
            MarginKiri = (float)10.5;
            MarginKanan = (float)10.5;
            marginAtas = (float)10.5;
            MarginBawah = (float)10.5;
        }

        public Cetak(string pNamaFile, string pNamaFont, int pUkuranFont, float pMarginKiri, float pMarginKanan, float pMarginAtas, float pMarginBawah)
        {
            FileCetak = new StreamReader(pNamaFile);
            JenisFont = new Font(pNamaFont, pUkuranFont);
            MarginKiri = pMarginKiri;
            MarginKanan = pMarginKanan;
            marginAtas = pMarginAtas;
            MarginBawah = pMarginBawah;
        }
        #endregion

        #region Properties
        public Font JenisFont
        {
            get { return jenisFont; }
            set { jenisFont = value; }
        }
        private StreamReader fileCetak;

        public StreamReader FileCetak
        {
            get { return fileCetak; }
            set { fileCetak = value; }
        }
        private float marginKiri, marginKanan, marginAtas, marginBawah;

        public float MarginBawah
        {
            get { return marginBawah; }
            set { marginBawah = value; }
        }

        public float MarginAtas
        {
            get { return marginAtas; }
            set { marginAtas = value; }
        }

        public float MarginKanan
        {
            get { return marginKanan; }
            set { marginKanan = value; }
        }

        public float MarginKiri
        {
            get { return marginKiri; }
            set { marginKiri = value; }
        }
        #endregion

        #region Method

        private void CetakTulisan(object sender, PrintPageEventArgs e)
        {
            int JumBarisPerHalaman = (int)((e.MarginBounds.Height - MarginBawah) / JenisFont.GetHeight(e.Graphics));

            float y = MarginAtas;

            int jumBaris = 0;

            string tulisanCetak = FileCetak.ReadLine();

            while (jumBaris < JumBarisPerHalaman && tulisanCetak != null)
            {
                y = MarginAtas + (jumBaris * jenisFont.GetHeight(e.Graphics));

                e.Graphics.DrawString(tulisanCetak, JenisFont, Brushes.Black, MarginKiri, y);

                jumBaris++;

                tulisanCetak = FileCetak.ReadLine();
            }

            if (tulisanCetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public string CetakKePrinter(string pTipe)
        {
            try
            {
                PrintDocument p = new PrintDocument();
                if (pTipe == "tulisan")
                {
                    p.PrintPage += new PrintPageEventHandler(CetakTulisan);
                }

                p.Print();

                FileCetak.Close();
                return "1";
            }
            catch (Exception e)
            {
                return "Proses Cetak gagal. Pesan Kesalahan = " + e.Message;
            }
        }


        #endregion
    }
}
