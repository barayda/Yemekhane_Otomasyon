using DevExpress.XtraEditors;
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
using static Yemekhane_otomasyon.Forms.PersonelLogin;
namespace Yemekhane_otomasyon.PersonelForm
{
    public partial class YanitGonder : Form
    {
        public YanitGonder()
        {
            InitializeComponent();
        }
        DBYemekhaneEntities db = new DBYemekhaneEntities();
        int secilenGorevID = 0;
        private void Listele2()
        {
            var gorevler = db.Gorevler
        .Where(x => x.Personel1.ID == KullaniciOturumu.KullaniciID)
        .Select(x => new
        {
            x.ID,
            GörevVeren = x.Personel.Ad + " " + x.Personel.Soyad,
            Görev = x.Aciklama,
            Tarih = x.Tarih,
            TamAciklama = x.GorevDetaylar.FirstOrDefault().Aciklama,
            Durum = x.Durum
        })
        .ToList();

            gridCtrl1.DataSource = gorevler;
        }

        private void YanitGonder_Load(object sender, EventArgs e)
        {
            Listele2 ();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var idObj = gridView1.GetFocusedRowCellValue("ID");
            if (idObj != null)
            {
                secilenGorevID = int.Parse(idObj.ToString());
            }

            var gorevAciklama = gridView1.GetFocusedRowCellValue("Görev");

            if (gorevAciklama != null)
            {
                LblSeciliGorev.Text = "Seçili Görev: " + gorevAciklama.ToString();
            }
        }
        private void AlanlariTemizle()
        {
            LblSeciliGorev.Text = "";
            memoEdit1.Text ="";
          
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (secilenGorevID == 0)
            {
                MessageBox.Show("Lütfen önce bir görev seçin!");
                return;
            }

            GorevDetaylar yeniDetay = new GorevDetaylar();
            yeniDetay.Gorev = secilenGorevID;
            yeniDetay.Aciklama = memoEdit1.Text; 
            yeniDetay.Tarih = DateTime.Now;
            yeniDetay.Saat = DateTime.Now.ToShortTimeString();

            db.GorevDetaylar.Add(yeniDetay);

            db.SaveChanges();
            MessageBox.Show("Yanıtınız başarıyla iletildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            AlanlariTemizle();
        }

        private void checkEditDurum_CheckedChanged(object sender, EventArgs e)
        {
            var idObj = gridView1.GetFocusedRowCellValue("ID");

            if (idObj != null)
            {
                int secilenID = int.Parse(idObj.ToString());

                var guncellenecekGorev = db.Gorevler.Find(secilenID);

                if (guncellenecekGorev != null)
                {
                    guncellenecekGorev.Durum = !checkEditDurum.Checked;
                }
            }
        }
    }
}
