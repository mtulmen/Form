using Dal.DbOps;
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
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            UserRepositry rep = new UserRepositry();
            if (rep.CheckLogin(username, password))
            {
                MenuForm frm = new MenuForm(this);
                frm.Show();
                this.Visible = false;

            }
        }
    }
}
