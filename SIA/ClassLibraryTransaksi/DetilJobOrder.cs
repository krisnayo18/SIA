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
        private string jumlah, satuan, gajiPerSatuan;
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

        public string Jumlah
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

        public string GajiPerSatuan
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
