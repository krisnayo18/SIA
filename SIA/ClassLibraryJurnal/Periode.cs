using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryJurnal
{
    public class Periode
    {
        #region Data Member
        private string idPeriode;
        private DateTime tglAwal, tglAkhir;
        private List<PeriodeAkun> listPeriodeAkun;

        public Periode(string idPeriode, DateTime tglAwal, DateTime tglAkhir)
        {
            this.idPeriode = idPeriode;
            this.tglAwal = tglAwal;
            this.tglAkhir = tglAkhir;
            listPeriodeAkun = new List<PeriodeAkun>();
        }
        public Periode()
        {
            this.idPeriode = "";
            this.tglAwal = DateTime.Now;
            this.tglAkhir = DateTime.Now;
            listPeriodeAkun = new List<PeriodeAkun>();
        }
        #endregion

        #region Properties
        public string IdPeriode
        {
            get
            {
                return idPeriode;
            }

            set
            {
                idPeriode = value;
            }
        }

        public DateTime TglAwal
        {
            get
            {
                return tglAwal;
            }

            set
            {
                tglAwal = value;
            }
        }

        public DateTime TglAkhir
        {
            get
            {
                return tglAkhir;
            }

            set
            {
                tglAkhir = value;
            }
        }

        internal List<PeriodeAkun> ListPeriodeAkun
        {
            get
            {
                return listPeriodeAkun;
            }

            set
            {
                listPeriodeAkun = value;
            }
        }

        #endregion

        #region Method
        public static Periode GetPeriodeTerbaru()
        {   
            //ambil data dari periode
            string sql = "select * from _periode where idPeriode = (select max(idPeriode) from _periode)";
         
            
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

            Periode hasilPeriode = null;
            if (hasilData.Read() == true) //jika ada data
                {
                    string idPeriode = hasilData.GetValue(0).ToString();
                    DateTime tglAwal = DateTime.Parse(hasilData.GetValue(1).ToString());
                    DateTime tglAkhir = DateTime.Parse(hasilData.GetValue(2).ToString());
                    hasilPeriode = new Periode(idPeriode, tglAwal, tglAkhir);
                }
                return hasilPeriode;
            
            
        }
        #endregion

    }
}
