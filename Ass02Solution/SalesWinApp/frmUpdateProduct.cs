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
    public partial class frmUpdateProduct : Form
    {
        public frmUpdateProduct()
        {
            InitializeComponent();
        }

        private void frmUpdateProduct_Load(object sender, EventArgs e)
        {
            txtNAme.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPass.ReadOnly = true;
            btnFindID.Enabled = true;
            txtID.ReadOnly = false;
            label7.Enabled = true;
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(txtID.Text);
                Product product = ProductDAO.GetProductById(Id);
                if (product != null)
                {
                    txtNAme.ReadOnly = false;
                    txtCity.ReadOnly = false;
                    txtCountry.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtPass.ReadOnly = false;
                    txtNAme.Text = product.CategoryId.ToString();
                    txtCity.Text = product.UnitPrice.ToString();
                    txtCountry.Text = product.UnitsInStock.ToString();
                    txtEmail.Text = product.ProductName.ToString();
                    txtPass.Text = product.Weight.ToString();
                }
                else
                {
                    MessageBox.Show("Can't Find this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNAme.ReadOnly)
            {
                MessageBox.Show("You must fill ID frist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var pro = new Product
                    {
                        ProductId = int.Parse(txtID.Text),
                        CategoryId = int.Parse(txtNAme.Text),
                        ProductName = txtEmail.Text,
                        Weight = txtPass.Text,
                        UnitPrice = decimal.Parse(txtCity.Text),
                        UnitsInStock = int.Parse(txtCountry.Text),
                    };

                   ProductDAO.UpdateProduct(pro);
                    MessageBox.Show("Action completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmManagetOder = new ManagerProduct();
            frmManagetOder.Show();
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
