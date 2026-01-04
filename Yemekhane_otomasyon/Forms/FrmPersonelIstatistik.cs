using DevExpress.LookAndFeel;
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
    public partial class FrmPersonelIstatistik : Form
    {
        public FrmPersonelIstatistik()
        {
            InitializeComponent();
        }
        Entity.DBYemekhaneEntities db=new Entity.DBYemekhaneEntities();
        private void FrmPersonelIstatistik_Load(object sender, EventArgs e)
        {
            LblToplamDepartman.Text = db.Departmanlar.Count().ToString(); //Toplam departman sayısı

            LblToplamYemekhane.Text=db.Yemekhaneler.Count().ToString();   //Toplam yemekhane sayısı

            LblToplamPersonel.Text=db.Personel.Count().ToString();        //Toplam personel sayısı   

            lblAktifİs.Text=db.Gorevler.Count(x=>x.Durum==true).ToString();//Aktif iş sayısı

            lblPasifİs.Text=db.Gorevler.Count(x=>x.Durum==false).ToString();//Pasif iş sayısı

            lblSonGörev.Text = db.Gorevler.OrderByDescending(x=>x.ID).Select(x => x.Aciklama).FirstOrDefault();//Son görev 

            var d = db.Gorevler.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault(); //Son görev Detayları

            var görevVerenID = db.Gorevler
                .OrderByDescending(x => x.ID)
                .Where(x => x.ID == d)
                .Select(x => x.GörevVeren)
                .FirstOrDefault();

            var görevAlanID = db.Gorevler
                .OrderByDescending(x => x.ID)
                .Where(x => x.ID == d)
                .Select(x => x.GörevAlan)
                .FirstOrDefault();

            LblSonGörevDetayi.Text= db.Gorevler.OrderByDescending(x => x.ID)
                .Select(x =>"Görev Veren : "+ db.Personel.Where(y=>y.ID==görevVerenID).Select(z=>z.Ad +" "+z.Soyad).FirstOrDefault()
                +"\n"+"Görev Tarihi : "+x.Tarih+
                "\n"+"Görev Alan : " +db.Personel.Where(y=>y.ID==görevAlanID).Select(z=>z.Ad+" "+z.Soyad).FirstOrDefault())
                .FirstOrDefault().ToString(); 

            LblSehirSayisi.Text = db.Yemekhaneler.Select(x=>x.İl).Distinct().Count().ToString();//Yemekhane bulunan şehir sayısı

            LblSektör.Text=db.Yemekhaneler.Select(x=>x.Sektör).Distinct().Count().ToString();//Yemekhane bulunan sektör sayısı

            DateTime bugun=DateTime.Today;
            LblBugünAcilanGörevler.Text=db.Gorevler.Count(x=>x.Tarih==bugun).ToString();//Bugün açılan görev sayısı

            var d1  = db.Gorevler.Where(x=>x.Tarih.Value.Month==bugun.Month).GroupBy(x=>x.GörevAlan).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();//Ayın personeli
            var adSoyad = db.Personel
                     .Where(x => x.ID == d1)
                     .Select(y => y.Ad + " " + y.Soyad)
                     .FirstOrDefault();
            LblAyinPersoneli.Text = adSoyad;

            LblAyinDepartmani.Text = db.Departmanlar.Where(x => x.ID==db.Personel //Ayın personelinin departmanı
            .Where(t=>t.ID==d1).Select(z=>z.Departman).FirstOrDefault())
                .Select(y => y.Ad).FirstOrDefault().ToString();
            

        }

    
    }
}
