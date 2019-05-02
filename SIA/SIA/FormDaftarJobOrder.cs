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
    public partial class FormDaftarJobOrder : Form
    {
        public FormDaftarJobOrder()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJobOrder frmTambahJobOrder = new FormTambahJobOrder();
            frmTambahJobOrder.Owner = this;
            frmTambahJobOrder.ShowDialog();
        }
        private void textBoxBarang_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxBarang.Text == "Kode Job Order")
            {
                hasilCari = "J.kodeJobOrder";
            }
            else if (comboBoxBarang.Text == "Kuantitas")
            {
                hasilCari = "J.quantity";
            }
            else if (comboBoxBarang.Text == "Direct Labor")
            {
                hasilCari = "J.directLabor";
            }
            else if (comboBoxBarang.Text == "Direct Material")
            {
                hasilCari = "J.directMaterial";
            }
            else if (comboBoxBarang.Text == "Overhead Produksi")
            {
                hasilCari = "J.overheadProduksi";
            }
            else if (comboBoxBarang.Text == "Tanggal Mulai")
            {
                hasilCari = "J.tanggalMulai";
            }
            else if (comboBoxBarang.Text == "Tanggal Selesai")
            {
                hasilCari = "J.tanggalSelesai";
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("kodeJobOrder", "Kode Job Order");
            dataGridViewBarang.Columns.Add("quantity", "Kuantitas");
            dataGridViewBarang.Columns.Add("directLabor", "Direct Labor");
            dataGridViewBarang.Columns.Add("directMaterial", "Direct Material");
            dataGridViewBarang.Columns.Add("overheadProduksi", "Overhead Produksi");
            dataGridViewBarang.Columns.Add("tanggalMulai", "Tanggal Mulai");
            dataGridViewBarang.Columns.Add("tanggalSelesai", "Tanggal Selesai");

            dataGridViewBarang.Columns["kodeJobOrder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["directLabor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["directMaterial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["overheadProduksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["tanggalMulai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["tanggalSelesai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

    }
}
