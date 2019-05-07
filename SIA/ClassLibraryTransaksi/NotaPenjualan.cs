using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class NotaPenjualan
    {

        #region Data Member
        private string noNotaPenjualan, status, keterangan;
        private double diskon;
        private int totalHarga;
        private DateTime tglBatasPelunasan, tglBatasDiskon, tglBeli;
        private Pelanggan pelanggan;
        private List<DetilNotaJual> listNotaPenjualan;
        #endregion

        #region Properties
        public string NoNotaPenjualan
        {
            get
            {
                return noNotaPenjualan;
            }

            set
            {
                noNotaPenjualan = value;
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

        public Pelanggan Pelanggan
        {
            get
            {
                return pelanggan;
            }

            set
            {
                pelanggan = value;
            }
        }

        public List<DetilNotaJual> ListNotaPenjualan
        {
            get
            {
                return listNotaPenjualan;
            }

            set
            {
                listNotaPenjualan = value;
            }
        }

        #endregion
    }
}
