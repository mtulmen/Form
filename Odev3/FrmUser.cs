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
    public partial class FrmUser : BaseFrm
    {
        public FrmUser()
        {
            InitializeComponent();
            rep = new UserRepositry();
            RefreshGrid();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            UserEditForm frm = new UserEditForm();
            frm.ShowDialog();
            RefreshGrid();
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select row to Edit");
                return;
            }



            DataRowView userRow = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;

            UserEntity user = new UserEntity();
            user.Credit = Convert.ToDecimal(userRow["Credit"]);
            user.FullName = userRow["FullName"].ToString();
            user.Id = Convert.ToInt32(userRow["Id"]);
            user.Password = userRow["Password"].ToString();
            user.UserName = userRow["UserName"].ToString();

            UserEditForm frm = new UserEditForm(user);
            frm.ShowDialog();
            RefreshGrid();
        }
    }
}
