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
    public partial class PastaGrafik : UserControl
    {
        public PastaGrafik()
        {
            InitializeComponent();
            this.Load += PastaGrafik_Load;
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
    
    private void PastaGrafik_Load(object sender, EventArgs e)
        {
            var veriler = db.Menü
                     .OrderByDescending(x => x.Tarih)
                     .Take(7)
                     .Select(x => new
                     {
                         Tarih = x.Tarih,
                         Kazanc = x.ToplamKazanc,
                         Maliyet = x.ToplamMaliyet
                     }).ToList();
            DevExpress.XtraCharts.Series seri1 = new DevExpress.XtraCharts.Series("Toplam Kazanç", DevExpress.XtraCharts.ViewType.Bar);
            seri1.DataSource = veriler;
            seri1.ArgumentDataMember = "Tarih";
            seri1.ValueDataMembers.AddRange(new string[] { "Kazanc" }); 
            
            DevExpress.XtraCharts.Series seri2 = new DevExpress.XtraCharts.Series("Toplam Maliyet", DevExpress.XtraCharts.ViewType.Bar);
            seri2.DataSource = veriler;
            seri2.ArgumentDataMember = "Tarih";
            seri2.ValueDataMembers.AddRange(new string[] { "Maliyet" }); 

            chartControl1.Series.Add(seri1);
            chartControl1.Series.Add(seri2);

            chartControl1.RefreshData();
        }


    } }

