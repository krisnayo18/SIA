using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SistemAkuntansi
{
    public partial class FormTambahJobOrder : Form
    {
        public FormTambahJobOrder()
        {
            InitializeComponent();
        }

        //List<Kategori> listDataKategori = new List<Kategori>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormDaftarBarang fdb = (FormDaftarBarang)this.Owner; 

            //Kategori kategoriBrng = listDataKategori[comboBoxKodeBarang.SelectedIndex];
            //Barang br = new Barang(textBoxQuantity.Text, textBoxDirectLabor.Text, textBoxNama.Text, int.Parse(textBoxHargaJual.Text), int.Parse(textBoxStok.Text), kategoriBrng);
            //string hasilTambah = Barang.TambahData(br);

            
            //if (hasilTambah == "1")
            //{
            //    MessageBox.Show("Data barang telah tersimpan.", "Informasi");

            //    textBoxQuantity.Clear();
            //    textBoxDirectLabor.Clear();
            //    textBoxHargaJual.Clear();
            //    textBoxStok.Clear();
            //    textBoxNama.Clear();

            //    fdb.FormDaftarBarang_Load(sender, e);
            //}
            //else
            //{
            //    MessageBox.Show("Gagal menambah kategori. Pesan kesalahan : " + hasilTambah);
            //}
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(881, 26);
            //textBoxQuantity.MaxLength = 5;
            //textBoxDirectLabor.MaxLength = 13;
            //textBoxNama.MaxLength = 45;

            //comboBoxKodeBarang.DropDownStyle = ComboBoxStyle.DropDownList;

            //textBoxQuantity.Enabled = false;

            //string hasilBaca = Kategori.BacaData("", "", listDataKategori);

            //if (hasilBaca == "1")
            //{
            //    comboBoxKodeBarang.Items.Clear();
            //    for (int i = 0; i < listDataKategori.Count; i++)
            //    {
            //        comboBoxKodeBarang.Items.Add(listDataKategori[i].KodeKategori + " - " + listDataKategori[i].Nama);
            //    }
            //}
            //else
            //{
            //    comboBoxKodeBarang.Items.Clear();
            //}
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string kodeKategori = comboBoxKodeBarang.Text.Substring(0, 2);
            //string kodeTerbaru;

            //string hasilGenerate = Barang.GenerateCode(kodeKategori, out kodeTerbaru);

            //if (hasilGenerate == "1")
            //{
            //    textBoxQuantity.Text = kodeTerbaru;

            //    textBoxDirectLabor.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            //}
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            //textBoxQuantity.Clear();
            //textBoxDirectLabor.Clear();
            //textBoxHargaJual.Clear();
            //textBoxStok.Clear();
            //textBoxNama.Clear();
        }
    }
}
