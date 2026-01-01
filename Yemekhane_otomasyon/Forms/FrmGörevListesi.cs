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
    public partial class FrmGörevListesi : Form
    {
        public FrmGörevListesi()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db= new DBYemekhaneEntities();
        private void FrmGörevListesi_Load(object sender, EventArgs e)
        {
           gridCtrl1.DataSource = (from x in db.Gorevler
                                       select new
                                       {          
                                          x.ID,
                                          GörevVeren = x.Personel.Ad+" "+x.Personel.Soyad,
                                          x.Aciklama,
                                         GörevAlan=x.Personel.Ad+" "+x.Personel.Soyad,
                                         Durum= x.Durum==true ? "Aktif" :"Pasif"
                                       }).ToList();


            LblAktifGörevSayisi.Text=db.Gorevler.Where(x=>x.Durum==true).Count().ToString();
            LblPasifGörevSayisi.Text = db.Gorevler.Where(x => x.Durum == false).Count().ToString();
            LblToplamDepartman.Text=db.Departmanlar.Count().ToString();

            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler", int.Parse(LblAktifGörevSayisi.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", int.Parse(LblPasifGörevSayisi.Text));
            

        }


    }
}
