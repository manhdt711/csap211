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
    public partial class ViewOderHis : Form
    {
        public ViewOderHis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmNormalupdate = new NomarlViewIn4();
            frmNormalupdate.Show();
            this.Hide();
        }

        private void ViewOderHis_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = OrderDetailDAO.GetOrderbyMemberID(frmLogin.mem.MemberID);
        }
    }
}
