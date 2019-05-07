using System;
using System.Collections.Generic;

namespace ClassLibraryJurnal
{
    public class Jurnal
    {
        #region Data Member
        private String idJurnal, keterangan, nomorBukti, jenis;
        private DateTime tanggal;
        private Periode periode;
        private Transaksi transaksi;
        private List<DetilJurnal> listDetilJurnal;
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

        public string Keterangan
        {
            get
            {
                return keterangan;
            }

            set
            {
                keterangan = value;
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

            set
            {
                listDetilJurnal = value;
            }
        }
        #endregion
    }
}
