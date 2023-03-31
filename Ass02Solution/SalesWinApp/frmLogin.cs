using BusinessObject;
using DataAccess;
using Newtonsoft.Json.Linq;
using SalesWinApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        private string _adminEmail;
        private string _adminPassword;
        public static Member mem { get; set; }
        public frmLogin()
        {
            InitializeComponent();

            // Read the AdminAccount settings from appsettings.json
            string json = File.ReadAllText("appsettings.json");
            var jObject = JObject.Parse(json);
            var adminAccount = jObject["AdminAccount"];
            _adminEmail = adminAccount["Email"].ToString();
            _adminPassword = adminAccount["Password"].ToString();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email = UserName.Text;
            string password = Password.Text;
            mem = MemberDAO.CheckLogin(email, password);
            if (email == _adminEmail && password == _adminPassword)
            {
                //loginthanh cong
                var Main = new MainForAdmin();
                Main.Show();
                this.Hide();
            }
            else if(mem != null)
            {
                var Main = new NomarlViewIn4();
                Main.Show();
                this.Hide();
            }
            else
            {
                //show error message
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
    }
