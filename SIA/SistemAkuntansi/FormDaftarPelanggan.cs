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
    public partial class FormDaftarPelanggan : Form
    {
        public FormDaftarPelanggan()
        {
            InitializeComponent();
        }

        

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            
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
