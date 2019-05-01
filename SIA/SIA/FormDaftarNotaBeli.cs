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

namespace Indomart
{
    public partial class FormDaftarNotaBeli : Form
    {
        List<NotaBeli> listHasilData = new List<NotaBeli>();
        string kriteria = "";
        public FormDaftarNotaBeli()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarNotaBeli_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 401);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = NotaBeli.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaBeli, listHasilData[i].Tanggal, listHasilData[i].Supplier.KodeSupplier, listHasilData[i].Supplier.Nama, listHasilData[i].Supplier.Alamat, listHasilData[i].Pegawai.KodePegawai, listHasilData[i].Pegawai.Nama);
                }
            }
             
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli form = new FormTambahNotaBeli();
            form.Owner = this;
            form.ShowDialog();
        }
        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("NoNota", "No Nota");
            dataGridViewNota.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNota.Columns.Add("KodePelanggan", "Kode Pelanggan");
            dataGridViewNota.Columns.Add("NamaPelanggan", "Nama Pelanggan");
            dataGridViewNota.Columns.Add("AlamatPelanggan", "Alamat Pelanggan");
            dataGridViewNota.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewNota.Columns.Add("NamaPegawai", "Nama Pegawai");

            dataGridViewNota.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["KodePelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["AlamatPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void buttoncetak_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaBeli.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_Beli.txt");
            if (hasilCetak == "1") MessageBox.Show("Nota telah tercetak");
            else MessageBox.Show("Nota beli gagal dicetak. Pesan kesalahan : " + hasilCetak);
        }

        private void textBoxNotaBeli_TextChanged(object sender, EventArgs e)
        {
            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "No. Nota") kriteria = "N.NoNota";
            else if (comboBoxCari.Text == "Tanggal") kriteria = "N.Tanggal";
            else if (comboBoxCari.Text == "Kode Supplier") kriteria = "N.KodeSupplier";
            else if (comboBoxCari.Text == "Nama Supplier") kriteria = "S.Nama";
            else if (comboBoxCari.Text == "Alamat Supplier") kriteria = "S.Alamat";
            else if (comboBoxCari.Text == "Kode Pegawai") kriteria = "N.KodePegawai";
            else if (comboBoxCari.Text == "Nama Pegawai") kriteria = "Pgw.Nama";

            string hasilBaca = NotaBeli.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaBeli, listHasilData[i].Tanggal, listHasilData[i].Supplier.KodeSupplier, listHasilData[i].Supplier.Nama, listHasilData[i].Supplier.Alamat, listHasilData[i].Pegawai.KodePegawai, listHasilData[i].Pegawai.Nama);
                }
            }
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaBeli.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_beli.txt");
            if (hasilCetak == "1") MessageBox.Show("Nota telah tercetak");
            else MessageBox.Show("Nota beli gagal dicetak. Pesan kesalahan : " + hasilCetak);
        }
    } 
}
