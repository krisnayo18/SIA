using System;
using System.Collections.Generic;

namespace SIA_LIB
{
    public class Jurnal
    {
        private String idJurnal, keterangan, nomorBukti, jenis;
        private DateTime tanggal;
        private Periode periode;
        private Transaksi transaksi;
        private List<DetilJurnal> listDetilJurnal;

        public string IdJurnal { get => idJurnal; set => idJurnal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public string NomorBukti { get => nomorBukti; set => nomorBukti = value; }
        public string Jenis { get => jenis; set => jenis = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
        internal Periode Periode { get => periode; set => periode = value; }
        internal Transaksi Transaksi { get => transaksi; set => transaksi = value; }
        internal List<DetilJurnal> ListDetilJurnal { get => listDetilJurnal; set => listDetilJurnal = value; }
    }
}
