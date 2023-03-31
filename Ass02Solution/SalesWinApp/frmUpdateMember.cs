using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using System.Xml.Linq;
using MyStoreWinApp;

namespace SalesWinApp
{
    public partial class frmUpdateMember : Form
    {
        public frmUpdateMember()
        {
            InitializeComponent();
        }

        private void frmUpdateMember_Load(object sender, EventArgs e)
        {
            txtNAme.ReadOnly= true;
            txtCity.ReadOnly= true;
            txtCountry.ReadOnly= true;
            txtEmail.ReadOnly= true;
            txtPass.ReadOnly= true;
            btnFindID.Enabled= true;
            txtID.ReadOnly = false;
            label7.Enabled= true;
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(txtID.Text);
                Member member = MemberDAO.GetMemberById(Id);
                if (member != null)
                {
                    txtNAme.ReadOnly = false;
                    txtCity.ReadOnly = false;
                    txtCountry.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtPass.ReadOnly = false;
                    txtNAme.Text = member.CompanyName;
                    txtCity.Text = member.City;
                    txtCountry.Text = member.Country;
                    txtEmail.Text = member.Email;
                    txtPass.Text = member.Password;
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
            if(txtNAme.ReadOnly)
            {
                MessageBox.Show("You must fill ID frist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var mem = new Member
                    {
                        MemberID = int.Parse(txtID.Text),
                        CompanyName = txtNAme.Text,
                        Email = txtEmail.Text,
                        Password = txtPass.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                    };

                    MemberDAO.UpdateMember(mem);
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
            var ManaMem = new ManagerMember();
            ManaMem.Show();
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
