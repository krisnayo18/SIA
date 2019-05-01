using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassJualBeli;

namespace SIA
{
    public partial class FormTambahBarang : Form
    {
        public FormTambahBarang()
        {
            InitializeComponent();
        }

        List<Kategori> listDataKategori = new List<Kategori>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormDaftarBarang fdb = (FormDaftarBarang)this.Owner; 

            Kategori kategoriBrng = listDataKategori[comboBoxKategori.SelectedIndex];
            Barang br = new Barang(textBoxKode.Text, textBoxBarcode.Text, textBoxNama.Text, int.Parse(textBoxHargaJual.Text), int.Parse(textBoxStok.Text), kategoriBrng);
            string hasilTambah = Barang.TambahData(br);

            
            if (hasilTambah == "1")
            {
                MessageBox.Show("Data barang telah tersimpan.", "Informasi");

                textBoxKode.Clear();
                textBoxBarcode.Clear();
                textBoxHargaJual.Clear();
                textBoxStok.Clear();
                textBoxNama.Clear();

                fdb.FormDaftarBarang_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Gagal menambah kategori. Pesan kesalahan : " + hasilTambah);
            }
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            this.Location = new Point(881, 26);
            textBoxKode.MaxLength = 5;
            textBoxBarcode.MaxLength = 13;
            textBoxNama.MaxLength = 45;

            comboBoxKategori.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxKode.Enabled = false;

            string hasilBaca = Kategori.BacaData("", "", listDataKategori);

            if (hasilBaca == "1")
            {
                comboBoxKategori.Items.Clear();
                for (int i = 0; i < listDataKategori.Count; i++)
                {
                    comboBoxKategori.Items.Add(listDataKategori[i].KodeKategori + " - " + listDataKategori[i].Nama);
                }
            }
            else
            {
                comboBoxKategori.Items.Clear();
            }
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kodeKategori = comboBoxKategori.Text.Substring(0, 2);
            string kodeTerbaru;

            string hasilGenerate = Barang.GenerateCode(kodeKategori, out kodeTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxKode.Text = kodeTerbaru;

                textBoxBarcode.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKode.Clear();
            textBoxBarcode.Clear();
            textBoxHargaJual.Clear();
            textBoxStok.Clear();
            textBoxNama.Clear();
        }
    }
}
