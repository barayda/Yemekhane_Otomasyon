namespace Yemekhane_otomasyon.PersonelForm
{
    partial class GorevListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorevListesi));
            this.gridCtrl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.LblTamanlananGorev = new DevExpress.XtraEditors.LabelControl();
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.LblBekleyenGorev = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.LblGorevTarih = new DevExpress.XtraEditors.LabelControl();
            this.LblDurumGorev = new DevExpress.XtraEditors.LabelControl();
            this.LblAciklama = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LblPersonelAd = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureFoto = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCtrl1
            // 
            this.gridCtrl1.Location = new System.Drawing.Point(1, 0);
            this.gridCtrl1.MainView = this.gridView1;
            this.gridCtrl1.Name = "gridCtrl1";
            this.gridCtrl1.Size = new System.Drawing.Size(370, 344);
            this.gridCtrl1.TabIndex = 2;
            this.gridCtrl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridCtrl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.LblTamanlananGorev);
            this.panelControl3.Controls.Add(this.lbl);
            this.panelControl3.Controls.Add(this.pictureEdit3);
            this.panelControl3.Location = new System.Drawing.Point(573, 0);
            this.panelControl3.LookAndFeel.SkinName = "DevExpress Style";
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(201, 105);
            this.panelControl3.TabIndex = 7;
            // 
            // LblTamanlananGorev
            // 
            this.LblTamanlananGorev.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTamanlananGorev.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblTamanlananGorev.Appearance.Options.UseFont = true;
            this.LblTamanlananGorev.Appearance.Options.UseForeColor = true;
            this.LblTamanlananGorev.Location = new System.Drawing.Point(44, 51);
            this.LblTamanlananGorev.Name = "LblTamanlananGorev";
            this.LblTamanlananGorev.Size = new System.Drawing.Size(11, 25);
            this.LblTamanlananGorev.TabIndex = 5;
            this.LblTamanlananGorev.Text = "0";
            // 
            // lbl
            // 
            this.lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl.Appearance.Options.UseFont = true;
            this.lbl.Appearance.Options.UseForeColor = true;
            this.lbl.Location = new System.Drawing.Point(4, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(184, 19);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Tamamlanan Görev Sayısı";
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.EditValue = ((object)(resources.GetObject("pictureEdit3.EditValue")));
            this.pictureEdit3.Location = new System.Drawing.Point(110, 34);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit3.Size = new System.Drawing.Size(77, 68);
            this.pictureEdit3.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(177)))), ((int)(((byte)(44)))));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.LblBekleyenGorev);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.pictureEdit2);
            this.panelControl2.Location = new System.Drawing.Point(377, 0);
            this.panelControl2.LookAndFeel.SkinName = "DevExpress Style";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(190, 105);
            this.panelControl2.TabIndex = 6;
            // 
            // LblBekleyenGorev
            // 
            this.LblBekleyenGorev.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblBekleyenGorev.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblBekleyenGorev.Appearance.Options.UseFont = true;
            this.LblBekleyenGorev.Appearance.Options.UseForeColor = true;
            this.LblBekleyenGorev.Location = new System.Drawing.Point(34, 51);
            this.LblBekleyenGorev.Name = "LblBekleyenGorev";
            this.LblBekleyenGorev.Size = new System.Drawing.Size(11, 25);
            this.LblBekleyenGorev.TabIndex = 5;
            this.LblBekleyenGorev.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(17, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(154, 19);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Bekleyen Görev Sayısı";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(110, 31);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Size = new System.Drawing.Size(77, 68);
            this.pictureEdit2.TabIndex = 3;
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.LblGorevTarih);
            this.panelControl4.Controls.Add(this.LblDurumGorev);
            this.panelControl4.Controls.Add(this.LblAciklama);
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Location = new System.Drawing.Point(377, 111);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(371, 233);
            this.panelControl4.TabIndex = 8;
            // 
            // LblGorevTarih
            // 
            this.LblGorevTarih.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGorevTarih.Appearance.Options.UseFont = true;
            this.LblGorevTarih.Location = new System.Drawing.Point(35, 200);
            this.LblGorevTarih.Name = "LblGorevTarih";
            this.LblGorevTarih.Size = new System.Drawing.Size(10, 23);
            this.LblGorevTarih.TabIndex = 3;
            this.LblGorevTarih.Text = "0";
            // 
            // LblDurumGorev
            // 
            this.LblDurumGorev.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDurumGorev.Appearance.Options.UseFont = true;
            this.LblDurumGorev.Location = new System.Drawing.Point(220, 200);
            this.LblDurumGorev.Name = "LblDurumGorev";
            this.LblDurumGorev.Size = new System.Drawing.Size(10, 23);
            this.LblDurumGorev.TabIndex = 2;
            this.LblDurumGorev.Text = "0";
            // 
            // LblAciklama
            // 
            this.LblAciklama.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAciklama.Appearance.Options.UseFont = true;
            this.LblAciklama.Location = new System.Drawing.Point(17, 71);
            this.LblAciklama.Name = "LblAciklama";
            this.LblAciklama.Size = new System.Drawing.Size(7, 16);
            this.LblAciklama.TabIndex = 1;
            this.LblAciklama.Text = "0";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(17, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(137, 23);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Görev Detaylar :";
            // 
            // LblPersonelAd
            // 
            this.LblPersonelAd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPersonelAd.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblPersonelAd.Appearance.Options.UseFont = true;
            this.LblPersonelAd.Appearance.Options.UseForeColor = true;
            this.LblPersonelAd.Location = new System.Drawing.Point(16, 56);
            this.LblPersonelAd.Name = "LblPersonelAd";
            this.LblPersonelAd.Size = new System.Drawing.Size(9, 19);
            this.LblPersonelAd.TabIndex = 1;
            this.LblPersonelAd.Text = "0";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(65)))), ((int)(((byte)(24)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.LblPersonelAd);
            this.panelControl1.Location = new System.Drawing.Point(780, 0);
            this.panelControl1.LookAndFeel.SkinName = "DevExpress Style";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(190, 105);
            this.panelControl1.TabIndex = 5;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(157, 9);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(30, 30);
            this.pictureEdit1.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 25);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "İyi Günler";
            // 
            // pictureFoto
            // 
            this.pictureFoto.Location = new System.Drawing.Point(754, 111);
            this.pictureFoto.Name = "pictureFoto";
            this.pictureFoto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureFoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureFoto.Size = new System.Drawing.Size(216, 233);
            this.pictureFoto.TabIndex = 9;
            // 
            // GorevListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 346);
            this.Controls.Add(this.pictureFoto);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridCtrl1);
            this.Name = "GorevListesi";
            this.Text = "Görev Listesi";
            this.Load += new System.EventHandler(this.GorevListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridCtrl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl LblTamanlananGorev;
        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl LblBekleyenGorev;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl LblPersonelAd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl LblGorevTarih;
        private DevExpress.XtraEditors.LabelControl LblDurumGorev;
        private DevExpress.XtraEditors.LabelControl LblAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureFoto;
    }
}