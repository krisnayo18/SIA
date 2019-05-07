using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class SuratPermintaan
    {
        #region Data Member
        private string noSuratPermintaan, keterangan;
        private DateTime tanggal;
        private JobOrder jobOrder;
        private List<DetilSuratPermintaan> listDetilSuratPermintaan;
        #endregion

        #region Properties
        public string NoSuratPermintaan
        {
            get
            {
                return noSuratPermintaan;
            }

            set
            {
                noSuratPermintaan = value;
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

        public JobOrder JobOrder
        {
            get
            {
                return jobOrder;
            }

            set
            {
                jobOrder = value;
            }
        }

        public List<DetilSuratPermintaan> ListDetilSuratPermintaan
        {
            get
            {
                return listDetilSuratPermintaan;
            }

            set
            {
                listDetilSuratPermintaan = value;
            }
        }

        #endregion
    }
}
