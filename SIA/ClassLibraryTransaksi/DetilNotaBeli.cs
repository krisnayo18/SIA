using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class DetilNotaBeli
    {
        #region Data Member
        private Barang barang;
        private int jumlah, hargaBeli;
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

        public int HargaBeli
        {
            get
            {
                return hargaBeli;
            }

            set
            {
                hargaBeli = value;
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
