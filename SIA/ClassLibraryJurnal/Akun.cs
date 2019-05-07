using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    public class Akun
    {
        #region Data Member
        private string nomor, nama, kelompok;
        private int saldoNominal;
        #endregion

        #region Properties
        public string Kelompok
        {
            get
            {
                return kelompok;
            }

            set
            {
                kelompok = value;
            }
        }

        public string Nama
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
            }
        }

        public string Nomor
        {
            get
            {
                return nomor;
            }

            set
            {
                nomor = value;
            }
        }

        public int SaldoNominal
        {
            get
            {
                return saldoNominal;
            }

            set
            {
                saldoNominal = value;
            }
        }

#endregion
    }
}
