using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                              Departman= x.Departmanlar.Ad,
                               x.Durum
                           };
            gridControl1.DataSource = degerler.Where(x=>x.Durum==true).ToList();
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();
           var departmanlar = (from x in dB.Departmanlar
                              select new
                              {
                                  x.ID,
                                  x.Ad
                              }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Personel t = new Personel();
            t.Ad = textInfo.ToTitleCase(txtAd.Text.ToLower());  
            t.Soyad= textInfo.ToTitleCase(TxtSoyad.Text.ToLower());
            t.Mail = TxtMail.Text;
            t.Görsel= TxtGörsel.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            dB.Personel.Add(t);
            XtraMessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dB.SaveChanges();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x =int.Parse(txtID.Text);
            var deger = dB.Personel.Find(x); 
            deger.Durum = false;
            dB.SaveChanges();
            XtraMessageBox.Show("Personel Silindi. Silinen Personeller Listesinden Tüm Silinmiş Personellere Ulaşabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            //TxtGörsel.Text = gridView1.GetFocusedRowCellValue("Görsel").ToString();
            lookUpEdit1.Text= gridView1.GetFocusedRowCellValue("Departman").ToString();


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = dB.Personel.Find(x);
            deger.Ad = textInfo.ToTitleCase(txtAd.Text.ToLower());
            deger.Soyad = textInfo.ToTitleCase(TxtSoyad.Text.ToLower());
            deger.Mail = TxtMail.Text;
            deger.Görsel= TxtGörsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            dB.SaveChanges();
            XtraMessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();
        }
    }
}
