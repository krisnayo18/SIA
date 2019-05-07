using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Pembayaran
    {
        #region Data Member
        private string idPembayaran, caraPembayaran;
        private DateTime tgl;
        private int nominal;
        private NotaPembelian notaPembelian;
        #endregion

        #region Properties
        public string IdPembayaran
        {
            get
            {
                return idPembayaran;
            }

            set
            {
                idPembayaran = value;
            }
        }

        public string CaraPembayaran
        {
            get
            {
                return caraPembayaran;
            }

            set
            {
                caraPembayaran = value;
            }
        }

        public DateTime Tgl
        {
            get
            {
                return tgl;
            }

            set
            {
                tgl = value;
            }
        }

        public int Nominal
        {
            get
            {
                return nominal;
            }

            set
            {
                nominal = value;
            }
        }

        public NotaPembelian NotaPembelian
        {
            get
            {
                return notaPembelian;
            }

            set
            {
                notaPembelian = value;
            }
        }

        #endregion
    }
}
