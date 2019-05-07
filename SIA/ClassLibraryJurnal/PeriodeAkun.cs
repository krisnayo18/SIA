using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    class PeriodeAkun
    {
        #region Data Member
        private Akun akun;
        private long saldoAwal, saldoAkhir;
        #endregion

        #region Properties
        public Akun Akun
        {
            get
            {
                return akun;
            }

            set
            {
                akun = value;
            }
        }

        public long SaldoAkhir
        {
            get
            {
                return saldoAkhir;
            }

            set
            {
                saldoAkhir = value;
            }
        }

        public long SaldoAwal
        {
            get
            {
                return saldoAwal;
            }

            set
            {
                saldoAwal = value;
            }
        }

#endregion
    }
}
