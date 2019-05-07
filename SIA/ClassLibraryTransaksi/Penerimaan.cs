using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Penerimaan
    {
        #region Data Member
        private string idPengiriman, jenisPengiriman, nama, keterangan;
        private int biayaKirim;
        private DateTime tglKirim;
        private NotaPembelian notaPembelian;
        #endregion

        #region Properties
        public string IdPengiriman
        {
            get
            {
                return idPengiriman;
            }

            set
            {
                idPengiriman = value;
            }
        }

        public string JenisPengiriman
        {
            get
            {
                return jenisPengiriman;
            }

            set
            {
                jenisPengiriman = value;
            }
        }

        public string Nama
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
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

        public int BiayaKirim
        {
            get
            {
                return biayaKirim;
            }

            set
            {
                biayaKirim = value;
            }
        }

        public DateTime TglKirim
        {
            get
            {
                return tglKirim;
            }

            set
            {
                tglKirim = value;
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
