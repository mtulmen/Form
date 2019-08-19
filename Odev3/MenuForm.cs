using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev3
{
    public partial class MenuForm : Form
    {
        LoginFrm frm;
        public MenuForm(LoginFrm _frm)
        {
            frm = _frm;
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            frm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.ShowDialog();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            frm.Close();
            base.OnFormClosed(e);
        }
    }
}
