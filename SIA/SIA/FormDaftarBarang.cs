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
    public partial class FormDaftarBarang : Form
    {
        public FormDaftarBarang()
        {
            InitializeComponent();
        }

        //List<Barang> listHasilData = new List<Barang>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("Barcode", "Barcode");
            dataGridViewBarang.Columns.Add("NamaBarang", "Namae Barang");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Stok", "Stok");
            dataGridViewBarang.Columns.Add("KodeKategori", "Kode Kategori");
            dataGridViewBarang.Columns.Add("NamaKategori", "Nama Kategori");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["KodeKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
        }

        public void FormDaftarBarang_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(0, 0);
            //comboBoxBarang.DropDownStyle = ComboBoxStyle.DropDownList;

            //FormatDataGrid();

            //string hasilBaca = Barang.BacaData("", "", listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewBarang.Rows.Clear();

            //    for(int i=0; i<listHasilData.Count; i++)
            //    {
            //        dataGridViewBarang.Rows.Add(listHasilData[i].KodeBarang, listHasilData[i].Barcode, listHasilData[i].Nama,listHasilData[i].HargaJual ,listHasilData[i].Stok, listHasilData[i].Kategori.KodeKategori, listHasilData[i].Kategori.Nama);
            //    }
            //}
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJobOrder frmTbhBarang = new FormTambahJobOrder();
            frmTbhBarang.Owner = this;
            frmTbhBarang.ShowDialog();
        }

        private void textBoxBarang_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxBarang.Text == "Kode Barang")
            {
                hasilCari = "B.KodeBarang";
            }
            else if (comboBoxBarang.Text == "Barcode")
            {
                hasilCari = "B.Barcode";
            }
            else if (comboBoxBarang.Text == "Nama")
            {
                hasilCari = "B.Nama";
            }
            else if (comboBoxBarang.Text == "Harga Jual")
            {
                hasilCari = "B.HargaJUal";
            }
            else if (comboBoxBarang.Text == "Stok")
            {
                hasilCari = "B.Stok";
            }
            else if (comboBoxBarang.Text == "Kode Kategori")
            {
                hasilCari = "B.KodeKategori";
            }
            else if (comboBoxBarang.Text == "Nama Kategori")
            {
                hasilCari = "K.Nama";
            }

            //string hasilBaca = Barang.BacaData(hasilCari, textBoxBarang.Text, listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewBarang.Rows.Clear();

            //    for (int i = 0; i < listHasilData.Count; i++)
            //    {
            //        dataGridViewBarang.Rows.Add(listHasilData[i].KodeBarang, listHasilData[i].Barcode, listHasilData[i].Nama, listHasilData[i].HargaJual, listHasilData[i].Stok, listHasilData[i].Kategori.KodeKategori, listHasilData[i].Kategori.Nama);
            //    }
            //}
            //else
            //{
            //    dataGridViewBarang.Rows.Clear();
            //}
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            //FormUbahBarang frmUbhBarang = new FormUbahBarang();
            //frmUbhBarang.Owner = this;
            //frmUbhBarang.ShowDialog();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            //FormHapusBarang frmHpsBarang = new FormHapusBarang();
            //frmHpsBarang.Owner = this;
            //frmHpsBarang.ShowDialog();
        }
    }
}
