using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryJurnal;
using ClassLibraryTransaksi;

namespace SistemAkuntansi
{
    public partial class FormTambahPembayaran : Form
    {
        public FormTambahPembayaran()
        {
            InitializeComponent();
        }
        List<Pembayaran> listHasilData = new List<Pembayaran>();
        List<NotaPembelian> listHasilData2 = new List<NotaPembelian>();
        Periode pPeriode = new Periode();
        DateTime btsDiskon = DateTime.Now;
        double diskon = 0;
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormDaftarPembayaran form = (FormDaftarPembayaran)this.Owner;
            int hutang = int.Parse(textBoxNominal.Text);
            DateTime tglPemb = dateTimePickerTgl.Value;
            // pngecekan apabila tanggal pembayaran sebelum tanggal batas diskon
            if (tglPemb <= btsDiskon) // apabila sebelum batas diskon
            {
                diskon = diskon / 100;
            }
            else // apabila melewati tanggal batas diskon
            {
                diskon = 0;
            }
            int hargaDiskon = (int)(hutang * diskon); // hitung total yang harus dibayar

            //buat object bertipe notaBeli
            NotaPembelian nota = new NotaPembelian();
            nota.NoNotaPembelian = comboBoxNoNotaBeli.Text;
            nota.Status = "L";

            MessageBox.Show("" + nota.NoNotaPembelian);
            
            Pembayaran lunas = new Pembayaran();
            lunas.IdPembayaran = textBoxNoPembayaran.Text;
            lunas.CaraPembayaran = comboBoxCaraPemb.Text;
            lunas.Tgl = dateTimePickerTgl.Value;
            lunas.Nominal = hutang - hargaDiskon;
            //lunas.NotaPembelian = nota;

            string hasilTambahNota = Pembayaran.TambahData(lunas, nota);

            if (hasilTambahNota == "1") //jika berhasil maka insert jurnal dan detil jurnal
            {
                MessageBox.Show("Data Pembayaran telah tersimpan", "Info");
                //tambah posting ke jurnal

                string idJurnal = Jurnal.GenerateIdJurnal();

                Transaksi trans = new Transaksi();
                //transaksi penjualan tunai (id transkasi 008);
                trans.IdTransaksi = "009";
                trans.Keterangan = "Melunasi hutang secara tunai";

                //buat object bertipe jurnal
                Jurnal jurnal = new Jurnal();
                //tambahkan data
                jurnal.IdJurnal = int.Parse(idJurnal);
                jurnal.Tanggal = dateTimePickerTgl.Value;

                jurnal.NomorBukti = comboBoxNoNotaBeli.Text;
                jurnal.Jenis = "JU";
                jurnal.Periode = pPeriode;
                jurnal.Transaksi = trans;

                //isi detil jurnalnya
                //apabila diskon tidak 0 atau tidak ada diskon
                //
                //apabila ada diskon
                jurnal.TambahDetilJurnalPembayaranHutangTunai(hutang, hargaDiskon);
                //simpan ke tabel _jurnal
                string hasilTambahJurnal = Jurnal.TambahData(jurnal);
                if (hasilTambahJurnal == "1")
                {
                    MessageBox.Show("berhasil posting ke jurnal");
                    FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
                    this.Close();
                    form.FormDaftarPembayaran_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("gagal posting ke jurnal" + hasilTambahJurnal);
                }
            }
            else
            {
                MessageBox.Show("Data pembayaran gagal tersimpan. Pesan kesalahan : " + hasilTambahNota, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxNoNotaBeli_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Pembayaran.BacaDataPembayaran("noNotaPembelian", comboBoxNoNotaBeli.Text, listHasilData2);

            if (hasilBaca == "1")
            {
                textBoxNominal.Clear();
                if (listHasilData2.Count > 0)
                {
                    textBoxNominal.Text = listHasilData2[0].TotalHarga.ToString();
                    btsDiskon = listHasilData2[0].TglBatasDiskon;
                    diskon = listHasilData2[0].Diskon;//untuk mendapatkan diskon
                    if(diskon > 0) // apabila terdapat diskon, maka tampilkan info diskon dan batas diskon
                    {
                        MessageBox.Show("Mendapatkan diskon : " + diskon + "%, apabila membayar sebelum atau tanggal :  " + btsDiskon.ToString("dddd, dd MMMM yyyy"),
                            "Info Diskon");
                    }
                    else //apabila tidak ada diskon
                    {
                        MessageBox.Show("Tidak ada diskon", "Info Diskon");
                    }
                }
            }
            else
            {
                textBoxNominal.Clear();
            }
        }

        private void FormTambahPembayaran_Load(object sender, EventArgs e)
        {
            string noNotaBaru;
            pPeriode = Periode.GetPeriodeTerbaru();
            comboBoxNoNotaBeli.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaraPemb.DropDownStyle = ComboBoxStyle.DropDownList;
            string hasilGenerate = Pembayaran.GenerateNoNota(out noNotaBaru);
            textBoxNoPembayaran.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNoPembayaran.Text = noNotaBaru;

            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTgl.Value = DateTime.Now;
            dateTimePickerTgl.Enabled = false;

            string hasilBaca = Pembayaran.BacaDataPembayaran("", "", listHasilData2);

            if (hasilBaca == "1")
            {
                comboBoxNoNotaBeli.Items.Clear();
                for (int i = 0; i < listHasilData2.Count; i++)
                {
                    comboBoxNoNotaBeli.Items.Add(listHasilData2[i].NoNotaPembelian);
                }
            }
            else
            {
                comboBoxNoNotaBeli.Items.Clear();
            }
        }
    }
}
