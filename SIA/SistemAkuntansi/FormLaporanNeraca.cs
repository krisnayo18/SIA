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


            dataGridViewNeraca.AllowUserToAddRows = false;
        }
        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FormLaporanNeraca_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

           
            labelAktiva.Text = Laporan.HitungTotalAktiva().ToString("0,###");
            labelPasiva.Text = Laporan.HitungTotalPasiva().ToString("0,###");

            FormatDataGrid();
            string hasilBaca = Laporan.BacaDataNeraca("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNeraca.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewNeraca.Rows.Add(
                        listHasilData[i].IdLaporan,
                        listHasilData[i].Judul,
                        listHasilData[i].Periode.IdPeriode);
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
