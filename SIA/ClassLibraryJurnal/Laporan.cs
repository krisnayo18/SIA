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
    }
}
