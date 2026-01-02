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

namespace Yemekhane_otomasyon.PersonelForm
{
    public partial class YemekhaneEkle : Form
    {
        public YemekhaneEkle()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Yemekhaneler t = new Yemekhaneler();
                if (!string.IsNullOrWhiteSpace(TxtSirketAdi.Text))
                {
                    t.Ad = TxtSirketAdi.Text;
                }
                t.Yetkili = string.IsNullOrWhiteSpace(TxtYetkiliKisi.Text) ? null : TxtYetkiliKisi.Text;
                t.Telefon = string.IsNullOrWhiteSpace(TxtTelefon.Text) ? null : TxtTelefon.Text;
                t.Mail = string.IsNullOrWhiteSpace(TxtMail.Text) ? null : TxtMail.Text;
                t.Sektör = string.IsNullOrWhiteSpace(TxtSektor.Text) ? null : TxtSektor.Text;
                t.İl = string.IsNullOrWhiteSpace(Txtil.Text) ? null : Txtil.Text;
                t.ilce = string.IsNullOrWhiteSpace(Txtilce.Text) ? null : Txtilce.Text;
                t.Adres = string.IsNullOrWhiteSpace(TxtAdres.Text) ? null : TxtAdres.Text;
                db.Yemekhaneler.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yemekhane başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlanlariTemizle();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            AlanlariTemizle();
        }
        private void YemekhaneGuncelle()
        {
            var sektor = db.Yemekhaneler
                .Select(x => new {SektörAdı=x.Sektör})
                .Distinct()
                .ToList();

            var il = db.Yemekhaneler
                .Select(x => new { İlAdı = x.İl })
                .Distinct()
                .ToList();
            var ilce = db.Yemekhaneler
                .Select(x => new { İlçeAdı = x.ilce })
                .Distinct()
                .ToList();
            TxtSektor.Properties.DataSource = sektor;
            TxtSektor.Properties.DisplayMember = "SektörAdı";
            TxtSektor.Properties.ValueMember = "SektörAdı";
            Txtil.Properties.DataSource = il;
            Txtil.Properties.DisplayMember = "İlAdı";
            Txtil.Properties.ValueMember = "İlAdı";
            Txtilce.Properties.DataSource = ilce;
            Txtilce.Properties.DisplayMember = "İlçeAdı";
            Txtilce.Properties.ValueMember = "İlçeAdı";
        }
        private void AlanlariTemizle()
        {
            TxtSirketAdi.Text = "";
            TxtYetkiliKisi.Text = "";
            TxtTelefon.Text = "";
            TxtMail.Text = "";
            TxtSektor.Text = "";
            Txtil.Text = "";
            Txtilce.Text = "";
            TxtAdres.Text = "";
        }

        private void YemekhaneEkle_Load(object sender, EventArgs e)
        {
           YemekhaneGuncelle();
        }

    }
}
