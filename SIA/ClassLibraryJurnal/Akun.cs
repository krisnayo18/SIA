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

        public Akun(string nomor, string nama, string kelompok, int saldoNominal)
        {
            this.nomor = nomor;
            this.nama = nama;
            this.kelompok = kelompok;
            this.saldoNominal = saldoNominal;
        }
        public Akun()
        {
            this.nomor = "";
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
