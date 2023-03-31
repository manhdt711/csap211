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
    public partial class ManagerOder : Form
    {
        public ManagerOder()
        {
            InitializeComponent();
        }

        private void ManagerOder_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = OrderDAO.GetAllOrders();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var frmUpdateOrder = new frmCreateOrder();
            frmUpdateOrder.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var frmUpdateOrder = new frmUpdateOrder();
            frmUpdateOrder.Show();
            this.Hide();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = OrderDAO.GetAllOrders();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = OrderDAO.GetOrdersByDateRange(dateTimePicker1.Value,dateTimePicker2.Value);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmMain = new MainForAdmin();
            frmMain.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                int Id = int.Parse(txtDeleteId.Text);
                Order order = OrderDAO.GetOrderById(Id);
                if (order == null)
                {
                    MessageBox.Show("Can't Find this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = OrderDAO.GetAllOrders();
                }
                else
                {
                    OrderDAO.DeleteOrder(Id);
                    dataGridView1.DataSource = OrderDAO.GetAllOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var formMember = new frmLogin();
            formMember.Show();
            this.Hide();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ShippedDate"].Index && e.Value != null)
            {
                DateTime orderDate = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["OrderDate"].Value;
                DateTime shippedDate = (DateTime)e.Value;

                if (shippedDate < orderDate)
                {
                    e.Value = "Not Shipped Yet";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
