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
            LblToplamDepartman.Text = db.Departmanlar.Count().ToString();
            LblToplamYemekhane.Text=db.Yemekhaneler.Count().ToString();
            LblToplamPersonel.Text=db.Personel.Count().ToString();
            lblAktifİs.Text=db.Gorevler.Count(x=>x.Durum=="1").ToString();
            lblPasifİs.Text=db.Gorevler.Count(x=>x.Durum=="0").ToString();
            lblSonGörev.Text = db.Gorevler.OrderByDescending(x=>x.ID).Select(x => x.Aciklama).FirstOrDefault();
        }
    }
}
