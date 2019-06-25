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
    public partial class FormLaporanNeraca : Form
    {
        public FormLaporanNeraca()
        {
            InitializeComponent();
        }
        List<Laporan> listHasilData = new List<Laporan>();
        private void FormatDataGrid()
        {
            dataGridViewNeraca.Columns.Clear();

            dataGridViewNeraca.Columns.Add("kelompok", "Kelompok Akun");
            dataGridViewNeraca.Columns.Add("nama", "Nama Akun");
            dataGridViewNeraca.Columns.Add("saldoAkhir", "Saldo Akhir");


            dataGridViewNeraca.Columns["kelompok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNeraca.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNeraca.Columns["saldoAkhir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dataGridViewNeraca.Columns["saldoAkhir"].DefaultCellStyle.Format = "0,###";

            dataGridViewNeraca.AllowUserToAddRows = false;
        }
        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FormLaporanNeraca_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            labelTotalHutang.Text = Laporan.tampilHutang().ToString("0,###");
            labelTotalEkuitas.Text = Laporan.HitungEkuitasAkhir().ToString("0,###");
            labelAktiva.Text = Laporan.HitungTotalAktiva().ToString("0,###");
            labelPasiva.Text = Laporan.HitungTotalPasiva().ToString("0,###");

            FormatDataGrid();
            string hasilBaca = Laporan.BacaDataNeraca("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNeraca.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    int saldo = int.Parse(listHasilData[i].Periode.IdPeriode);
                    dataGridViewNeraca.Rows.Add(
                        listHasilData[i].IdLaporan,
                        listHasilData[i].Judul,
                        saldo.ToString("0,###")
                        );
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            string bulan = DateTime.Now.Month.ToString();
            string tahun = DateTime.Now.Year.ToString();
            string periode = "Periode 1 " + bulan + " " + tahun + " s/d " + " 30 " + bulan + " " + tahun;
            StreamWriter file = new StreamWriter("Laporan_Neraca.txt");
            //Header
            file.WriteLine("");
            file.WriteLine("".PadRight(22) + "LAPORAN NERACA");
            file.WriteLine("".PadRight(21) + "\"Bagoes Bangets\"");
            file.WriteLine("".PadRight(13) + periode);
            file.WriteLine("");
            file.WriteLine("");

            file.WriteLine("AKTIVA (ASET) :");
            file.Write("".PadRight(5, ' ') + "Kas".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[0].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Piutang".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[1].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Sediaan Bahan Baku".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[2].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Work in Process (WIP)".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[3].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Sediaan Barang Jadi".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[4].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.WriteLine("=".PadRight(55, '='));
            file.Write("".PadRight(22, ' ') + "TOTAL AKTIVA (ASET) :".PadRight(21, ' '));
            file.Write(labelAktiva.Text.PadLeft(12, ' '));
            file.WriteLine("");
            file.WriteLine("");

            file.WriteLine("KEWAJIBAN :");
            file.Write("".PadRight(5, ' ') + "Hutang".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[5].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Hutang Gaji".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[6].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.WriteLine("=".PadRight(55, '='));
            file.Write("".PadRight(29, ' ') + "TOTAL HUTANG :".PadRight(14, ' '));
            file.Write(labelTotalHutang.Text.PadLeft(12, ' '));
            file.WriteLine("");
            file.WriteLine("");

            file.WriteLine("EKUITAS :");
            file.Write("".PadRight(5, ' ') + "Modal".PadRight(38, ' '));
            file.Write(dataGridViewNeraca.Rows[7].Cells["saldoAkhir"].Value.ToString().PadLeft(12, ' '));
            file.WriteLine("");

            file.WriteLine("=".PadRight(55, '='));
            file.Write("".PadRight(28, ' ') + "TOTAL EKUITAS :".PadRight(15, ' '));
            file.Write(labelTotalEkuitas.Text.PadLeft(12, ' '));
            file.WriteLine("");
            file.WriteLine("");

            file.Write("".PadRight(7, ' ') + "TOTAL PASIVA (KEWAJIBAN + EKUITAS) :".PadRight(36, ' '));
            file.Write(labelPasiva.Text.PadLeft(12, ' '));
            file.WriteLine("");

            file.Close();
            MessageBox.Show("Berhasil cetak laporan Neraca", "info");
        }
    }
}
