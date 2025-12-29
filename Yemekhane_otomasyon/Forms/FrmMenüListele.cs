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
using Yemekhane_otomasyon.Forms;

namespace Yemekhane_otomasyon.Forms
{
    public partial class FrmMenüListele : Form
    {
        public FrmMenüListele()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();

        private void FrmMenüListele_Load(object sender, EventArgs e)
        {
            // Grid Wiew Ekranı Kod Kısmı : 
            var ogunListesi = (from x in db.Ogün
                               select new
                               {
                                   ID = x.ID,
                                   Öğünler = x.Ad
                               }).ToList();

            var tumuSecenegi = new { ID = 0, Öğünler = "Tüm Öğünler" };
            var sonListe = Enumerable.Repeat(tumuSecenegi, 1).ToList();
            sonListe.AddRange(ogunListesi);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Öğünler";
            lookUpEdit1.Properties.DataSource = sonListe;
            lookUpEdit1.EditValue = 0;


            DateTime tdy = DateTime.Today;

            // Kahvaltı Paneli :

            LblKahvaltıAnaYemek.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID==1).Select(x => x.AnaYemek).FirstOrDefault() ?? "------").ToString();
            LblKahvaltıYanYemek.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x => x.YanYemek).FirstOrDefault() ?? "------").ToString();
            LblKahvaltıAraSıcak.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x => x.AraSıcak).FirstOrDefault() ?? "------").ToString();

            // Öğlen Yemeği Paneli :

            LblOglenAnaYemek.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.AnaYemek).FirstOrDefault() ?? "------").ToString();
            LblOglenYanYemek.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.YanYemek).FirstOrDefault() ?? "------").ToString();
            LblOglenAraSicak.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.AraSıcak).FirstOrDefault() ?? "------").ToString();
            LblOglenTatli.Text =  (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.Tatli).FirstOrDefault() ?? "------").ToString();
            LblOglenSalata.Text =  (db.Menü.Where(x=>x.Tarih==tdy && x.OgunID==2).Select(x=>x.Salata).FirstOrDefault()??"------").ToString();

            // Akşam Yemeği Paneli :

            LblAksamAnaYemek.Text =(db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.AnaYemek).FirstOrDefault() ?? "------").ToString();
            LblAksamYanYemek.Text =(db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.YanYemek).FirstOrDefault() ?? "------").ToString();
            LblAksamAraSicak.Text =(db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.AraSıcak).FirstOrDefault() ?? "------").ToString();
            LblAksamTatli.Text =(db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.Tatli).FirstOrDefault() ?? "------").ToString();
            LblAksamSalata.Text =(db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.Salata).FirstOrDefault() ?? "------").ToString();

            // Menü Tüketim Paneli :

            LblKahvaltiTüketim.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x=>x.Kapasite).Sum()).ToString();
            LblOglenTuketim.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.Kapasite).Sum()).ToString();
            LblAksamTuketim.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.Kapasite).Sum()).ToString();
            LblKahvaltiTuketim1.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x => x.YiyenKisiSayisi).Sum()).ToString();
            LblOglenTuketim1.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.YiyenKisiSayisi).Sum()).ToString();
            LblAksamTuketim1.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.YiyenKisiSayisi).Sum()).ToString();
            LblToplamTuketim.Text = (db.Menü.Where(x => x.Tarih == tdy ).Select(x => x.Kapasite).Sum()).ToString();
            LblToplamTuketim1.Text = (db.Menü.Where(x => x.Tarih == tdy ).Select(x => x.YiyenKisiSayisi).Sum()).ToString();



        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            DateTime? secilenTarih = OgunTarih.EditValue as DateTime?;
            int secilenOgunID = lookUpEdit1.EditValue != null ? Convert.ToInt32(lookUpEdit1.EditValue) : 0;
            var sorgu = db.Menü.AsQueryable();
            if (secilenTarih.HasValue)
            {
                sorgu = sorgu.Where(x => x.Tarih.Value.Day == secilenTarih.Value.Day &&
                                         x.Tarih.Value.Month == secilenTarih.Value.Month &&
                                         x.Tarih.Value.Year == secilenTarih.Value.Year);
            }

            if (secilenOgunID > 0)
            {
                sorgu = sorgu.Where(x => x.Ogün.ID == secilenOgunID);
            }
            var filtreliListe = sorgu.Select(x => new
            {
                x.AnaYemek,
                x.YanYemek,
                x.AraSıcak,
                x.Tatli,
                x.Tarih,
                OgunAdi = x.Ogün.Ad
            }).ToList();
            if (filtreliListe.Count > 0)
            {
                gridControl2.DataSource = filtreliListe;
            }
            else
            {
                gridControl2.DataSource = null;
                XtraMessageBox.Show("Aradığınız kriterlere uygun bir menü bulunamadı.",
                                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
