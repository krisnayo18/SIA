using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryTransaksi;

namespace SistemAkuntansi
{
    public partial class FormTambahPengiriman : Form
    {
        public FormTambahPengiriman()
        {
            InitializeComponent();
        }
       
        List<NotaPenjualan> listHasilNota = new List<NotaPenjualan>();
        List<Pengiriman> listHasilData = new List<Pengiriman>();
        List<Ekspedisi> listHasilEkspedisi = new List<Ekspedisi>();
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            FormDaftarPengiriman form = (FormDaftarPengiriman)this.Owner;

            Ekspedisi eks = new Ekspedisi();
            eks.IdEkspedisi = comboBoxIdEks.Text;
            eks.Nama = textBoxNamaEks.Text;

            NotaPenjualan nota = new NotaPenjualan();
            nota.NoNotaPenjualan = comboBoxNoNotaJual.Text; 
           
            string kode = textBoxKodePengiriman.Text;
            string jenis = "";
            if (comboBoxJenisPengiriman.Text == "Shipping Point")
                jenis = "SP";
            else
                jenis = "DP";
            int biaya = int.Parse(textBoxBiaya.Text);
            string nama = textBoxNama.Text;
            DateTime tgl = dateTimePickerKirim.Value;
            string ket = textBoxKeterangan.Text;
            Pengiriman peng = new Pengiriman(kode,jenis,nama, ket, tgl,biaya,nota,eks);

            string hasilTambah = Pengiriman.TambahData(peng);

            if (hasilTambah == "1")
            {
                MessageBox.Show("Berhasil Menambahkan Pengiriman");
                this.Close();
                form.FormDaftarPengiriman_Load(sender, e); 
            }
            else
            {
                MessageBox.Show("pengiriman gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahPengiriman_Load(object sender, EventArgs e)
        {
            comboBoxJenisPengiriman.Items.AddRange(new string[] { "Shipping Point", "Destination Point"});
            string noNotaBaru;
            textBoxNamaEks.Enabled = false;
            textBoxKodePengiriman.Enabled = false;
            dateTimePickerKirim.Enabled = false;
            dateTimePickerKirim.Value = DateTime.Now;
            comboBoxNoNotaJual.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIdEks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJenisPengiriman.DropDownStyle = ComboBoxStyle.DropDownList;

            string hasilGenerate = Pengiriman.GenerateNoNota(out noNotaBaru);
            textBoxKodePengiriman.Clear();
            if (hasilGenerate == "1")
            {
                textBoxKodePengiriman.Text = noNotaBaru;

            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            string hasilBaca = NotaPenjualan.BacaData("", "", listHasilNota);

            if (hasilBaca == "1")
            {
                comboBoxNoNotaJual.Items.Clear();
                for (int i = 0; i < listHasilNota.Count; i++)
                {
                    comboBoxNoNotaJual.Items.Add(listHasilNota[i].NoNotaPenjualan);
                }
            }
            else
            {
                comboBoxNoNotaJual.Items.Clear();
            }
            string hasilBaca2 = Ekspedisi.BacaData("", "", listHasilEkspedisi);

            if (hasilBaca2 == "1")
            {
                comboBoxIdEks.Items.Clear();
                for (int i = 0; i < listHasilEkspedisi.Count; i++)
                {   

                    comboBoxIdEks.Items.Add(listHasilEkspedisi[i].IdEkspedisi);
                    textBoxNamaEks.Text = listHasilEkspedisi[i].Nama;
                }
            }
            else
            {
                comboBoxIdEks.Items.Clear();
            }

            if(comboBoxNoNotaJual.Items.Count != 0)
                comboBoxNoNotaJual.SelectedIndex = 0;
            if(comboBoxIdEks.Items.Count !=0)
                comboBoxIdEks.SelectedIndex = 0;
            if(comboBoxJenisPengiriman.Items.Count != 0)
                comboBoxJenisPengiriman.SelectedIndex = 0;

            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;

        }

        private void comboBoxIdEks_TextChanged(object sender, EventArgs e)
        {
            string hasilBaca2 = Ekspedisi.BacaData("idEkspedisi", comboBoxIdEks.Text, listHasilEkspedisi);

            if (hasilBaca2 == "1")
            {
                textBoxNamaEks.Clear();
                for (int i = 0; i < listHasilEkspedisi.Count; i++)
                {
                    textBoxNamaEks.Text = listHasilEkspedisi[i].Nama;
                }
            }
            else
            {
                textBoxNamaEks.Clear();
            }
        }
    }
}
