using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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

namespace Yemekhane_otomasyon.Forms
{
    public partial class FrmGörev : Form
    {
        public FrmGörev()
        {
            InitializeComponent();
        }
        
        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Gorevler t=new Gorevler();
            t.Aciklama=txtAciklama.Text;
            t.Durum = true;
            t.GörevAlan = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Tarih = DateTime.Parse(txtTarih.Text);
            t.GörevVeren = int.Parse(txtGorevVeren.Text);
            db.Gorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void FrmGörev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.Personel
                                select new
                                {
                                    x.ID,
                                   AdSoyad= x.Ad +" "+x.Soyad,
                                   Departman=x.Departmanlar.Ad
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
            lookUpEdit1.Properties.DisplayMember = "Departman";
            lookUpEdit1.Properties.DataSource = degerler;
           
        }
    }
}
