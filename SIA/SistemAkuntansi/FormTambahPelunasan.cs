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
    public partial class FormTambahPenerimaanPembayaran : Form
    {
        public FormTambahPenerimaanPembayaran()
        {
            InitializeComponent();
        }
        List<Pelunasan> listHasilData = new List<Pelunasan>();
        List<NotaPenjualan> listHasilData2 = new List<NotaPenjualan>();
        Periode pPeriode = new Periode();
        DateTime btsDiskon = DateTime.Now;
        double diskon = 0;
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormDaftarPelunasan form = (FormDaftarPelunasan)this.Owner;
            int piutang = int.Parse(textBoxNominal.Text);
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
            int hargaDiskon = (int)(piutang * diskon); // hitung total yang harus dibayar oleh pembeli

            NotaPenjualan nota = new NotaPenjualan();
            nota.NoNotaPenjualan = comboBoxNoNotaJual.Text;
            nota.Status = "L";
            //buat object bertipe notajual
            Pelunasan lunas = new Pelunasan();
            lunas.NoPelunasan = textBoxNoPelunasan.Text;
            lunas.NotaPenjualan = nota;
            lunas.Tanggal = dateTimePickerTgl.Value;
            lunas.CaraPembayaran = comboBoxCaraPemb.Text;
            lunas.Nominal = piutang - hargaDiskon;

            string hasilTambahNota = Pelunasan.TambahData(lunas, nota);

            if (hasilTambahNota == "1") //jika berhasil maka insert jurnal dan detil jurnal
            {
                MessageBox.Show("Data Pelunasan telah tersimpan", "Info");
                //tambah posting ke jurnal

                string idJurnal = Jurnal.GenerateIdJurnal();

                Transaksi trans = new Transaksi();
                //transaksi penjualan tunai (id transkasi 008);
                trans.IdTransaksi = "010";
                trans.Keterangan = "Pelunasan piutang dari cv abadi";

                //buat object bertipe jurnal
                Jurnal jurnal = new Jurnal();
                //tambahkan data
                jurnal.IdJurnal = int.Parse(idJurnal);
                jurnal.Tanggal = dateTimePickerTgl.Value;

                jurnal.NomorBukti = comboBoxNoNotaJual.Text;
                jurnal.Jenis = "JU";
                jurnal.Periode = pPeriode;
                jurnal.Transaksi = trans;

                //isi detil jurnalnya
                //apabila ada diskon
                //
                //apabila tidak ada diskon
                jurnal.TambahDetilJurnalPelunasanPiutangTunai(piutang);
                
                //simpan ke tabel _jurnal
                string hasilTambahJurnal = Jurnal.TambahData(jurnal);
                if (hasilTambahJurnal == "1")
                {
                    MessageBox.Show("berhasil posting ke jurnal");
                    FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
                    form.FormDaftarPelunasan_Load(sender, e);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("gagal posting ke jurnal" + hasilTambahJurnal);
                }
            }
            else
            {
                MessageBox.Show("Data pelunasan gagal tersimpan. Pesan kesalahan : " + hasilTambahNota, "Kesalahan");
            }
        }

    private void FormTambahPenerimaanPembayaran_Load(object sender, EventArgs e)
        {
           
            string noNotaBaru;
            pPeriode = Periode.GetPeriodeTerbaru();
            comboBoxNoNotaJual.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaraPemb.DropDownStyle = ComboBoxStyle.DropDownList;
            string hasilGenerate = Pelunasan.GenerateNoNota(out noNotaBaru);
            textBoxNoPelunasan.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNoPelunasan.Text = noNotaBaru;
              
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTgl.Value = DateTime.Now;
            dateTimePickerTgl.Enabled = false;

            string hasilBaca = NotaPenjualan.BacaDataPelunasan("","", listHasilData2);

            if (hasilBaca == "1")
            {
                comboBoxNoNotaJual.Items.Clear();
                for (int i = 0; i < listHasilData2.Count; i++)
                {
                        comboBoxNoNotaJual.Items.Add(listHasilData2[i].NoNotaPenjualan);
                }
            }
            else
            {
                comboBoxNoNotaJual.Items.Clear();
            }
            if(comboBoxNoNotaJual.Items.Count != 0)
            comboBoxNoNotaJual.SelectedIndex = 0;
            comboBoxCaraPemb.SelectedIndex = 0;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxNoNotaJual_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = NotaPenjualan.BacaDataPelunasan("noNotaPenjualan", comboBoxNoNotaJual.Text, listHasilData2);

            if (hasilBaca == "1")
            {
                textBoxNominal.Clear();
                if (listHasilData2.Count > 0)
                {
                    textBoxNominal.Text = listHasilData2[0].TotalHarga.ToString();
                    btsDiskon = listHasilData2[0].TglBatasDiskon; // 
                    diskon = listHasilData2[0].Diskon;//untuk mendapatkan diskon
                    if (diskon > 0) // apabila terdapat diskon, maka tampilkan info diskon dan batas diskon
                    {
                        MessageBox.Show("Pembeli mendapatkan diskon : " + diskon + "%, apabila membayar sebelum atau tanggal : " + btsDiskon.ToString("dddd, dd MMMM yyyy"), "Info Diskon");
                    }
                    else //apabila ada diskon
                    {
                        MessageBox.Show("Tidak ada diskon untuk pembeli", "Info Diskon");
                    }
                }
            }
            else
            {
                textBoxNominal.Clear();
            }
        }
    }
}
