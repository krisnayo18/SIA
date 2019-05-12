using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    public class Akun
    {
        #region Data Member
        private string nomorAkun, nama, kelompok;
        private int saldoNominal;

        public Akun(string nomorAkun, string nama, string kelompok, int saldoNominal)
        {
            this.nomorAkun = nomorAkun;
            this.nama = nama;
            this.kelompok = kelompok;
            this.saldoNominal = saldoNominal;
        }
        public Akun()
        {
            this.nomorAkun = "";
            this.nama = "";
            this.kelompok = "";
            this.saldoNominal = 0 ;
        }
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

        public string NomorAkun
        {
            get
            {
                return nomorAkun;
            }

            set
            {
                nomorAkun = value;
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
