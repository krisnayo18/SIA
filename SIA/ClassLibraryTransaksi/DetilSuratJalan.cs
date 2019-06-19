using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class DetilSuratJalan
    {
        #region Data Member
        private Barang barang;
        private int jumlah;
        #endregion

        #region Constructor
        public DetilSuratJalan()
        {
            Jumlah = 0;
        }
        public DetilSuratJalan(Barang barang, int jumlah)
        {
            this.barang = barang;
            this.jumlah = jumlah;
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
