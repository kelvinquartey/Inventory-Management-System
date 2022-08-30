using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallInventoryManagementSystem
{
    public partial class ProductCategoryOption : Form
    {
        public ProductCategoryOption()
        {
            InitializeComponent();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminForm = new AdminHome();
            adminForm.ShowDialog();
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageProducts pf = new ManageProducts();
            pf.ShowDialog();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCategories fm = new ManageCategories();
            fm.ShowDialog();
        }
    }
}
