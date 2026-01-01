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

namespace Yemekhane_otomasyon.Forms.MenuIstatistikGrafikleri
{
    public partial class SütunGrafik1 : UserControl
    {
        public SütunGrafik1()
        {
            InitializeComponent();
            this.Load += SütunGrafik1_Load;
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        private void SütunGrafik1_Load(object sender, EventArgs e)
        {
            var veriler = db.Menü
                    .OrderByDescending(x => x.Tarih)
                    .Take(7)
                    .Select(x => new
                    {
                        Tarih = x.Tarih,
                        Kapasite = x.Kapasite,
                        Tüketim = x.YiyenKisiSayisi
                    }).ToList();
            chartControl1.Series["Kapasite"].DataSource = veriler;
            chartControl1.Series["Kapasite"].ArgumentDataMember = "Tarih";
            chartControl1.Series["Kapasite"].ValueDataMembers.AddRange(new string[] { "Kapasite" });
            chartControl1.Series["Tüketim"].DataSource = veriler;
            chartControl1.Series["Tüketim"].ArgumentDataMember = "Tarih";
            chartControl1.Series["Tüketim"].ValueDataMembers.AddRange(new string[] { "Tüketim" });
            chartControl1.RefreshData();
        }
    }
}
