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
    public partial class KarZararGrafik : UserControl
    {
        public KarZararGrafik()
        {
            InitializeComponent();
            this.Load += KarZararGrafik_Load;
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        private void KarZararGrafik_Load(object sender, EventArgs e)
        {
            var veriler = db.Menü
                    .OrderByDescending(x => x.Tarih)
                    .Take(7)
                    .Select(x => new
                    {
                        Tarih = x.Tarih,
                        Kar = x.ToplamKazanc - x.ToplamMaliyet > 0 ? x.ToplamKazanc - x.ToplamMaliyet : 0,
                        Zarar = x.ToplamKazanc - x.ToplamMaliyet < 0 ? (x.ToplamMaliyet - x.ToplamKazanc) : 0
                    }).ToList();
            chartControl1.Series["Kar"].DataSource = veriler;
            chartControl1.Series["Kar"].ArgumentDataMember = "Tarih";
            chartControl1.Series["Kar"].ValueDataMembers.AddRange(new string[] { "Kar" });
            chartControl1.Series["Zarar"].DataSource = veriler;
            chartControl1.Series["Zarar"].ArgumentDataMember = "Tarih";
            chartControl1.Series["Zarar"].ValueDataMembers.AddRange(new string[] { "Zarar" });
            chartControl1.RefreshData();


        }

    }
}
