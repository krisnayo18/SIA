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

    }
}
