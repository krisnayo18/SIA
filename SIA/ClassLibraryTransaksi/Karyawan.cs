using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTransaksi
{
    public class Karyawan
    {
        #region Data Member
        private string idKaryawan, nama, gender, alamat, noTelepon;
        private int gaji;
        #endregion

        #region Properties
        public string IdKaryawan
        {
            get
            {
                return idKaryawan;
            }

            set
            {
                idKaryawan = value;
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

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
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

        public int Gaji
        {
            get
            {
                return gaji;
            }

            set
            {
                gaji = value;
            }
        }

        #endregion
    }
}
