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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageUsers mu = new ManageUsers();
            mu.ShowDialog();
        }

        private void buttonManageProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductCategoryOption productCategoryOption = new ProductCategoryOption();
            productCategoryOption.ShowDialog();

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonManageStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminTransactionForm adminTransactionForm = new AdminTransactionForm();
            adminTransactionForm.ShowDialog();
        }
    }
}
