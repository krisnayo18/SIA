using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SIA
{
    public partial class FormDaftarPelanggan : Form
    {
        public FormDaftarPelanggan()
        {
            InitializeComponent();
        }

        //List<Pelanggan> listHasilData = new List<Pelanggan>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarPelanggan_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(0, 0);
            //string hasilBaca = Pelanggan.BacaData("", "", listHasilData);

            //if (hasilBaca == "1")
            //{
            //    //dataGridViewPelanggan.DataSource = null;
            //    dataGridViewPelanggan.DataSource = listHasilData;
            //}
            //else
            //{
            //    dataGridViewPelanggan.DataSource = null;
            //}
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            //FormTambahPelanggan frmTambah = new FormTambahPelanggan();
            //frmTambah.Owner = this;
            //frmTambah.ShowDialog();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            //FormUbahPelanggan frmUbah = new FormUbahPelanggan();
            //frmUbah.Owner = this;
            //frmUbah.ShowDialog();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            //FormHapusPelanggan frmHapus = new FormHapusPelanggan();
            //frmHapus.Owner = this;
            //frmHapus.ShowDialog();
        }

        private void textBoxPelanggan_TextChanged(object sender, EventArgs e)
        {
            //string kriteria = "";
            //if (comboBoxCari.Text == "Kode Pelanggan")
            //{
            //    kriteria = "KodePelanggan";
            //}
            //else if (comboBoxCari.Text == "Telepon")
            //{
            //    kriteria = "Telepon";
            //}
            //else if (comboBoxCari.Text == "Alamat")
            //{
            //    kriteria = "Alamat";
            //}
            //else
            //{
            //    kriteria = "Nama";
            //}

            //listHasilData.Clear();

            //string hasilBaca = Pelanggan.BacaData(kriteria, textBoxCari.Text, listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewPelanggan.DataSource = null;
            //    dataGridViewPelanggan.DataSource = listHasilData;
            //}
        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCari_Click(object sender, EventArgs e)
        {

        }
    }
}
