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
    public partial class FormDaftarNotaJual : Form
    {
        public FormDaftarNotaJual()
        {
            InitializeComponent();
        }

        //List<NotaJual> listHasilData = new List<NotaJual>();
        //string kriteria = "";
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual frmTambah = new FormTambahNotaJual();
            frmTambah.Owner = this;
            frmTambah.ShowDialog();
        }

        public void FormDaftarNotaJual_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(0, 0);
            //comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            //FormatDataGrid();

            //string hasilBaca = NotaJual.BacaData("", "", listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewNota.Rows.Clear();

            //    for (int i = 0; i < listHasilData.Count; i++)
            //    {
            //        dataGridViewNota.Rows.Add(listHasilData[i].NoNota, listHasilData[i].Tanggal, listHasilData[i].Pelanggan.KodePelanggan, listHasilData[i].Pelanggan.Nama,listHasilData[i].Pelanggan.Alamat,listHasilData[i].Pegawai.KodePegawai,listHasilData[i].Pegawai.Nama);
            //    }
            //}
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

        private void buttonCari_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNotaJual_TextChanged(object sender, EventArgs e)
        {
            //string nilaiKriteria = textBoxCari.Text;
            //if (comboBoxCari.Text == "No. Nota") kriteria = "N.NoNota";
            //else if (comboBoxCari.Text == "Tanggal") kriteria = "N.Tanggal";
            //else if (comboBoxCari.Text == "Kode Pelanggan") kriteria = "N.KodePelanggan";
            //else if (comboBoxCari.Text == "Nama Pelanggan") kriteria = "Plg.Nama";
            //else if (comboBoxCari.Text == "Alamat Pelanggan") kriteria = "Plg.Alamat";
            //else if (comboBoxCari.Text == "Kode Pegawai") kriteria = "N.KodePegawai";
            //else if (comboBoxCari.Text == "Nama Pegawai") kriteria = "Pgw.Nama";

            //string hasilBaca = NotaJual.BacaData(kriteria, nilaiKriteria, listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewNota.Rows.Clear();

            //    for (int i = 0; i < listHasilData.Count; i++)
            //    {
            //        dataGridViewNota.Rows.Add(listHasilData[i].NoNota, listHasilData[i].Tanggal, listHasilData[i].Pelanggan.KodePelanggan, listHasilData[i].Pelanggan.Nama, listHasilData[i].Pelanggan.Alamat, listHasilData[i].Pegawai.KodePegawai, listHasilData[i].Pegawai.Nama);
            //    }
            //}
        }

        private void buttoncetak_Click(object sender, EventArgs e)
        {
            //cetak semua nota yang memenuhi kriteria user
            //simpan di file daftar_nota_jual.txt
            //string hasilCetak = NotaJual.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_jual.txt");
            //if (hasilCetak == "1") MessageBox.Show("Nota telah tercetak");
            //else MessageBox.Show("Nota jual gagal dicetak. Pesan kesalahan : " + hasilCetak);
        }
    }
}
