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
    public partial class FormDaftarEkspedisi : Form
    {
        
        public FormDaftarEkspedisi()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }
        private void textBoxBarang_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxBarang.Text == "Kode Ekspedisi")
            {
                hasilCari = "E.kodeEkspedisi";
            }
            else if (comboBoxBarang.Text == "Nama")
            {
                hasilCari = "E.nama";
            }
            else if (comboBoxBarang.Text == "Alamat")
            {
                hasilCari = "E.alamat";
            }
            else if (comboBoxBarang.Text == "Nomor Telepon")
            {
                hasilCari = "E.noTelp";
            }
            else if (comboBoxBarang.Text == "Harga")
            {
                hasilCari = "E.harga";
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("kodeEkspedisi", "Kode Ekspedisi");
            dataGridViewBarang.Columns.Add("nama", "Nama Barang");
            dataGridViewBarang.Columns.Add("alamat", "Alamat");
            dataGridViewBarang.Columns.Add("noTelp", "Nomor Telepon");
            dataGridViewBarang.Columns.Add("harga", "Harga");

            dataGridViewBarang.Columns["kodeEkspedisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["noTelp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
