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
    public partial class MainForAdmin : Form
    {
        public MainForAdmin()
        {
            InitializeComponent();
        }

        private void btnManagerMem_Click(object sender, EventArgs e)
        {
            var formMember = new ManagerMember();
            formMember.Show();
            this.Hide();
        }

        private void btnManagerProduct_Click(object sender, EventArgs e)
        {
            var formMember = new ManagerProduct();
            formMember.Show();
            this.Hide();
        }

        private void btnManagerOrder_Click(object sender, EventArgs e)
        {
            var formMember = new ManagerOder();
            formMember.Show();
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
