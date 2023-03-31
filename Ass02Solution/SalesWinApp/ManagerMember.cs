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
using BusinessObject;
using DataAccess;
using MyStoreWinApp;

namespace SalesWinApp
{
    public partial class ManagerMember : Form
    {
        public ManagerMember()
        {
            InitializeComponent();
        }

        private void ManagerMember_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = MemberDAO.GetAllMembers();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
          var frmCreateMember = new frmCreateMember();
            frmCreateMember.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var frmUpdateMem = new frmUpdateMember();
            frmUpdateMem.Show();
            this.Hide();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = MemberDAO.GetAllMembers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = null;
                int Id = int.Parse(txtDeleteId.Text);
                Member member = MemberDAO.GetMemberById(Id);
                if (member == null)
                {
                    MessageBox.Show("Can't Find this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView2.DataSource = MemberDAO.GetAllMembers();
                }
                else
                {
                    MemberDAO.DeleteMember(Id);
                    dataGridView2.DataSource = MemberDAO.GetAllMembers();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmMain = new MainForAdmin();
            frmMain.Show();
            this.Hide();
        }
    }
}
