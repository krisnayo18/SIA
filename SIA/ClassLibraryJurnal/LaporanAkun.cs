using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    public class LaporanAkun
    {
        #region Data Member
        private Akun akun;
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

#endregion
    }
}
