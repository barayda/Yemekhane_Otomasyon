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
using Yemekhane_otomasyon.Forms.MenuIstatistikGrafikleri;

namespace Yemekhane_otomasyon.Forms
{
    public partial class FrmMenuIstatistik : Form
    {
        public FrmMenuIstatistik()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        private void GrafikGetir(Control uc)
        {
            PnlGrafikler.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            PnlGrafikler.Controls.Add(uc);
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int secim = int.Parse(lookUpEdit1.EditValue.ToString());
            switch (secim)
            {
                case 1:
                    Forms.MenuIstatistikGrafikleri.KarZararGrafik uc1 = new Forms.MenuIstatistikGrafikleri.KarZararGrafik();
                    GrafikGetir((Control)uc1);
                    break;
                case 2:
                    Forms.MenuIstatistikGrafikleri.PastaGrafik uc2 = new Forms.MenuIstatistikGrafikleri.PastaGrafik();
                    GrafikGetir((Control)uc2);
                    break;
                case 3:
                    Forms.MenuIstatistikGrafikleri.SütunGrafik1 uc3 = new Forms.MenuIstatistikGrafikleri.SütunGrafik1();
                    GrafikGetir((Control)uc3);
                    break;
                default:
                    PnlGrafikler.Controls.Clear();
                    break;

            }
        }

        private void FrmMenuIstatistik_Load(object sender, EventArgs e)
        {
            // LookUpEdit Kodları

            DataTable dtGrafikler = new DataTable();
            dtGrafikler.Columns.Add("ID", typeof(int));
            dtGrafikler.Columns.Add("GrafikAdi", typeof(string));

            dtGrafikler.Rows.Add(1, "Aylık Kar/Zarar Grafiği");
            dtGrafikler.Rows.Add(2, "Aylık Kapasite/Tüketim Grafiği");
            dtGrafikler.Rows.Add(3, "Aylık Maliyet Grafiği");
            lookUpEdit1.Properties.DataSource = dtGrafikler;
            lookUpEdit1.Properties.DisplayMember = "GrafikAdi";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GrafikAdi", "Grafik Seçimi"));


            Forms.MenuIstatistikGrafikleri.KarZararGrafik x = new Forms.MenuIstatistikGrafikleri.KarZararGrafik();
            GrafikGetir(x);

            // Panel Kodları

            LblAylikGelir.Text = (db.Menü.Sum(y => y.ToplamKazanc)).ToString() + " TL"; // Aylık Gelir
            LblAylikMaliyet.Text = (db.Menü.Sum(y => y.ToplamMaliyet)).ToString() + " TL";// Aylık Maliyet

            // En Maliyetli Menü
            var menu = (from x1 in db.Menü
                        orderby x1.ToplamMaliyet descending
                        select x1).FirstOrDefault();
            var parcalar = new List<string> {
                 menu.AnaYemek,
                    menu.YanYemek,
                    menu.AraSıcak,
                    menu.Tatli,
                    menu.Salata
    };
            LblEnMaliyetliMenu.Text = string.Join("\n", parcalar.Where(s => !string.IsNullOrWhiteSpace(s)));
            LblEnMaliyetliMenuTarih.Text = string.Format("{0:dd.MM.yyyy}", menu.Tarih);

            // En karlı Menü
            var kar = (from x1 in db.Menü
                       orderby x1.ToplamKazanc descending
                       select x1).FirstOrDefault();
            var karparcalar = new List<string>
            {
                kar.AnaYemek,
                kar.YanYemek,
                kar.AraSıcak,
                kar.Tatli,
                kar.Salata
            };
            LblEnKarliMenu.Text = string.Join("\n", karparcalar.Where(s => !string.IsNullOrWhiteSpace(s)));
            LblEnKarliMenuDate.Text = string.Format("{0:dd.MM.yyyy}", kar.Tarih);

            // En Az Maliyetli Menü
            var azmaliyet = (from x1 in db.Menü
                             orderby x1.ToplamMaliyet ascending
                             select x1).FirstOrDefault();
            var azmaliyetparcalar = new List<string>
            {
                azmaliyet.AnaYemek,
                azmaliyet.YanYemek,
                azmaliyet.AraSıcak,
                azmaliyet.Tatli,
                azmaliyet.Salata
            };
            LblEnAzMaliyetliMenu.Text = string.Join("\n", azmaliyetparcalar.Where(s => !string.IsNullOrWhiteSpace(s)));
            LblEnAzMaliyetliMenuDate.Text = string.Format("{0:dd.MM.yyyy}", azmaliyet.Tarih);

            //En Fazla Satılan Menü
            var fazlasatilan = (from x1 in db.Menü
                                orderby x1.YiyenKisiSayisi descending
                                select x1).FirstOrDefault();
            var fazlasatilanparcalar = new List<string>
            {
                fazlasatilan.AnaYemek,
                fazlasatilan.YanYemek,
                fazlasatilan.AraSıcak,
                fazlasatilan.Tatli,
                fazlasatilan.Salata
            };
            LblEnFazlaTuketilenMenu.Text = string.Join("\n", fazlasatilanparcalar.Where(s => !string.IsNullOrWhiteSpace(s)));
            LblEnFazlaTuketilenMenuDate.Text = string.Format("{0:dd.MM.yyyy}", fazlasatilan.Tarih);




        }
    }
}
