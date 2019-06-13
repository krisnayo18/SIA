using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassLibraryJurnal;

namespace SistemAkuntansi
{
    public partial class FormLaporanBukuBesar : Form
    {
        public FormLaporanBukuBesar()
        {
            InitializeComponent();
        }

        List<Laporan> listHasilData = new List<Laporan>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewBukuBesar.Columns.Clear();

            dataGridViewBukuBesar.Columns.Add("kelompok", "Kelompok Akun");
            dataGridViewBukuBesar.Columns.Add("nama", "Nama Akun");
            dataGridViewBukuBesar.Columns.Add("saldoAkhir", "Saldo Akhir");
        
            dataGridViewBukuBesar.Columns["kelompok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBukuBesar.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBukuBesar.Columns["saldoAkhir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dataGridViewBukuBesar.Columns["saldoAkhir"].DefaultCellStyle.Format = "0,###";

            dataGridViewBukuBesar.AllowUserToAddRows = false;
        }

        public void FormDaftarPelanggan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();
            string hasilBaca =  Laporan.BacaDataBukuBesar("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewBukuBesar.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    int total =int.Parse( listHasilData[i].Periode.IdPeriode);
                    dataGridViewBukuBesar.Rows.Add(
                        listHasilData[i].IdLaporan, 
                        listHasilData[i].Judul,
                        total.ToString("RP 0,###") // isinya saldo akhir
                       );
                }
            }
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
