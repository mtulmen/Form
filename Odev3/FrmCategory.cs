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
    public partial class FrmCategory : BaseFrm
    {
        public FrmCategory()
        {
            InitializeComponent();

            rep = new CategoryRepository();
            RefreshGrid();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmCategoryEdit frm = new FrmCategoryEdit();
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


            DataRowView row = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;

            CategoryEntity cat = new CategoryEntity();
            cat.CatOrder = Convert.ToInt32(row["CatOrder"]);
            cat.Desc = row["Description"].ToString();
            cat.Id = Convert.ToInt32(row["Id"]);
            cat.Name = row["Name"].ToString();

            FrmCategoryEdit frm = new FrmCategoryEdit(cat);
            frm.ShowDialog();
            RefreshGrid();
        }
    }
}
