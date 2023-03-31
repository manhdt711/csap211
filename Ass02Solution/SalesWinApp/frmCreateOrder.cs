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
    public partial class frmCreateOrder : Form
    {
        public frmCreateOrder()
        {
            InitializeComponent();
        }

        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MemberDAO.GetAllMembers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var ord = new Order
                {
                    MemberID = int.Parse(txtMemID.Text),
                    OrderDate = dateTimePicker1.Value,
                    RequiredDate = dateTimePicker2.Value,
                    ShippedDate = dateTimePicker3.Value,
                    Freight = decimal.Parse(txtFreight.Text)
                };

                OrderDAO.AddOrder(ord);
                MessageBox.Show("Action completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmManaOdrer = new ManagerOder();
            frmManaOdrer.Show();
            this.Hide();
        }

        private void btnLogOUT_Click(object sender, EventArgs e)
        {
            var formMember = new frmLogin();
            formMember.Show();
            this.Hide();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "yyyy/MM/dd";
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Back) ||(e.KeyCode == Keys.Delete))
            {
                dateTimePicker3.CustomFormat = " ";
            }    
        }
    }
}
