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
    public partial class GorevIstatistikleri : Form
    {
        public GorevIstatistikleri()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();
        DateTime tdy = DateTime.Today;
        
        void gorevler()
        {
            var degerler = from x in db.Gorevler
                           select new
                           {
                               x.ID,
                               x.Aciklama,
                               GörevVeren = x.Personel.Ad + " " + x.Personel.Soyad,
                               GörevAlan = x.Personel1.Ad + " " + x.Personel1.Soyad,
                               Durum = x.Durum == true ? "Tamamlandı" : "Tamamlanmadı"
                           };
            gridControl1.DataSource = degerler.ToList();

        }
        private void GorevIstatistikleri_Load(object sender, EventArgs e)
        {
            gorevler();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var secilenIdStr = gridView1.GetFocusedRowCellValue("ID")?.ToString();

            if (string.IsNullOrEmpty(secilenIdStr)) return;

            int sID = int.Parse(secilenIdStr);

            var tarihObj = gridView1.GetFocusedRowCellValue("Tarih");
            if (tarihObj != null)
            {
                DateTime gorevTarihi = Convert.ToDateTime(tarihObj);
                TimeSpan fark = DateTime.Today - gorevTarihi;
                double toplamgun = Math.Abs(fark.TotalDays);
                LblGorevSuresi.Text = toplamgun.ToString("0") + " Gün";
            }

            var aciklama = db.GorevDetaylar
                             .Where(x => x.Gorev == sID)
                             .Select(x => x.Aciklama)
                             .FirstOrDefault();
            LblAciklama.Text = aciklama ?? "Henüz bir açıklama girilmedi.";

            var gorev = db.Gorevler.FirstOrDefault(x => x.ID == sID);
            if (gorev != null && gorev.Personel1 != null)
            {
                int pID = gorev.Personel1.ID;
                LblPersonelAd.Text = gorev.Personel1.Ad + " " + gorev.Personel1.Soyad;

                if (gorev.Personel1.İseBaslamaTarihi != null)
                {
                    TimeSpan fark2 = DateTime.Today - Convert.ToDateTime(gorev.Personel1.İseBaslamaTarihi);
                    LblCalismaSuresi.Text = fark2.TotalDays.ToString("0") + " Gün";
                }

                int tamamlanan = db.Gorevler.Count(x => x.GörevAlan == pID && x.Durum == true);
                LblTamamlananGorevSayisi.Text = tamamlanan.ToString();
            }
        }
    }
}
