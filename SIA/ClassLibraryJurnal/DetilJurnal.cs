using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
   public class DetilJurnal
    {
        #region Data Member
        private Akun akun;
        private int noUrut, debit, kredit;
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

        public int Debit
        {
            get
            {
                return debit;
            }

            set
            {
                debit = value;
            }
        }

        public int Kredit
        {
            get
            {
                return kredit;
            }

            set
            {
                kredit = value;
            }
        }

        public int NoUrut
        {
            get
            {
                return noUrut;
            }

            set
            {
                noUrut = value;
            }
        }

#endregion
    }
}
