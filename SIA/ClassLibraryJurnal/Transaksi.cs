using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    public   class Transaksi
    {
        #region Data Member
        private string idTransaksi, keterangan;
        #endregion

        #region Properties
        public string IdTransaksi
        {
            get
            {
                return idTransaksi;
            }

            set
            {
                idTransaksi = value;
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

#endregion
    }
}
