﻿using System;
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
                         saldo.ToString("RP 0,###"));
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
    }
}
