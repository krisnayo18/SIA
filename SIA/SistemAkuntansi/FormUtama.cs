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

                FormDaftarSuratJalan formBarang = new FormDaftarSuratJalan();
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
                FormDaftarSuratPermintaan frmEkspedisi = new FormDaftarSuratPermintaan();
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
                FormLaporanBukuBesar frmPelanggan = new FormLaporanBukuBesar();
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
          
        }

        private void labelMaster_Click(object sender, EventArgs e)
        {
            if(panelMaster.Height == 31)
            {
                panelMaster.Height = 215;
                panelTransaksi.Location = new Point(20, 220);
                panelLaporan.Location = new Point(20, 595);
            }
            else
            {
                panelMaster.Height = 31;
                panelTransaksi.Location = new Point(20, 40);
                panelLaporan.Location = new Point(21, 417);
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

        private void buttonBukuBesar_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLaporanBukuBesar"];
            if (form == null)
            {
                FormLaporanBukuBesar fp = new FormLaporanBukuBesar();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonLabaRugi_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLaporanLabaRugi"];
            if (form == null)
            {
                FormLaporanLabaRugi fp = new FormLaporanLabaRugi();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonPerubahanEkuitas_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLaporanEkuitas"];
            if (form == null)
            {
               FormLaporanEkuitas fp = new FormLaporanEkuitas();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonNeraca_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLaporanNeraca"];
            if (form == null)
            {
                FormLaporanNeraca fp = new FormLaporanNeraca();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonTutupPeriode_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Yakin ingin menutup periode ?", "konformasi", MessageBoxButtons.YesNo);
            if(pesan == DialogResult.Yes)
            {
                string status = Periode.TutupPeriode();
                if (status == "1")
                {
                    MessageBox.Show("Berhasil melakukan Tutup Periode Akuntansi");
                }
                else
                {
                    MessageBox.Show(status);
                }
            }
            else
            {
                
            }
                
        }

        private void buttonPembayaran_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPembayaran"];
            if (form == null)
            {
                FormDaftarPembayaran fp = new FormDaftarPembayaran();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonJobOrder_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJobOrder"];
            if (form == null)
            {
                FormDaftarJobOrder fp = new FormDaftarJobOrder();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonSuratPermintaan_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarSuratPermintaan"];
            if (form == null)
            {
                FormDaftarSuratPermintaan fp = new FormDaftarSuratPermintaan();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonSuratJalan_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarSuratJalan"];
            if (form == null)
            {
                FormDaftarSuratJalan fp = new FormDaftarSuratJalan();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonPenerimaan_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPenerimaan"];
            if (form == null)
            {
                FormDaftarPenerimaan fp = new FormDaftarPenerimaan();
                fp.MdiParent = this;
                fp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonPengiriman_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPengiriman"];
            if (form == null)
            {
                FormDaftarPengiriman fp = new FormDaftarPengiriman();
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
