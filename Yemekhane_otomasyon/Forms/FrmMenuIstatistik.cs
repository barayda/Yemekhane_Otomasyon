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
        DBYemekhaneEntities db=new DBYemekhaneEntities();
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
                    Forms.MenuIstatistikGrafikleri.SutunGrafik uc1 = new Forms.MenuIstatistikGrafikleri.SutunGrafik();
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
            DataTable dtGrafikler=new DataTable();
            dtGrafikler.Columns.Add("ID", typeof(int));
            dtGrafikler.Columns.Add("GrafikAdi", typeof(string));

            dtGrafikler.Rows.Add(1, "Sütun Grafiği");
            dtGrafikler.Rows.Add(2, "Pasta Grafiği");
            dtGrafikler.Rows.Add(3, "Çizgi Grafiği");
            lookUpEdit1.Properties.DataSource = dtGrafikler;
            lookUpEdit1.Properties.DisplayMember = "GrafikAdi"; 
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GrafikAdi", "Grafik Seçimi"));


            Forms.MenuIstatistikGrafikleri.SutunGrafik x = new Forms.MenuIstatistikGrafikleri.SutunGrafik();
            GrafikGetir(x);
        }
    }
}
