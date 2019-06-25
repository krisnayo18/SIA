using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryTransaksi;

namespace SistemAkuntansi
{
    public partial class FormDaftarNotaBeli : Form
    {
        public FormDaftarNotaBeli()
        {
            InitializeComponent();
        }

        List<NotaPembelian> listHasilData = new List<NotaPembelian>();
        string kriteria = "";
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarNotaBeli_Load(object sender, EventArgs e)
        {

            comboBoxCari.Items.AddRange(new string[] { "No Nota","ID Supplier","Nama Supplier","Alamat Supplier",
                "Diskon","Total Harga","Batas Pelunasan",
                "Batas Diskon","Tanggal Pembelian","Status","Keterangan" });

            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = NotaPembelian.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    string total = listHasilData[i].TotalHarga.ToString("RP 0,###");
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPembelian, listHasilData[i].Supplier.IdSupplier,
                        listHasilData[i].Supplier.Nama, listHasilData[i].Supplier.Alamat, listHasilData[i].Diskon,
                        total, listHasilData[i].TglBatasPelunasan.ToString("dddd, dd MMMM yyyy"), 
                        listHasilData[i].TglBatasDiskon.ToString("dddd, dd MMMM yyyy"),
                        listHasilData[i].TglBeli.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Status, listHasilData[i].Keterangan);
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli form = new FormTambahNotaBeli();
            form.Owner = this;
            form.Show();
        }
        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("noNotaPembelian", "No Nota");
            dataGridViewNota.Columns.Add("idSupplier", "No Supplier");
            dataGridViewNota.Columns.Add("NamaSupplier", "Nama Supplier");
            dataGridViewNota.Columns.Add("AlamatSupplier", "Alamat Supplier");
            dataGridViewNota.Columns.Add("diskon", "Diskon");
            dataGridViewNota.Columns.Add("totalHarga", "Total Harga");
            dataGridViewNota.Columns.Add("tglBatasPelunasan", "Batas Pelunasan");
            dataGridViewNota.Columns.Add("tglBatasDiskon", "Batas Diskon");
            dataGridViewNota.Columns.Add("tglBeli", "Tanggal Pembelian");
            dataGridViewNota.Columns.Add("status", "Status");
            dataGridViewNota.Columns.Add("keterangan", "Keterangan");

            dataGridViewNota.Columns["noNotaPembelian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["idSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["AlamatSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["diskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["totalHarga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasDiskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void buttoncetak_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaPembelian.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_Beli.txt");
            if (hasilCetak == "1") MessageBox.Show("Nota telah tercetak");
            else MessageBox.Show("Nota beli gagal dicetak. Pesan kesalahan : " + hasilCetak);
        }

        private void textBoxNotaBeli_TextChanged(object sender, EventArgs e)
        {
            if(textBoxCari.Text == "")
            {
                string hasilBaca = NotaPembelian.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewNota.Rows.Clear();

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        string total = listHasilData[i].TotalHarga.ToString("RP 0,###");
                        dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPembelian, listHasilData[i].Supplier.IdSupplier,
                            listHasilData[i].Supplier.Nama, listHasilData[i].Supplier.Alamat, listHasilData[i].Diskon,
                            total, listHasilData[i].TglBatasPelunasan.ToString("dddd, dd MMMM yyyy"),
                            listHasilData[i].TglBatasDiskon.ToString("dddd, dd MMMM yyyy"),
                            listHasilData[i].TglBeli.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Status, listHasilData[i].Keterangan);
                    }
                }
            }
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "No Nota") kriteria = "noNotaPembelian";
            else if (comboBoxCari.Text == "ID Supplier") kriteria = "idSupplier";
            else if (comboBoxCari.Text == "Nama Supplier") kriteria = "namaSupplier";
            else if (comboBoxCari.Text == "Alamat Supplier") kriteria = "alamatSupplier";
            else if (comboBoxCari.Text == "Diskon") kriteria = "diskon";
            else if (comboBoxCari.Text == "Total Harga") kriteria = "totalHarga";
            else if (comboBoxCari.Text == "Batas Pelunasan") kriteria = "tglBatasPelunasan";
            else if (comboBoxCari.Text == "Batas Diskon") kriteria = "tglBatasDiskon";
            else if (comboBoxCari.Text == "Tanggal Pembelian") kriteria = "tglBeli";
            else if (comboBoxCari.Text == "Status") kriteria = "status";
            else if (comboBoxCari.Text == "Keterangan") kriteria = "keterangan";


            string hasilBaca = NotaPembelian.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    string total = listHasilData[i].TotalHarga.ToString("RP 0,###");
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPembelian, listHasilData[i].Supplier.IdSupplier,
                        listHasilData[i].Supplier.Nama, listHasilData[i].Supplier.Alamat, listHasilData[i].Diskon,
                        total, listHasilData[i].TglBatasPelunasan.ToString("dddd, dd MMMM yyyy"),
                        listHasilData[i].TglBatasDiskon.ToString("dddd, dd MMMM yyyy"),
                        listHasilData[i].TglBeli.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Status, listHasilData[i].Keterangan);
                }
            }
        }

        private void comboBoxCari_TextChanged(object sender, EventArgs e)
        {
            string hasilBaca = NotaPembelian.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    string total = listHasilData[i].TotalHarga.ToString("RP 0,###");
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPembelian, listHasilData[i].Supplier.IdSupplier,
                        listHasilData[i].Supplier.Nama, listHasilData[i].Supplier.Alamat, listHasilData[i].Diskon,
                        total, listHasilData[i].TglBatasPelunasan.ToString("dddd, dd MMMM yyyy"),
                        listHasilData[i].TglBatasDiskon.ToString("dddd, dd MMMM yyyy"),
                        listHasilData[i].TglBeli.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Status, listHasilData[i].Keterangan);
                }
            }
        }
    } 
}
