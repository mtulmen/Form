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
    public partial class FrmProduct : BaseFrm
    {
        public FrmProduct()
        {
            InitializeComponent();
            rep = new ProductRepository();
            RefreshGrid();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmProEdit frm = new FrmProEdit();
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

            ProductEntity pro = new ProductEntity();
            pro.Id = Convert.ToInt32(row[0]);
            pro.Name = row[1].ToString();
            pro.Stock = Convert.ToInt32(row[2]);
            pro.Price = Convert.ToInt32(row[3]);
            pro.CategoryId = Convert.ToInt32(row[4]);
            pro.ProductCode = row[5].ToString();
            
            FrmProEdit frm = new FrmProEdit(pro);
            frm.ShowDialog();
            RefreshGrid();
        }
    }
}
