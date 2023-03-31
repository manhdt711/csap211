using Q2.Models;
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

namespace Q2
{
    public partial class Form1 : Form
    {
        private readonly PE_PRN_Sum21Context _context = new();
        public List<Employee> Employees = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _context.Employees.ToList();

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            string eName = textBox1.Text;
            string eSalary = numericUpDown1.Value.ToString();
            string Phone = textBox2.Text;
            bool isMale = radioButton1.Checked;
            try {
                Employee employee = new()
                {
                    EmployeeName = eName,
                    Male = isMale,
                    Salary = float.Parse(eSalary),
                    Phone = Phone,
                };
                _context.Employees.Add(employee);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (_context.SaveChanges() > 0)
            {
                MessageBox.Show("ok");
            }else
            {
                MessageBox.Show("not ok");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _context.Employees.ToList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Get the ID of the selected employee
                string employeeNAme = selectedRow.Cells["EmployeeName"].Value.ToString();

                // Retrieve the employee from the datasource
                Employee employee = _context.Employees.FirstOrDefault(e => e.EmployeeName == employeeNAme);

                // Remove the employee from the datasource
                _context.Employees.Remove(employee);

                // Save changes to the database
                _context.SaveChanges();

                // Reload the data in the datagridview
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _context.Employees.ToList();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["EmployeeName"].Value.ToString();
                numericUpDown1.Value = decimal.Parse(selectedRow.Cells["Salary"].Value.ToString());
                textBox2.Text = selectedRow.Cells["Phone"].Value.ToString();
                radioButton1.Checked = (bool)selectedRow.Cells["Male"].Value;
                radioButton2.Checked = !radioButton1.Checked;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Get the ID of the selected employee
                string employeeNAme = selectedRow.Cells["EmployeeName"].Value.ToString();

                // Retrieve the employee from the datasource
                Employee employee = _context.Employees.FirstOrDefault(e => e.EmployeeName == employeeNAme);

                // Update the employee information
                employee.EmployeeName = textBox1.Text;
                employee.Salary = float.Parse(numericUpDown1.Value.ToString());
                employee.Phone = textBox2.Text;
                if (radioButton1.Checked)
                {
                    employee.Male = true;
                }
                else
                {
                    employee.Male = false;
                }

                // Save changes to the database
               _context.SaveChanges();

                // Reload the data in the datagridview
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _context.Employees.ToList();
            }
        }
    }
}
