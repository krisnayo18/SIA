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
    }
}
