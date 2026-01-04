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
using Yemekhane_otomasyon.Entity;
using static Yemekhane_otomasyon.Forms.PersonelLogin;
namespace Yemekhane_otomasyon.Forms
{
    public partial class adminLogin : Form
    {

        public adminLogin()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();

        private void LblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LblClose_MouseHover(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(230, 126, 34);
        }

        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void LblBack_Click(object sender, EventArgs e)
        {
            Forms.LoginForm frm = new Forms.LoginForm();
            frm.Show();
            this.Hide();
        }
        private void LblBack_MouseHover(object sender, EventArgs e)
        {
            LblBack.ForeColor = Color.FromArgb(0, 0, 0);
        }
        private void LblBack_MouseLeave(object sender, EventArgs e)
        {
            LblBack.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            var adminvalue = db.Admin.Where(x => x.Kullanici == TxtLogin.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if(adminvalue != null)
            {
                var hatirlananKayit = db.Kullanicilar.FirstOrDefault(x => x.Kullanici == TxtLogin.Text);
                if (hatirlananKayit==null||hatirlananKayit.BeniHatirla==false)
                {
                    DialogResult soru = DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Giriş Bilgileriniz kaydedilsin mi ?",
                    "Bilgileri Kaydet",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    
                    );
                    if (soru == DialogResult.Yes)
                    {
                        BilgileriKaydet(TxtLogin.Text, TxtSifre.Text);
                    }
                }
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş Yaptınız ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        void BilgileriKaydet(string ad, string sifre)
        {
            var kullanici=db.Kullanicilar.FirstOrDefault(x=>x.Kullanici==ad);
            if (kullanici == null)
            {
                Kullanicilar t = new Kullanicilar();
                t.Kullanici = ad;
                t.Sifre = sifre;
                t.BeniHatirla = true;
                db.Kullanicilar.Add(t);
            }
            else 
            { 
                kullanici.Sifre = sifre;
                kullanici.BeniHatirla=true;
            }
            db.SaveChanges();

        }

        private void adminLogin_Load(object sender, EventArgs e)
        {
            var kullaniciListesi = db.Kullanicilar.Select(x => x.Kullanici).ToArray();
            var sonKullanici = db.Kullanicilar.Where(z => z.BeniHatirla == true).OrderByDescending(y => y.ID).FirstOrDefault();
            AutoCompleteStringCollection liste = new AutoCompleteStringCollection();
            liste.AddRange(kullaniciListesi);
            TxtLogin.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtLogin.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TxtLogin.MaskBox.AutoCompleteCustomSource = liste;

            if (sonKullanici != null)
            {
                TxtLogin.Text = sonKullanici.Kullanici;
            }
            
            
        }

       
    }
}
