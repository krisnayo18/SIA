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
    public partial class FormDaftarJurnal : Form
    {
        public FormDaftarJurnal()
        {
            InitializeComponent();
        }
        List<Jurnal> listHasilData = new List<Jurnal>();
        string kriteria = "";
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }
        private void FormatDataGrid()
        {
           
            dataGridViewJurnal.Columns.Clear();

            dataGridViewJurnal.Columns.Add("idJurnal", "ID Jurnal");
            dataGridViewJurnal.Columns.Add("tanggal", "Tanggal");
            dataGridViewJurnal.Columns.Add("keterangan", "Keterangan");
            dataGridViewJurnal.Columns.Add("namaAkun", "Nama Akun");
            dataGridViewJurnal.Columns.Add("debet", "Debet");
            dataGridViewJurnal.Columns.Add("kredit", "Kredit");
            dataGridViewJurnal.Columns.Add("nomorBukti", "Nomor Bukti");



            dataGridViewJurnal.Columns["idJurnal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurnal.Columns["tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurnal.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurnal.Columns["namaAkun"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurnal.Columns["debet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurnal.Columns["kredit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurnal.Columns["nomorBukti"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewJurnal.AllowUserToAddRows = false;
        }
        private void FormDaftarJurnal_Load(object sender, EventArgs e)
        {

            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = Jurnal.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewJurnal.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                        dataGridViewJurnal.Rows.Add(listHasilData[i].IdJurnal, listHasilData[i].Tanggal, 
                        listHasilData[i].Transaksi.Keterangan,
                        listHasilData[i].DetilJurnal.Akun.Nama,
                        listHasilData[i].DetilJurnal.Debit,
                        listHasilData[i].DetilJurnal.Kredit, listHasilData[i].NomorBukti);
                   
                }
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "ID Jurnal") kriteria = "idjurnal";
            else if (comboBoxCari.Text == "Tanggal") kriteria = "tanggal";
            else if (comboBoxCari.Text == "Keterangan") kriteria = "keterangan";
            else if (comboBoxCari.Text == "Nama Akun") kriteria = "nama";
            else if (comboBoxCari.Text == "Debet") kriteria = "debet";
            else if (comboBoxCari.Text == "Kredit") kriteria = "kredit";
            else if (comboBoxCari.Text == "Nomor Bukti") kriteria = "nomorbukti";



            string hasilBaca = Jurnal.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewJurnal.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewJurnal.Rows.Add(listHasilData[i].IdJurnal, listHasilData[i].Tanggal,
                      listHasilData[i].Transaksi.Keterangan,
                      listHasilData[i].DetilJurnal.Akun.Nama,
                      listHasilData[i].DetilJurnal.Debit,
                      listHasilData[i].DetilJurnal.Kredit, listHasilData[i].NomorBukti);
                }
            }
        }
    }
}
