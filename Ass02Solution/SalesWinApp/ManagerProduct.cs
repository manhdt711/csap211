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
    public partial class ManagerProduct : Form
    {
        public ManagerProduct()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var frmCreateProduct = new frmCreateProduct();
            frmCreateProduct.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var frmUpdateProduct = new frmUpdateProduct();
            frmUpdateProduct.Show();
            this.Hide();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ProductDAO.GetAllProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                int Id = int.Parse(txtDeleteId.Text);
                //Member member = MemberDAO.GetMemberById(Id);
                Product product= ProductDAO.GetProductById(Id);
                if (product == null)
                {
                    MessageBox.Show("Can't Find this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = ProductDAO.GetAllProducts();
                }
                else
                {
                    ProductDAO.DeleteProduct(Id);
                    dataGridView1.DataSource = ProductDAO.GetAllProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManagerProduct_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ProductDAO.GetAllProducts();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmMain = new MainForAdmin();
            frmMain.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var formMember = new frmLogin();
            formMember.Show();
            this.Hide();
        }
    }
}
