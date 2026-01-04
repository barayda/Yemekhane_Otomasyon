using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Yemekhane_otomasyon.Entity;

namespace Yemekhane_otomasyon.Forms
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        DBYemekhaneEntities dB = new DBYemekhaneEntities();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string ResimYolu = "";

        void personeller()
        {
            var degerler = from x in dB.Personel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               Departman = x.Departmanlar.Ad,
                               Durum = x.Durum == true ? "Aktif" : "Pasif"
                           };
            gridControl1.DataSource = degerler.Where(x => x.Durum == "Aktif").ToList();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();

            var departmanlar = (from x in dB.Departmanlar
                                select new { x.ID, x.Ad }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ResimYolu = dialog.FileName;
                    pictureEdit1.Image = Image.FromFile(ResimYolu);
                }
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Personel t = new Personel();
                t.Ad = textInfo.ToTitleCase(txtAd.Text.ToLower());
                t.Soyad = textInfo.ToTitleCase(TxtSoyad.Text.ToLower());
                t.Mail = TxtMail.Text;
                t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
                t.Durum = true;

                if (!string.IsNullOrEmpty(ResimYolu))
                {
                    t.Görsel = File.ReadAllBytes(ResimYolu);
                }

                dB.Personel.Add(t);
                dB.SaveChanges();
                XtraMessageBox.Show("Personel başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personeller();
                Temizle();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            int id = int.Parse(txtID.Text);
            var deger = dB.Personel.Find(id);
            if (deger != null)
            {
                deger.Durum = false;
                dB.SaveChanges();
                XtraMessageBox.Show("Personel pasif duruma getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personeller();
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            int id = int.Parse(txtID.Text);
            var deger = dB.Personel.Find(id);
            if (deger != null)
            {
                deger.Ad = textInfo.ToTitleCase(txtAd.Text.ToLower());
                deger.Soyad = textInfo.ToTitleCase(TxtSoyad.Text.ToLower());
                deger.Mail = TxtMail.Text;
                deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());

                if (!string.IsNullOrEmpty(ResimYolu))
                {
                    deger.Görsel = File.ReadAllBytes(ResimYolu);
                }

                dB.SaveChanges();
                XtraMessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personeller();
                ResimYolu = "";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object idObj = gridView1.GetFocusedRowCellValue("ID");
            if (idObj == null) return;

            txtID.Text = idObj.ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad")?.ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad")?.ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail")?.ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman")?.ToString();

            int id = int.Parse(txtID.Text);
            var personel = dB.Personel.Find(id);

            if (personel != null && personel.Görsel != null)
            {
                using (MemoryStream ms = new MemoryStream(personel.Görsel))
                {
                    pictureEdit1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureEdit1.Image = null;
            }
        }

        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            pictureEdit1.Image = null;
            ResimYolu = "";
        }
    }
}