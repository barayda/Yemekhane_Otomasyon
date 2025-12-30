using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Yemekhane_otomasyon.Entity;

namespace Yemekhane_otomasyon.Forms
{
    public partial class FrmMenuEkle : Form
    {
        public FrmMenuEkle()
        {
            InitializeComponent();
        }

        DBYemekhaneEntities db = new DBYemekhaneEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Menü t = new Menü();

                if (lookUpEdit1.EditValue != null)
                {
                    t.OgunID = int.Parse(lookUpEdit1.EditValue.ToString());
                }

                t.AnaYemek = string.IsNullOrWhiteSpace(TxtAnaYemek.Text) ? null : TxtAnaYemek.Text;
                t.YanYemek = string.IsNullOrWhiteSpace(TxtYanYemek.Text) ? null : TxtYanYemek.Text;
                t.AraSıcak = string.IsNullOrWhiteSpace(TxtAraSicak.Text) ? null : TxtAraSicak.Text;
                t.Tatli = string.IsNullOrWhiteSpace(TxtTatli.Text) ? null : TxtTatli.Text;
                t.Salata = string.IsNullOrWhiteSpace(TxtSalata.Text) ? null : TxtSalata.Text;

                t.Tarih = DateEditTarih.DateTime;
                decimal fiyat = decimal.TryParse(TxtMenuFiyat.Text, out decimal f) ? f : 0;
                int adet = int.TryParse(TxtMenüAdet.Text, out int a) ? a : 0;

                t.Maliyet = fiyat;
                t.Kapasite= adet;
                t.ToplamMaliyet = adet * fiyat;
                db.Menü.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Menü başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlanlariTemizle();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void YemekListesiniGuncelle(int ogunID)
        {
            var anayemekListesi = db.Menü
                .Where(x => x.OgunID == ogunID)
                .Select(x => new { YemekAdi = x.AnaYemek })
                .Distinct()
                .ToList();

            TxtAnaYemek.Properties.DataSource = anayemekListesi;
            TxtAnaYemek.Properties.DisplayMember = "YemekAdi";
            TxtAnaYemek.Properties.ValueMember = "YemekAdi";

            TxtAnaYemek.Properties.Columns.Clear();
            TxtAnaYemek.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YemekAdi", "Ana Yemekler"));

            var yanYemekListesi = db.Menü
                .Where(x => x.OgunID == ogunID)
                .Select(x => new { YemekAdı = x.YanYemek })
                .Distinct()
                .ToList();
            TxtYanYemek.Properties.DataSource = yanYemekListesi;
            TxtYanYemek.Properties.DisplayMember = "YemekAdı";
            TxtYanYemek.Properties.ValueMember = "YemekAdı";

            TxtYanYemek.Properties.Columns.Clear();
            TxtYanYemek.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YemekAdı", "Yan Yemekler"));

            var araSicakListesi = db.Menü
                .Where(x => x.OgunID == ogunID)
                .Select(x => new { YemekAdı = x.AraSıcak })
                .Distinct()
                .ToList();
            TxtAraSicak.Properties.DataSource = araSicakListesi;
            TxtAraSicak.Properties.DisplayMember = "YemekAdı";
            TxtAraSicak.Properties.ValueMember = "YemekAdı";

            TxtAraSicak.Properties.Columns.Clear();
            TxtAraSicak.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YemekAdı", "Ara Sıcaklar"));

            var tatliListesi = db.Menü
                .Where(x => x.OgunID == ogunID)
                .Select(x => new { YemekAdı = x.Tatli })
                .Distinct()
                .ToList();
            TxtTatli.Properties.DataSource = tatliListesi;
            TxtTatli.Properties.DisplayMember = "YemekAdı";
            TxtTatli.Properties.ValueMember = "YemekAdı";

            TxtTatli.Properties.Columns.Clear();
            TxtTatli.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YemekAdı", "Tatlılar"));

            var salataListesi = db.Menü
                .Where(x => x.OgunID == ogunID)
                .Select(x => new { YemekAdı = x.Salata })
                .Distinct()
                .ToList();
            TxtSalata.Properties.DataSource = salataListesi;
            TxtSalata.Properties.DisplayMember = "YemekAdı";
            TxtSalata.Properties.ValueMember = "YemekAdı";

            TxtSalata.Properties.Columns.Clear();
            TxtSalata.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YemekAdı", "Salatalar"));
        }

        private void FrmMenuEkle_Load(object sender, EventArgs e)
        {
            DateEditTarih.Properties.MinValue = DateTime.Today;
            DateEditTarih.DateTime = DateTime.Today;
            DateEditTarih.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            DateEditTarih.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            DateEditTarih.Properties.EditMask = "dd.MM.yyyy";
            DateEditTarih.Properties.Mask.UseMaskAsDisplayFormat = true;

            var ogunler = db.Ogün.Select(x => new { x.ID, x.Ad }).ToList();
            lookUpEdit1.Properties.DataSource = ogunler;
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.NullText = "Öğün Seçiniz";
            lookUpEdit1.Properties.Columns.Clear();
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Öğün Adı"));

            TxtAnaYemek.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            TxtYanYemek.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            TxtAraSicak.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            TxtTatli.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            TxtSalata.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            TxtAnaYemek.Properties.ImmediatePopup = true;
            TxtAnaYemek.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            TxtYanYemek.Properties.ImmediatePopup = true;
            TxtYanYemek.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

        }
        private void ToplamMaliyetHesapla()
        {
            decimal fiyat = decimal.TryParse(TxtMenuFiyat.Text, out decimal f) ? f : 0;
            int adet = int.TryParse(TxtMenüAdet.Text, out int a) ? a : 0;

            decimal toplam = fiyat * adet;
            LblToplamMaliyet.Text = toplam.ToString("C2");
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null && lookUpEdit1.EditValue != DBNull.Value)
            {
                if (int.TryParse(lookUpEdit1.EditValue.ToString(), out int secilenOgunID))
                {
                    YemekListesiniGuncelle(secilenOgunID);
                }
            }
        }

        private void TxtMenuFiyat_EditValueChanged(object sender, EventArgs e)
        {
            ToplamMaliyetHesapla();
        }

        private void TxtMenüAdet_EditValueChanged(object sender, EventArgs e)
        {
            ToplamMaliyetHesapla();
        }
        private void AlanlariTemizle()
        {
            lookUpEdit1.EditValue = null;
            TxtAnaYemek.EditValue = null;
            TxtYanYemek.EditValue = null;
            TxtAraSicak.EditValue = null;
            TxtTatli.EditValue = null;
            TxtSalata.EditValue = null;
            TxtMenuFiyat.Text = "";
            TxtMenüAdet.Text = "";
            DateEditTarih.DateTime = DateTime.Today;
            lookUpEdit1.Focus();
        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            AlanlariTemizle();
        }
    }
}