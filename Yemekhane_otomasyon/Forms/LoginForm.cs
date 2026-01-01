using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yemekhane_otomasyon.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        
        private void BtnPersonelGirisi_Click(object sender, EventArgs e)
        {
            Forms.PersonelLogin x = new Forms.PersonelLogin();
            x.Show();
            this.Hide();
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LblClose_MouseHover(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(230, 126, 34);
        }

        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            LblClose.ForeColor = Color.FromArgb(0,0,0);
        }

        private void BtnAdminGirisi_Click(object sender, EventArgs e)
        {
            Forms.adminLogin frm=new Forms.adminLogin();
            frm.Show();
            this.Hide();
        }
    }
}
