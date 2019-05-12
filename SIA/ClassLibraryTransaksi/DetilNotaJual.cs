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
        private Barang barang; //aggregation
        private int jumlah, hargaJual;
        #endregion

        #region Constructor
        public DetilNotaJual(Barang barang, int jumlah, int hargaJual)
        {
            this.barang = barang;
            this.jumlah = jumlah;
            this.hargaJual = hargaJual;
        }
        public DetilNotaJual()
        {
            Jumlah = 0;
            HargaJual = 0;
        }
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
