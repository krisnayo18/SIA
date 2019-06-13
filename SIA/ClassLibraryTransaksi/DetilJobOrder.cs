using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class DetilJobOrder
    {
        #region Data Member
        private Karyawan karyawan;
        private string satuan;
        private int gajiPerSatuan;
        #endregion

        #region Constructor
        public DetilJobOrder()
        {
            Satuan = "";
            GajiPerSatuan = 0;
        }
        public DetilJobOrder(Karyawan karyawan, string satuan, int gajiPerSatuan)
        {
            this.karyawan = karyawan;
            this.satuan = satuan;
            this.gajiPerSatuan = gajiPerSatuan;
        }
        #endregion

        #region Properties
        public Karyawan Karyawan
        {
            get
            {
                return karyawan;
            }

            set
            {
                karyawan = value;
            }
        }
        public string Satuan
        {
            get
            {
                return satuan;
            }

            set
            {
                satuan = value;
            }
        }

        public int GajiPerSatuan
        {
            get
            {
                return gajiPerSatuan;
            }

            set
            {
                gajiPerSatuan = value;
            }
        }

        #endregion
    }
}
