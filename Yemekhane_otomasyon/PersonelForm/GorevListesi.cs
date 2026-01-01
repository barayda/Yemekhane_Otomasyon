using DevExpress.XtraCharts;
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
using static Yemekhane_otomasyon.Forms.PersonelLogin;
namespace Yemekhane_otomasyon.PersonelForm
{
    public partial class GorevListesi : Form
    {
        public GorevListesi()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();
      
        private void Listele2()
        {
            var gorevler = db.Gorevler
        .Where(x => x.Personel1.ID == KullaniciOturumu.KullaniciID)
        .Select(x => new
        {
            x.ID, 
            GörevVeren = x.Personel.Ad + " " + x.Personel.Soyad,
            Görev = x.Aciklama,
            Tarih = x.Tarih,
            TamAciklama = x.GorevDetaylar.FirstOrDefault().Aciklama,
            Durum=x.Durum
        })
        .ToList();

            gridCtrl1.DataSource = gorevler;
        }
        private void IstatistikleriGetir()
        {
            int aktifKullaniciID = KullaniciOturumu.KullaniciID;

            int bekleyenSayisi = db.Gorevler
                .Where(x => x.Personel1.ID == aktifKullaniciID && x.Durum == true)
                .Count();

            int tamamlananSayisi = db.Gorevler
                .Where(x => x.Personel1.ID == aktifKullaniciID && x.Durum == false)
                .Count();

            LblBekleyenGorev.Text = bekleyenSayisi.ToString();
            LblTamanlananGorev.Text = tamamlananSayisi.ToString();
        }
        private void GorevListesi_Load(object sender, EventArgs e)
        {
            Listele2();
            var personel = db.Personel.FirstOrDefault(x => x.ID == KullaniciOturumu.KullaniciID);
            if (personel != null)
            {
                string tamAd = personel.Ad + " " + personel.Soyad;
                LblPersonelAd.Text = tamAd; 
            }
            IstatistikleriGetir();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object deger = gridView1.GetFocusedRowCellValue("TamAciklama");
            object tarih = gridView1.GetFocusedRowCellValue("Tarih");
            object durumObj = gridView1.GetFocusedRowCellValue("Durum");
            string durumMetni = "";
            if (durumObj != null)
            {
                bool durum = (bool)durumObj; 
                durumMetni = durum ? "Görev hala aktif" : "Görev tamamlandı";
            }
            if (deger != null)
            {
                string tarihMetni = tarih != null ? Convert.ToDateTime(tarih).ToShortDateString() : "";
                LblGorevTarih.Text = tarihMetni;
                LblDurumGorev.Text = durumMetni;
                LblAciklama.Text = deger.ToString();
            }
            
        }
    }
}
