using DevExpress.XtraToolbox;
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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();

        DateTime tdy=DateTime.Today;
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource=(from x in db.Gorevler where x.Durum==true
                                     select new
            {
                GorevVeren=x.Personel.Ad+" "+x.Personel.Soyad,
                x.Aciklama,
                GorevAlan=x.Personel1.Ad+" "+x.Personel1.Soyad

            }).ToList();
            gridControl2.DataSource = (from y in db.Menü where y.Tarih==tdy select new
            {
                Öğün=y.Ogün.Ad,
                y.AnaYemek,
                y.YanYemek,
                y.AraSıcak,
                y.Tatli,
                y.Salata,
                y.Tarih
            }).ToList();

        }
    }
}
