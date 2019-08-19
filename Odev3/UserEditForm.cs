using Dal.DbOps;
using Dal.Entities;
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
    public partial class UserEditForm : Form
    {
        int id;
        public UserEditForm()
        {
            id = -1;
            InitializeComponent();
        }

        public UserEditForm(UserEntity user)
        {
            id = user.Id;
            InitializeComponent();

            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtCredit.Text = user.Credit.ToString();
            txtName.Text = user.FullName;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserEntity user = new UserEntity();
            user.Credit = Convert.ToDecimal(txtCredit.Text);
            user.FullName = txtName.Text;
            user.Password = txtPassword.Text;
            user.UserName = txtUserName.Text;

            UserRepositry rep = new UserRepositry();
            if (id == -1)
            {
                rep.Insert(user);
            }
            else
            {
                user.Id = id;
                rep.Update(user);
            }


            Close();
        }
    }
}
