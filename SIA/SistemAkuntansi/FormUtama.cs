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
using ClassLibraryJurnal;

namespace SistemAkuntansi
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        


        //public void PengaturanHakAksesMenu(Jabatan pJabatan)
        //{
        //    if (pJabatan.IdJabatan == "J1") //jika jabatan nya pegawai pembelian
        //    {
        //        panelMaster.Visible = false;
        //        buttonPenjualan.Visible = false;
        //        buttonPembelian.Visible = true;
        //    }
        //    else if(pJabatan.IdJabatan == "J2") //jika jabatanya kasir
        //    {
        //        panelMaster.Visible = false;
        //        buttonPenjualan.Visible = true;
        //        buttonPembelian.Visible = false;
        //    }
        //    else if (pJabatan.IdJabatan == "J3") //jika jabatannya manajer
        //    {
        //        panelMaster.Visible = true;
        //        buttonPembelian.Visible = true;
        //        buttonPenjualan.Visible = true;
        //    }
        //}
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelKodePgw.Text = "Kode";
            labelNamaPgw.Text = "GUEST";
            labelJabatan.Text = "Jabatan";
            FormLogin form = new FormLogin();
            form.Owner = this;
            form.ShowDialog();
        }
        private void keluarSistemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormUtama_Load(object sender, EventArgs e)
        {
            

            this.WindowState = FormWindowState.Maximized;
            
            this.IsMdiContainer = true;

            this.Enabled = false;

            FormLogin formLogin = new FormLogin();
            formLogin.Owner = this;
            formLogin.Show();
           
        }

        private void buttonBarang_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarBarang"];
            if (form == null) // jika form ini belum di create sebelumnya
            {

                FormDaftarBarang formBarang = new FormDaftarBarang();
                formBarang.MdiParent = this; // buat form ini 
                formBarang.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonEkspedisi_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarEkspedisi"];
            if (form == null)
            {
                FormDaftarEkspedisi frmEkspedisi = new FormDaftarEkspedisi();
                frmEkspedisi.MdiParent = this;
                frmEkspedisi.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonPelanggan_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPelanggan"];
            if (form == null)
            {
                FormDaftarPelanggan frmPelanggan = new FormDaftarPelanggan();
                frmPelanggan.MdiParent = this;
                frmPelanggan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarSupplier"];
            if (form == null)
            {
                //FormDaftarSupplier formSupplier = new FormDaftarSupplier();
                //formSupplier.MdiParent = this;
                //formSupplier.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonPegawai_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPegawai"];
            if (form == null)
            {
                FormDaftarPegawai formPegawai = new FormDaftarPegawai();
                formPegawai.MdiParent = this;
                formPegawai.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
        private void buttonPenjualan_Click(object sender, EventArgs e)
        {
           
            Form form = Application.OpenForms["FormDaftarNotaJual"];
            if (form == null)
            {
                FormDaftarNotaJual formNotaJual = new FormDaftarNotaJual();
                formNotaJual.MdiParent = this;
                formNotaJual.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
        private void buttonPembelian_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarNotaBeli"];
            if (form == null)
            {
                FormDaftarNotaBeli formNotaBeli = new FormDaftarNotaBeli();
                formNotaBeli.MdiParent = this;
                formNotaBeli.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
        //
        // efek slide
        //
        private void labelTransaksi_Click(object sender, EventArgs e)
        {
            if (panelTransaksi.Height == 25)          
                panelTransaksi.Height = 120;    
            else
                panelTransaksi.Height = 25;
        }

        private void labelMaster_Click(object sender, EventArgs e)
        {
            if(panelMaster.Height == 25)
            {
                panelMaster.Height = 210;
                panelTransaksi.Location = new Point(1, 479);
            }
            else
            {
                panelMaster.Height = 25;
                panelTransaksi.Location = new Point(1, 300);
            }
        }

        private void buttonPelunasan_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPermintaanPembayaran"];
            if (form == null)
            {
                FormDaftarPelunasan fp = new FormDaftarPelunasan();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonJurnal_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJurnal"];
            if (form == null)
            {
                FormDaftarJurnal fp = new FormDaftarJurnal();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}
