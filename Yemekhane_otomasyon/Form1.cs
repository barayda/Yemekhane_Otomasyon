using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yemekhane_otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Forms.FrmDepartman frm1;
        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed) { 
            frm1=new Forms.FrmDepartman();
            frm1.MdiParent = this;
            frm1.Show();
            }
        }
        Forms.FrmPersoneller frm2;
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed) { 
            frm2=new Forms.FrmPersoneller();
            frm2.MdiParent = this;
            frm2.Show();
            }
        }
        Forms.FrmPersonelIstatistik frm3;
        private void BtnPersonelIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed) { 
            frm3=new Forms.FrmPersonelIstatistik();
            frm3.MdiParent = this;
            frm3.Show();
            }
        }
        Forms.FrmGörevListesi frm4;
        private void BtnGörevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4=new Forms.FrmGörevListesi();
                new Forms.FrmGörevListesi();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }
        Forms.FrmGörev frm5;
        private void BtnGörevTanimla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new Forms.FrmGörev();
                frm5.Show();
            }
        }
        Forms.FrmGorevDetay frm6;
        private void BtnGörevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed) 
            {
               frm6=new Forms.FrmGorevDetay(); 
               frm6.MdiParent = this;   
               frm6.Show();
            }
        }
        Forms.FrmAnaForm frm7;
        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null || frm7.IsDisposed)
            {
                frm7 = new Forms.FrmAnaForm();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }
        Forms.FrmMenüListele frm8;
        private void btnMenuListele_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm8 == null || frm8.IsDisposed)
            {
                frm8 = new Forms.FrmMenüListele();
                frm8.MdiParent = this;
                frm8.Show();
            }
        }
        Forms.FrmMenuEkle frm9;
        private void BtnMenuEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm9 == null || frm9.IsDisposed)
            {
                frm9 = new Forms.FrmMenuEkle();
                frm9.MdiParent = this;
                frm9.Show();
            }
        }
        Forms.FrmMenuIstatistik frm10;
        private void BtnMenuIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm10 == null || frm10.IsDisposed)
            {
                frm10 = new Forms.FrmMenuIstatistik();
                frm10.MdiParent = this;
                frm10.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblClose.Parent = ribbonControl1;
            LblClose.BackColor = Color.Transparent;
            LblGirisEkrani.Parent = ribbonControl1;
            
          }

        private void LblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LblClose_MouseHover(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(0,0,0);
        }

        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(255,255,255);
        }

        private void LblGirisEkrani_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Giriş Ekranına Dönmek İstediğinize Emin Misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
                Forms.LoginForm frm = new Forms.LoginForm();
                frm.Show();
                
            }
        }

        private void LblGirisEkrani_MouseHover(object sender, EventArgs e)
        {
            LblGirisEkrani.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void LblGirisEkrani_MouseLeave(object sender, EventArgs e)
        {
            LblGirisEkrani.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
