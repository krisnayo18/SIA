using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class SuratJalan
    {
        #region Data Member
        private string noSuratJalan, jenis, keterangan;
        private DateTime tgl;
        private SuratPermintaan suratPermintaan;
        private List<DetilSuratJalan> listDetilSuratJalan;
        #endregion

        #region Properties
        public string NoSuratJalan
        {
            get
            {
                return noSuratJalan;
            }

            set
            {
                noSuratJalan = value;
            }
        }

        public string Jenis
        {
            get
            {
                return jenis;
            }

            set
            {
                jenis = value;
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

        public List<DetilSuratJalan> ListDetilSuratJalan
        {
            get
            {
                return listDetilSuratJalan;
            }

            set
            {
                listDetilSuratJalan = value;
            }
        }

        public SuratPermintaan SuratPermintaan
        {
            get
            {
                return suratPermintaan;
            }

            set
            {
                suratPermintaan = value;
            }
        }

        #endregion
    }
}
