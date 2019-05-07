using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public  class JobOrder
    {
        #region Data Member
        private string kodeJobOrder;
        private int quantity, directLabor, directMaterial, overheadProduksi;
        private DateTime tglMulai, tglSelesai;
        private Barang barang;
        private NotaPenjualan notaPenjualan;
        private List<DetilJobOrder> listDetilJobOrder;
        #endregion

        #region Properties
        public string KodeJobOrder
        {
            get
            {
                return kodeJobOrder;
            }

            set
            {
                kodeJobOrder = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public int DirectLabor
        {
            get
            {
                return directLabor;
            }

            set
            {
                directLabor = value;
            }
        }

        public int DirectMaterial
        {
            get
            {
                return directMaterial;
            }

            set
            {
                directMaterial = value;
            }
        }

        public int OverheadProduksi
        {
            get
            {
                return overheadProduksi;
            }

            set
            {
                overheadProduksi = value;
            }
        }

        public DateTime TglMulai
        {
            get
            {
                return tglMulai;
            }

            set
            {
                tglMulai = value;
            }
        }

        public DateTime TglSelesai
        {
            get
            {
                return tglSelesai;
            }

            set
            {
                tglSelesai = value;
            }
        }

        public Barang Barang
        {
            get
            {
                return barang;
            }

            set
            {
                barang = value;
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

        public List<DetilJobOrder> ListDetilJobOrder
        {
            get
            {
                return listDetilJobOrder;
            }

            set
            {
                listDetilJobOrder = value;
            }
        }

        #endregion
    }
}
