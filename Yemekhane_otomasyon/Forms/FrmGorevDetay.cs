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
using System.Data.Entity;

namespace Yemekhane_otomasyon.Forms
{
    public partial class FrmGorevDetay : Form
    {
        public FrmGorevDetay()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db=new DBYemekhaneEntities();
        private void FrmGorevDetay_Load(object sender, EventArgs e)
        {
            db.GorevDetaylar.Load();
            bindingSource1.DataSource = db.GorevDetaylar.Local;
            gridView1.NewItemRowText = "Yeni bir görev eklemek için buraya tıklayın";
            gridControl1.DataSource = (from x in db.GorevDetaylar select new { 
                x.ID,
                Görev = x.Gorevler.Aciklama,
                x.Aciklama,
                x.Tarih,
                x.Saat
            }).ToList();
        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void görevDetaySilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
