using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
   public class Barang
    {
        #region Data Member
        private string kodeBarang, nama, jenis, satuan;
        private int quantity, hargaBeliTerbaru, hargaJual;

        #endregion

        #region Properties
        public int HargaBeliTerbaru
        {
            get
            {
                return hargaBeliTerbaru;
            }

            set
            {
                hargaBeliTerbaru = value;
            }
        }

        public int HargaJual
        {
            get
            {
                return hargaJual;
            }

            set
            {
                hargaJual = value;
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

        public string KodeBarang
        {
            get
            {
                return kodeBarang;
            }

            set
            {
                kodeBarang = value;
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

        public string Satuan
        {
            get
            {
                return satuan;
            }

            set
            {
                satuan = value;
            }
        }
       
        #endregion
    }
}
