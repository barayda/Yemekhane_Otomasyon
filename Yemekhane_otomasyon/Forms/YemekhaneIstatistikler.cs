using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.XtraCharts;
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
    public partial class YemekhaneIstatistikler : Form
    {
        public YemekhaneIstatistikler()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        void Degerler()
        {
            gridCtrl1.DataSource = db.Yemekhaneler
                .GroupBy(x => x.Ad)
                .Select(y => new
                {
                    Ad = y.Key,
                    YemekhaneSayisi = y.Count()
                }).ToList();

        }

        private void YemekhaneIstatistikler_Load(object sender, EventArgs e)
        {
            Degerler();
            var ilkFirma=gridView1.GetFocusedRowCellValue("Ad")?.ToString();
            if (!string.IsNullOrEmpty(ilkFirma))
            {
                AylikFirmaGrafiği(ilkFirma);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var secilenDeger = gridView1.GetFocusedRowCellValue("Ad")?.ToString();
            if (string.IsNullOrEmpty(secilenDeger)) return;

            LblSecilenSehir.Text = secilenDeger;

            var yemekhaneBilgi = db.Yemekhaneler
                .Where(x => x.Ad == secilenDeger)
                .FirstOrDefault();

            if (yemekhaneBilgi != null)
            {
                LblYetkiliKisi.Text = string.IsNullOrEmpty(yemekhaneBilgi.Yetkili) ? "-----" : yemekhaneBilgi.Yetkili;
                LblTelefonNo.Text = string.IsNullOrEmpty(yemekhaneBilgi.Telefon) ? "-----" : yemekhaneBilgi.Telefon;
                LblSektor.Text = string.IsNullOrEmpty(yemekhaneBilgi.Sektör) ? "-----" : yemekhaneBilgi.Sektör;
                LblMail.Text = string.IsNullOrEmpty(yemekhaneBilgi.Mail) ? "-----" : yemekhaneBilgi.Mail;

                decimal gelir = yemekhaneBilgi.Gelir ?? 0;
                decimal maliyet = yemekhaneBilgi.Maliyet ?? 0;
                decimal kar = yemekhaneBilgi.Kar ?? 0;
                LblGelir.Text = gelir == 0 ? "-----" : gelir.ToString("N2") + " ₺";
                LblMaliyet.Text = maliyet == 0 ? "-----" : maliyet.ToString("N2") + " ₺";
                LblKarZarar.Text = kar.ToString("N2") + " ₺";
                LblKarZarar.ForeColor = kar >= 0 ? Color.Blue : Color.Red;
            }

            decimal secilenKar = db.Yemekhaneler.Where(x => x.Ad == secilenDeger).Sum(x => (decimal?)x.Kar) ?? 0;
            var digerSehirKarlari = db.Yemekhaneler
                .Where(x => x.Ad != secilenDeger)
                .GroupBy(x => x.Ad)
                .Select(g => g.Sum(x => (decimal?)x.Kar) ?? 0)
                .ToList();

            if (digerSehirKarlari.Any())
            {
                decimal genelOrtalama = digerSehirKarlari.Average();
                if (genelOrtalama != 0)
                {
                    decimal yuzdeFark = ((secilenKar - genelOrtalama) / Math.Abs(genelOrtalama)) * 100;

                    if (yuzdeFark > 0)
                    {
                        Lblİliski.Text = $"{secilenDeger}, diğerlerine göre %{yuzdeFark:N2} daha karlı.";
                        Lblİliski.ForeColor = Color.FromArgb(26, 188, 156);
                    }
                    else
                    {
                        Lblİliski.Text = $"{secilenDeger}, diğerlerine göre %{Math.Abs(yuzdeFark):N2} daha geride.";
                        Lblİliski.ForeColor = Color.Red;
                    }
                }
            }
            if (!string.IsNullOrEmpty(secilenDeger))
            {
                AylikFirmaGrafiği(secilenDeger);
            }
        }

        void AylikFirmaGrafiği(string firmaAdi)
        {
            ChartControl1.Series["Gelir"].Points.Clear();
            ChartControl1.Series["Maliyet"].Points.Clear();
            var rapor = db.Yemekhaneler
                .Where(x => x.Ad == firmaAdi)
                .GroupBy(x => x.Tarih.Value.Month)
                .Select(y => new
                {
                    AyNo = y.Key,
                    Gelir = y.Sum(z => z.Gelir) ?? 0,
                    Maliyet = y.Sum(z => z.Maliyet) ?? 0
                }).ToList();
            foreach (var x in rapor)
            {
                string ayAdi = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(x.AyNo);
                ChartControl1.Series["Gelir"].Points.AddPoint(ayAdi, (double) x.Gelir);
                ChartControl1.Series["Maliyet"].Points.AddPoint(ayAdi, (double) x.Maliyet);

            }
        }
    }
}
