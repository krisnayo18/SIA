using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public   class DetilNotaJual
    {

        #region Data Member
        private Barang barang;
        private int jumlah, hargaJual;
        #endregion

        #region Properties
        public Barang Barang
        {
            get
            {
                return barang;
            }

            set
            {
                barang = value;
            }
        }

        public int HargaJual
        {
            get
            {
                return hargaJual;
            }

            set
            {
                hargaJual = value;
            }
        }

        public int Jumlah
        {
            get
            {
                return jumlah;
            }

            set
            {
                jumlah = value;
            }
        }

        #endregion
    }
}
