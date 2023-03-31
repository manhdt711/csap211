using BusinessObject;
using DataAccess;
using MyStoreWinApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmCreateProduct : Form
    {
        public frmCreateProduct()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var pro = new Product
                {
                    CategoryId = int.Parse(txtNAme.Text),
                    ProductName = txtEmail.Text,
                    Weight = txtPass.Text,
                    UnitPrice = decimal.Parse(txtCity.Text),
                    UnitsInStock = int.Parse(txtCountry.Text),
                };

                ProductDAO.AddProduct(pro);
                MessageBox.Show("Action completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmManagerProduct = new ManagerProduct();
            frmManagerProduct.Show();
            this.Hide();
        }

        private void btnLogOUT_Click(object sender, EventArgs e)
        {
            var formMember = new frmLogin();
            formMember.Show();
            this.Hide();
        }
    }
}
