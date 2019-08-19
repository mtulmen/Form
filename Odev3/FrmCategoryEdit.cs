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
    public partial class FrmCategoryEdit : Form
    {
        int id;
        public FrmCategoryEdit()
        {
            id = -1;
            InitializeComponent();
        }

        public FrmCategoryEdit(CategoryEntity cat)
        {
            InitializeComponent();
            txtName.Text = cat.Name;
            txtOrder.Text = cat.CatOrder.ToString();
            txtDesc.Text = cat.Desc;
            id = cat.Id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CategoryEntity ctg = new CategoryEntity();
            ctg.CatOrder = Convert.ToInt32(txtOrder.Text);
            ctg.Desc = txtDesc.Text;
            ctg.Name = txtName.Text;


            CategoryRepository rep = new CategoryRepository();

            if (id == -1)
            {
                rep.Insert(ctg);
            }
            else
            {
                ctg.Id = id;
                rep.Update(ctg);
            }
            Close();
        }
    }
}
