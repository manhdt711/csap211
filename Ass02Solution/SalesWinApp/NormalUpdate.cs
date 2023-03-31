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
    public partial class NormalUpdate : Form
    {
        public NormalUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = new Member
                {
                    MemberID = frmLogin.mem.MemberID,
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

        private void button1_Click(object sender, EventArgs e)
        {
            var frmnormali4 = new NomarlViewIn4();
            frmnormali4.Show();
            this.Hide();
        }

        private void NormalUpdate_Load(object sender, EventArgs e)
        {
            NomarlViewIn4.memm = MemberDAO.GetMemberById(frmLogin.mem.MemberID);
            txtNAme.Text = NomarlViewIn4.memm.CompanyName;
            txtCity.Text = NomarlViewIn4.memm.City;
            txtCountry.Text = NomarlViewIn4.memm.Country;
            txtEmail.Text = NomarlViewIn4.memm.Email;
            txtPass.Text = NomarlViewIn4.memm.Password;
        }
    }
}
