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
    public partial class FormLaporanEkuitas : Form
    {
        public FormLaporanEkuitas()
        {
            InitializeComponent();
        }
        List<Laporan> listHasilData = new List<Laporan>();
        private void FormDaftarPermintaan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            labelLabaRugi.Text = Laporan.HitungLabaRugi().ToString("0,###");
            labelTotalHarga.Text = Laporan.HitungEkuitasAkhir().ToString("0,###");
            labelEkuitasAwal.Text = Laporan.TampilkanModalAwal().ToString("0,###");

            FormatDataGrid();
            string hasilBaca = Laporan.BacaDataEkuitas("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewEkuitas.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    int saldo = int.Parse(listHasilData[i].Periode.IdPeriode);
                    dataGridViewEkuitas.Rows.Add(
                        listHasilData[i].IdLaporan,
                        listHasilData[i].Judul,
                        saldo.ToString("RP 0,###")
                        );
                    //labelEkuitasAwal.Text = saldo.ToString("0,###");
                }
            }

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewEkuitas.Columns.Clear();

            dataGridViewEkuitas.Columns.Add("kelompok", "Kelompok Akun");
            dataGridViewEkuitas.Columns.Add("nama", "Nama Akun");
            dataGridViewEkuitas.Columns.Add("saldoAkhir", "Saldo Akhir");


            dataGridViewEkuitas.Columns["kelompok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewEkuitas.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewEkuitas.Columns["saldoAkhir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridViewEkuitas.Columns["saldoAkhir"].DefaultCellStyle.Format = "0,###";

            dataGridViewEkuitas.AllowUserToAddRows = false;
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            int hasil = Laporan.TampilkanModalAwal() + Laporan.HitungLabaRugi();
            string bulan = DateTime.Now.Month.ToString();
            string tahun = DateTime.Now.Year.ToString();
            string periode = "Periode 1 " + bulan + " " + tahun + " s/d " + " 30 " + bulan + " " + tahun;
            StreamWriter file = new StreamWriter("Laporan_Ekuitas.txt");
            //Header
            file.WriteLine("");
            file.WriteLine("".PadRight(21) + "LAPORAN EKUITAS");
            file.WriteLine("".PadRight(21) + "\"Bagoes Bangets\"");
            file.WriteLine("".PadRight(13) + periode);
            file.WriteLine("");
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Ekuitas Pemilik per awal periode".PadRight(38, ' '));
            file.Write(labelEkuitasAwal.Text.PadLeft(12, ' '));
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Laba Rugi Tahun Berjalan".PadRight(38, ' '));
            file.Write(Laporan.HitungLabaRugi().ToString("0,###").PadLeft(12, ' '));
            file.WriteLine("");

            file.WriteLine("=".PadRight(55, '='));
            file.Write("".PadRight(5, ' ') + "Ekuitas setelah Laba Rugi".PadRight(38, ' '));
            file.Write(hasil.ToString("0,###").PadLeft(12, ' '));
            file.WriteLine("");
            file.WriteLine("");

            file.Write("".PadRight(5, ' ') + "Penarikan ekuitas pemilik".PadRight(38, ' '));
            file.Write("0".PadLeft(12, ' '));
            file.WriteLine("");
            file.WriteLine("=".PadRight(55, '='));

            file.WriteLine("");
            file.Write("".PadRight(5, ' ') + "Ekuitas pemilik per akhir periode".PadRight(38, ' '));
            file.Write(hasil.ToString("0,###").PadLeft(12, ' '));
            file.WriteLine("");

            file.Close();
            MessageBox.Show("Berhasil cetak laporan Ekuitas", "info");
        }
    }
}
