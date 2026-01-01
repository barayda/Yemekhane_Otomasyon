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
namespace Yemekhane_otomasyon.PersonelForm
{
    public partial class MenuListelecs : Form
    {
        public MenuListelecs()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();

        private void MenuListelecs_Load(object sender, EventArgs e)
        {
            DateTime tdy = DateTime.Today;
            LblKahvaltıAnaYemek.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x => x.AnaYemek).FirstOrDefault() ?? "------").ToString();
            LblKahvaltıYanYemek.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x => x.YanYemek).FirstOrDefault() ?? "------").ToString();
            LblKahvaltıAraSıcak.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 1).Select(x => x.AraSıcak).FirstOrDefault() ?? "------").ToString();

            LblOglenAnaYemek.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.AnaYemek).FirstOrDefault() ?? "------").ToString();
            LblOglenYanYemek.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.YanYemek).FirstOrDefault() ?? "------").ToString();
            LblOglenAraSicak.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.AraSıcak).FirstOrDefault() ?? "------").ToString();
            LblOglenTatli.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.Tatli).FirstOrDefault() ?? "------").ToString();
            LblOglenSalata.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 2).Select(x => x.Salata).FirstOrDefault() ?? "------").ToString();


            LblAksamAnaYemek.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.AnaYemek).FirstOrDefault() ?? "------").ToString();
            LblAksamYanYemek.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.YanYemek).FirstOrDefault() ?? "------").ToString();
            LblAksamAraSicak.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.AraSıcak).FirstOrDefault() ?? "------").ToString();
            LblAksamTatli.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.Tatli).FirstOrDefault() ?? "------").ToString();
            LblAksamSalata.Text = (db.Menü.Where(x => x.Tarih == tdy && x.OgunID == 3).Select(x => x.Salata).FirstOrDefault() ?? "------").ToString();

            int aktifKullaniciID = KullaniciOturumu.KullaniciID;
            LblBakiye.Text=((db.Personel.Where(x=>x.ID==aktifKullaniciID).Select(x=>x.bakiye).FirstOrDefault()).ToString())+" TL";
            LblKahvaltıFiyat.Text=((db.Menü.Where(x=>x.OgunID==1).Select(x=>x.Satis).FirstOrDefault()).ToString())+" TL";
            LblOglenFiyat.Text = ((db.Menü.Where(x => x.OgunID == 2).Select(x => x.Satis).FirstOrDefault()).ToString())+" TL";
            LblAksamFiyat.Text = ((db.Menü.Where(x => x.OgunID == 3).Select(x => x.Satis).FirstOrDefault()).ToString())+" TL";

        }
    }
}
