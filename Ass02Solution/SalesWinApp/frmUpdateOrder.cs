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
using System.Xml.Linq;

namespace SalesWinApp
{
    public partial class frmUpdateOrder : Form
    {
        public frmUpdateOrder()
        {
            InitializeComponent();
        }

        private void frmUpdateOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MemberDAO.GetAllMembers();
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(txtOderID.Text);
                Order order = OrderDAO.GetOrderById(Id);
                if (order != null)
                {
                    txtMemID.ReadOnly = false;
                    txtOrderDate.Visible = false;
                    txtRequiredDate.Visible = false;
                    txtShippeDate.Visible = false;
                    txtFreight.ReadOnly = false;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    dateTimePicker3.Visible = true;
                    txtMemID.Text = order.MemberID.ToString();
                    dateTimePicker1.Value = order.OrderDate;
                    dateTimePicker2.Value = order.RequiredDate;
                    if (order.ShippedDate >= order.OrderDate)
                    {
                        dateTimePicker3.CustomFormat = "yyyy/MM/dd";
                        dateTimePicker3.Value = (DateTime)order.ShippedDate;
                    }
                    else
                    {
                        dateTimePicker3.CustomFormat = " ";
                    }

                    txtFreight.Text = order.Freight.ToString();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = MemberDAO.GetAllMembers();
                }
                else
                {
                    MessageBox.Show("Can't Find this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = MemberDAO.GetAllMembers();
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmManaOder = new ManagerOder();
            frmManaOder.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFreight.ReadOnly)
            {
                MessageBox.Show("You must fill ID frist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var ord = new Order
                    {
                        OrderId = int.Parse(txtOderID.Text),
                        MemberID = int.Parse(txtMemID.Text),
                        OrderDate = dateTimePicker1.Value,
                        RequiredDate = dateTimePicker2.Value,
                        ShippedDate = dateTimePicker3.Value,
                        Freight = decimal.Parse(txtFreight.Text)
                    };

                    OrderDAO.UpdateOrder(ord);
                    MessageBox.Show("Action completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "yyyy/MM/dd";
        }

        private void btnLogOUT_Click(object sender, EventArgs e)
        {
            var formMember = new frmLogin();
            formMember.Show();
            this.Hide();
        }
    }
}
