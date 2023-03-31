using Q2.Models;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        private readonly PE_PRN211_23SprB1Context _context = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Students.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isMale = radioMale.Checked;
            Student s = new Student();
            s.Fullname = txtName.Text;
            if(isMale)
            {
                s.Sex = "male";
            }
            else
            {
                s.Sex = "female";
            }
            s.Dob = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            s.Email = txtEmail.Text;
            _context.Students.Add(s);
            _context.SaveChanges();
            dataGridView1.DataSource = _context.Students.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtID.Text = selectedRow.Cells["id"].Value.ToString();
                txtName.Text = selectedRow.Cells["Fullname"].Value.ToString();
                radioMale.Checked = (bool)selectedRow.Cells["Sex"].Value.Equals("male");
                radioFemale.Checked = !radioMale.Checked;
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isMale = radioMale.Checked;
            Student s = new Student();
            s.Fullname = txtName.Text;
            if (isMale)
            {
                s.Sex = "male";
            }
            else
            {
                s.Sex = "female";
            }
            s.Dob = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            s.Email = txtEmail.Text;

            _context.SaveChanges();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _context.Students.ToList();
        }
    }
}