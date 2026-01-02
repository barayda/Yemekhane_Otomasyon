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
    public partial class Yemekhaneler : Form
    {
        public Yemekhaneler()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        void Degerler()
        {
            gridCtrl1.DataSource = db.Yemekhaneler
        .GroupBy(x => x.İl) 
        .Select(y => new
        {
            İl = y.Key,             
            YemekhaneSayisi = y.Count() 
        })
        .ToList();
        }

        private void Grafik()
        {
                chartControl1.Series["Şehirlerveyemekhaneler"].Points.Clear();
            
            var sehirdagilimi=db.Yemekhaneler
                .GroupBy(x => x.İl)
                .Select(y => new
                {
                    İl = y.Key,
                    YemekhaneSayisi = y.Count()
                })
                .ToList();
            foreach (var item in sehirdagilimi)
            {
                chartControl1.Series["Şehirlerveyemekhaneler"].Points.AddPoint(item.İl, item.YemekhaneSayisi);
            }
            chartControl1.Series["Şehirlerveyemekhaneler"].LabelsVisibility= DevExpress.Utils.DefaultBoolean.True;
        }
        private void Yemekhaneler_Load(object sender, EventArgs e)
        { 
            Degerler();
            Grafik();

            LblToplamYemekhane.Text = db.Yemekhaneler.Count().ToString();
            LblEnFazlaKazandiranIl.Text = (from x in db.Yemekhaneler
                                         group x by x.İl into g
                                         orderby g.Sum(z => z.Kar) descending
                                         select new
                                         {
                                             Il = g.Key,
                                             ToplamKazanc = g.Sum(z => z.Kar)
                                         }).FirstOrDefault().Il;
            LblEnFazlaYemekhaneOlanIl.Text = (from x in db.Yemekhaneler
                                             group x by x.İl into g
                                             orderby g.Count() descending
                                             select new
                                             {
                                                 Il = g.Key,
                                                 YemekhaneSayisi = g.Count()
                                             }).FirstOrDefault().Il;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object il = gridView1.GetFocusedRowCellValue("İl");
            LblSecilenSehir.Text = il.ToString();
            var istatistik=db.Yemekhaneler.Where(x=>x.İl==il).GroupBy(x=>x.İl).Select(s=>new
            {
                İlceSayisi=db.Yemekhaneler.Where(y=>y.İl==il).Select(z=>z.ilce).Distinct().Count(),
                ToplamKazanc=db.Yemekhaneler.Where(y=>y.İl==il).Sum(z=>z.Gelir),
                ToplamMaliyet=db.Yemekhaneler.Where(y=>y.İl==il).Sum(z=>z.Maliyet),
                ToplamKarZarar=db.Yemekhaneler.Where(y=>y.İl==il).Sum(z=>z.Kar)
            }).FirstOrDefault();

            if(istatistik !=null)
            {
                LblYemekhaneBulunanİlceSayisi.Text = istatistik.İlceSayisi.ToString();
                LblToplamGelir.Text = istatistik.ToplamKazanc.ToString() + " ₺";
                LblToplamMaliyet.Text = istatistik.ToplamMaliyet.ToString() + " ₺";
                LblKarZararBilgisi.Text = istatistik.ToplamKarZarar.ToString() + " ₺";
                LblKarZararBilgisi.ForeColor = istatistik.ToplamKarZarar >= 0 ? Color.Green : Color.Red;
            }
        }
    }
}
