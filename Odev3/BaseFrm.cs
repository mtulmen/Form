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
    public partial class BaseFrm : Form
    {
        public BaseFrm()
        {
            InitializeComponent();
        }

        public BaseRepository rep;

        public void RefreshGrid()
        {
            dataGridView1.DataSource = rep.Listdt();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select row to delete");
                return;
            }

            DataRowView row = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;


            rep.Delete(Convert.ToInt32(row["Id"]));

            RefreshGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
