using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class NotaPembelian
    {
        #region Data Member
        private string noNotaPembelian, status, keterangan;
        private double diskon;
        private int totalHarga;
        private DateTime tglBatasPelunasan, tglBatasDiskon, tglBeli;
        private Supplier supplier;
        private List<DetilNotaBeli> listNotaPembelian;
        #endregion

        #region Properties
        public string NoNotaPembelian
        {
            get
            {
                return noNotaPembelian;
            }

            set
            {
                noNotaPembelian = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
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

        public double Diskon
        {
            get
            {
                return diskon;
            }

            set
            {
                diskon = value;
            }
        }

        public int TotalHarga
        {
            get
            {
                return totalHarga;
            }

            set
            {
                totalHarga = value;
            }
        }

        public DateTime TglBatasPelunasan
        {
            get
            {
                return tglBatasPelunasan;
            }

            set
            {
                tglBatasPelunasan = value;
            }
        }

        public DateTime TglBatasDiskon
        {
            get
            {
                return tglBatasDiskon;
            }

            set
            {
                tglBatasDiskon = value;
            }
        }

        public DateTime TglBeli
        {
            get
            {
                return tglBeli;
            }

            set
            {
                tglBeli = value;
            }
        }

        public Supplier Supplier
        {
            get
            {
                return supplier;
            }

            set
            {
                supplier = value;
            }
        }

        public List<DetilNotaBeli> ListNotaPembelian
        {
            get
            {
                return listNotaPembelian;
            }

            set
            {
                listNotaPembelian = value;
            }
        }

        #endregion
    }
}
