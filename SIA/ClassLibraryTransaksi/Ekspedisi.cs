using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Ekspedisi
    {
        #region Data Member
        private string idEkspedisi, nama, alamat, noTelepon;
        private int harga;
        #endregion

        #region Properties
        public string IdEkspedisi
        {
            get
            {
                return idEkspedisi;
            }

            set
            {
                idEkspedisi = value;
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

        public string Alamat
        {
            get
            {
                return alamat;
            }

            set
            {
                alamat = value;
            }
        }

        public string NoTelepon
        {
            get
            {
                return noTelepon;
            }

            set
            {
                noTelepon = value;
            }
        }

        public int Harga
        {
            get
            {
                return harga;
            }

            set
            {
                harga = value;
            }
        }

        #endregion
    }
}
