using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class Pelanggan
    {
        #region Data Member
        private string idPelanggan, nama, alamat, telepon;
        #endregion

        #region Properties
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

        public string IdPelanggan
        {
            get
            {
                return idPelanggan;
            }

            set
            {
                idPelanggan = value;
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

        public string Telepon
        {
            get
            {
                return telepon;
            }

            set
            {
                telepon = value;
            }
        }

        #endregion
    }
}
