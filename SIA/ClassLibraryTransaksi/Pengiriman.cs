using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class Pengiriman
    {

        #region Data Member
        private string idPengiriman, jenisPengiriman, nama, keterangan;
        private DateTime tglKirim;
        private int biayaKirim;
        private NotaPenjualan notaPenjualan;
        private Ekspedisi ekspedisi;
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

        public Ekspedisi Ekspedisi
        {
            get
            {
                return ekspedisi;
            }

            set
            {
                ekspedisi = value;
            }
        }

        #endregion
    }
}
