using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yemekhane_otomasyon.PersonelForm
{
    public partial class PersonelEkranıi : Form
    {
        public PersonelEkranıi()
        {
            InitializeComponent();
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LblClose_MouseHover(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(255, 255, 255);
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
        PersonelForm.GorevListesi frm1;
        private void BtnGörevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new PersonelForm.GorevListesi();
                frm1.MdiParent = this;
                frm1.Show();
            }
        }
        PersonelForm.GorevListesi frm10;
        private void PersonelEkranıi_Load(object sender, EventArgs e)
        {
            if (!frm10.IsDisposed || frm10 == null)
            {
                frm10 = new PersonelForm.GorevListesi();
                frm1.MdiParent = this;
                frm1.Show();
                LblClose.Parent = ribbonControl1;
                LblClose.BackColor = Color.Transparent;
                LblGirisEkrani.Parent = ribbonControl1;
            }
        }
        PersonelForm.YanitGonder frm2;
        private void BtnGorevYanitla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm2 ==null || frm2.IsDisposed)
            {
                frm2=new PersonelForm.YanitGonder();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }
        PersonelForm.MenuListelecs frm3;
        private void btnMenuListele_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new PersonelForm.MenuListelecs();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }
    }
}
