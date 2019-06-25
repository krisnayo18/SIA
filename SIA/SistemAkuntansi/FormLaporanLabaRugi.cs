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
using System.IO;

namespace SistemAkuntansi
{
    public partial class FormLaporanLabaRugi : Form
    {
        public FormLaporanLabaRugi()
        {
            InitializeComponent();
        }
        List<Laporan> listHasilData = new List<Laporan>();
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLaporanLabaRugi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;
           
            labelTotalHarga.Text = Laporan.HitungLabaRugi().ToString("0,###");
            labelTotalPendapatan.Text = Laporan.HitungTotalPendapatan().ToString("0,###");
            labelTotalBiaya.Text = Laporan.HitungTotalBiaya().ToString("0,###");
            FormatDataGrid();
            string hasilBaca = Laporan.BacaDataLabaRugi("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewLabaRugi.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    int saldo = int.Parse(listHasilData[i].Periode.IdPeriode);
                    dataGridViewLabaRugi.Rows.Add(
                        listHasilData[i].IdLaporan,
                        listHasilData[i].Judul,
                         saldo.ToString("0,###"));
                }
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewLabaRugi.Columns.Clear();

            dataGridViewLabaRugi.Columns.Add("kelompok", "Kelompok Akun");
            dataGridViewLabaRugi.Columns.Add("nama", "Nama Akun");
            dataGridViewLabaRugi.Columns.Add("saldoAkhir", "Saldo Akhir");


            dataGridViewLabaRugi.Columns["kelompok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLabaRugi.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLabaRugi.Columns["saldoAkhir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dataGridViewLabaRugi.Columns["saldoAkhir"].DefaultCellStyle.Format = "0,###";

            dataGridViewLabaRugi.AllowUserToAddRows = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            string bulan = DateTime.Now.Month.ToString();
            string tahun = DateTime.Now.Year.ToString();
            string periode = "Periode 1 " + bulan + " " + tahun + " s/d " + " 30 " + bulan + " " + tahun;
            StreamWriter file = new StreamWriter("Laporan_Laba_Rugi.txt");
            //Header
            file.WriteLine("");
            file.WriteLine("".PadRight(20) + "LAPORAN LABA RUGI");
            file.WriteLine("".PadRight(21) + "\"Bagoes Bangets\"");
            file.WriteLine("".PadRight(13) + periode);
            file.WriteLine("");
            file.WriteLine("");

            file.WriteLine("PENDAPATAN :");
            file.Write("".PadRight(5,' ') + "Penjualan".PadRight(38, ' '));
            file.Write(dataGridViewLabaRugi.Rows[0].Cells["saldoAkhir"].Value.ToString().PadLeft(12,' '));
            file.WriteLine("");

            file.Write("".PadRight(5,' ') + "Retur Penjualan & Penyesuaian Harga".PadRight(38, ' '));
            file.Write(dataGridViewLabaRugi.Rows[1].Cells["saldoAkhir"].Value.ToString().PadLeft(12,' '));
            file.WriteLine("");

            file.WriteLine("=".PadRight(55, '='));
            file.Write("".PadRight(22,' ') + "TOTAL PENDAPATAN :".PadRight(21,' '));
            file.Write(labelTotalPendapatan.Text.PadLeft(12,' '));
            file.WriteLine("");
            file.WriteLine("");

            file.WriteLine("BIAYA :");
            file.Write("".PadRight(5,' ') + "HPP".PadRight(38,' '));
            file.Write(dataGridViewLabaRugi.Rows[2].Cells["saldoAkhir"].Value.ToString().PadLeft(12,' '));
            file.WriteLine("");

            file.Write("".PadRight(5,' ') + "Biaya Gaji ".PadRight(38,' '));
            file.Write(dataGridViewLabaRugi.Rows[3].Cells["saldoAkhir"].Value.ToString().PadLeft(12,' '));
            file.WriteLine("");

            file.Write("".PadRight(5,' ') + "Biaya Transportasi ".PadRight(38,' '));
            file.Write(dataGridViewLabaRugi.Rows[4].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.WriteLine("=".PadRight(55, '='));
            file.Write("".PadRight(27,' ') + "TOTAL BIAYA :".PadRight(16,' '));
            file.Write(labelTotalBiaya.Text.PadLeft(12,' '));
            file.WriteLine("");

            file.WriteLine("");
            file.Write("".PadRight(15,' ') +"LABA/RUGI SEBELUM PAJAK :".PadRight(28,' '));
            file.Write(labelTotalHarga.Text.PadLeft(12,' '));
            file.WriteLine("");

            file.Close();
            MessageBox.Show("Berhasil cetak laporan laba rugi", "info");
        }
    }
}
