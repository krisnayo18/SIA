using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class PenerimaanPembayaran
    {


        #region Data Member
        private string caraPembayaran, noPenerimaanPembayaran;
        private DateTime tanggal;
        private int nominal;
        private NotaPenjualan notaPenjualan;
        #endregion

        #region Properties
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

        public string NoPenerimaanPembayaran
        {
            get
            {
                return noPenerimaanPembayaran;
            }

            set
            {
                noPenerimaanPembayaran = value;
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

        public NotaPenjualan NotaPenjualan
        {
            get
            {
                return notaPenjualan;
            }

            set
            {
                notaPenjualan = value;
            }
        }

        #endregion
    }
}
