using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class Supplier
    {
        #region Data Member
        private string idSupplier, nama, alamat, noTelepon;
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

        public string IdSupplier
        {
            get
            {
                return idSupplier;
            }

            set
            {
                idSupplier = value;
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

        #endregion
    }
}
