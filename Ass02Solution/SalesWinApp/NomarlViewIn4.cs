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
    public partial class NomarlViewIn4 : Form
    {
        public static Member memm { get; set; }
        public NomarlViewIn4()
        {
            InitializeComponent();
        }

        private void NomarlViewIn4_Load(object sender, EventArgs e)
        {
            txtID.Text = frmLogin.mem.MemberID.ToString();
            txtNAme.Text = frmLogin.mem.CompanyName;
            txtCity.Text = frmLogin.mem.City;
            txtCountry.Text = frmLogin.mem.Country;
            txtEmail.Text = frmLogin.mem.Email;
            txtPass.Text = frmLogin.mem.Password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmViewOder = new ViewOderHis();
            frmViewOder.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var frmNomael = new NormalUpdate();
            frmNomael.Show();
            this.Hide();
        }

        private void btnLogOUT_Click(object sender, EventArgs e)
        {
            var formMember = new frmLogin();
            formMember.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memm = MemberDAO.GetMemberById(frmLogin.mem.MemberID);
            txtID.Text = frmLogin.mem.MemberID.ToString();
            txtNAme.Text = memm.CompanyName;
            txtCity.Text = memm.City;
            txtCountry.Text = memm.Country;
            txtEmail.Text = memm.Email;
            txtPass.Text = memm.Password;
        }
    }
}
