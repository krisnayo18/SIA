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
using ClassLibraryJurnal;

namespace SistemAkuntansi
{
    public partial class FormDaftarJobOrder : Form
    {
        public FormDaftarJobOrder()
        {
            InitializeComponent();
        }
        List<JobOrder> listHasilData = new List<JobOrder>();
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJobOrder frmTambahJobOrder = new FormTambahJobOrder();
            frmTambahJobOrder.Owner = this;
            frmTambahJobOrder.ShowDialog();
        }
        private void textBoxBarang_TextChanged(object sender, EventArgs e)
        {
            //string hasilCari = "";
            //if (comboBoxBarang.Text == "Kode Job Order")
            //{
            //    hasilCari = "J.kodeJobOrder";
            //}
            //else if (comboBoxBarang.Text == "Kuantitas")
            //{
            //    hasilCari = "J.quantity";
            //}
            //else if (comboBoxBarang.Text == "Direct Labor")
            //{
            //    hasilCari = "J.directLabor";
            //}
            //else if (comboBoxBarang.Text == "Direct Material")
            //{
            //    hasilCari = "J.directMaterial";
            //}
            //else if (comboBoxBarang.Text == "Overhead Produksi")
            //{
            //    hasilCari = "J.overheadProduksi";
            //}
            //else if (comboBoxBarang.Text == "Tanggal Mulai")
            //{
            //    hasilCari = "J.tanggalMulai";
            //}
            //else if (comboBoxBarang.Text == "Tanggal Selesai")
            //{
            //    hasilCari = "J.tanggalSelesai";
            //}
        }
        private void FormatDataGrid()
        {
            dataGridViewJobOrder.Columns.Clear();

            dataGridViewJobOrder.Columns.Add("kodeJobOrder", "Kode Job Order");
            dataGridViewJobOrder.Columns.Add("noNotaPenjualan", "No Nota Penjualan");
            dataGridViewJobOrder.Columns.Add("item", "Item");
            dataGridViewJobOrder.Columns.Add("quantity", "Quantity");
            dataGridViewJobOrder.Columns.Add("satuan", "Satuan");
            dataGridViewJobOrder.Columns.Add("directLabor", "Direct Labor");
            dataGridViewJobOrder.Columns.Add("directMaterial", "Direct Material");
            dataGridViewJobOrder.Columns.Add("overheadProduksi", "Overhead Produksi");
            dataGridViewJobOrder.Columns.Add("tanggalMulai", "Tanggal Mulai");
            dataGridViewJobOrder.Columns.Add("tanggalSelesai", "Tanggal Selesai");

            dataGridViewJobOrder.Columns["kodeJobOrder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["noNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["directLabor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["directMaterial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["overheadProduksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["tanggalMulai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["tanggalSelesai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewJobOrder.AllowUserToAddRows = false;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarJobOrder_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = JobOrder.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
               dataGridViewJobOrder.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    string directLabor =listHasilData[i].DirectLabor.ToString("RP 0,###");
                    string directMat = listHasilData[i].DirectMaterial.ToString("RP 0,###");
                    string over = listHasilData[i].OverheadProduksi.ToString("RP 0,###");
                    dataGridViewJobOrder.Rows.Add(listHasilData[i].KodeJobOrder, listHasilData[i].NotaPenjualan.NoNotaPenjualan,
                        listHasilData[i].Barang.Nama, listHasilData[i].Quantity, listHasilData[i].Barang.Satuan,
                        directLabor, directMat, over, listHasilData[i].TglMulai.ToString("dddd, dd MMMM yyyy"),
                        listHasilData[i].TglSelesai.ToString("dddd, dd MMMM yyyy"));
                }
            }
        }
    }
}
