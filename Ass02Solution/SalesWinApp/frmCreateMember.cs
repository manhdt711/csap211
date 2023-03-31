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
    public partial class frmCreateMember : Form
    {
        public frmCreateMember()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = new Member
                {
                    CompanyName = txtNAme.Text,
                    Email = txtEmail.Text,
                    Password = txtPass.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                };

                MemberDAO.AddMember(mem);
                MessageBox.Show("Action completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var backMem = new ManagerMember();
            backMem.Show();
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
