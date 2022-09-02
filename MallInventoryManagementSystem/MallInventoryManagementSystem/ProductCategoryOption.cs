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

       

        private void buttonProducts_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ManageCategories fm = new ManageCategories();
            fm.ShowDialog();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCategories manageCategories = new ManageCategories();
            manageCategories.ShowDialog();
        }

        private void labelClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminForm = new AdminHome();
            adminForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AttendantHome adminForm = new AttendantHome();
            adminForm.ShowDialog();
        }
    }
}
