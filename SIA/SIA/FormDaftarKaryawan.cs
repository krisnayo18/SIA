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
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        
        
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
           
        }

       

        public void FormDaftarPegawai_Load(object sender, EventArgs e)
        {
           
        }

        private void textBoxPegawai_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxPegawai.Text == "ID Karyawan")
            {
                hasilCari = "P.idkaryawan";
            }
            else if (comboBoxPegawai.Text == "Nama Karyawan")
            {
                hasilCari = "P.nama";
            }
            else if (comboBoxPegawai.Text == "Jenis Kelamin")
            {
                hasilCari = "P.gender";
            }
            else if (comboBoxPegawai.Text == "Alamat")
            {
                hasilCari = "P.alamat";
            }
            else if (comboBoxPegawai.Text == "Gaji")
            {
                hasilCari = "P.gaji";
            }
            else if (comboBoxPegawai.Text == "Nomor Telepon")
            {
                hasilCari = "P.noTelepon";
            }

           
        }
        private void FormatDataGrid()
        {
            dataGridViewPegawai.Columns.Clear();

            dataGridViewPegawai.Columns.Add("idkaryawan", "ID Karyawan");
            dataGridViewPegawai.Columns.Add("nama", "Nama Karyawan");
            dataGridViewPegawai.Columns.Add("gender", "Jenis Kelamin");
            dataGridViewPegawai.Columns.Add("alamat", "Alamat");
            dataGridViewPegawai.Columns.Add("noTelepon", "Nomor Telepon");
            dataGridViewPegawai.Columns.Add("gaji", "Gaji");

            dataGridViewPegawai.Columns["idkaryawan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["noTelepon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
