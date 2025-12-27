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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        TextInfo textInfo=CultureInfo.CurrentCulture.TextInfo;
        // crud --> create, read, update, delete
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        void Listele()
        {
           
            var degerler=(from x in db.Departmanlar
                         select new
                         {
                             x.ID,
                             x.Ad
                         }).ToList();
            gridControl1.DataSource =degerler;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Departmanlar t = new Departmanlar();
            t.Ad = textInfo.ToTitleCase(txtAd.Text.ToLower());  // sadece ilk harfi büyük yapar
            db.Departmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x =int.Parse(txtID.Text);
            var deger = db.Departmanlar.Find(x);
            db.Departmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Departman Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        private void gridView1_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.Departmanlar.Find(x);
            deger.Ad = textInfo.ToTitleCase(txtAd.Text.ToLower());
            db.SaveChanges();
            XtraMessageBox.Show("Departman Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.Departmanlar
                           select new
                           {
                               x.ID,
                               x.Ad
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
