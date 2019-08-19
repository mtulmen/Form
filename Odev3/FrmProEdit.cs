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
    public partial class FrmProEdit : Form
    {
        int id;
        public FrmProEdit()
        {
            id = -1;
            InitializeComponent();
            List<CategoryEntity> catList = new List<CategoryEntity>();

            CategoryRepository rep = new CategoryRepository();

            catList = rep.List();

            comboBoxCat.DataSource = catList;

            comboBoxCat.DisplayMember = "Name";
        }

        public FrmProEdit(ProductEntity pro)
        {
            InitializeComponent();
            txtName.Text = pro.Name;
            txtPrice.Text = pro.Price.ToString();
            txtpC.Text = pro.ProductCode;
            txtStock.Text = pro.Stock.ToString();
            comboBoxCat.DisplayMember = pro.CatName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductEntity p = new ProductEntity();
            p.Name = txtName.Text;
            p.Price = Convert.ToDecimal(txtPrice.Text);
            p.ProductCode = txtpC.Text;
            p.Stock = Convert.ToInt32(txtStock.Text);

            CategoryEntity selectedCat = (CategoryEntity)comboBoxCat.SelectedItem;

            p.CategoryId = selectedCat.Id;

            ProductRepository rep = new ProductRepository();

            if (id == -1)
            {
                rep.Insert(p);
            }
            else
            {
                p.Id = id;
                rep.Update(p);
            }
            Close();
            
        }
    }
}
