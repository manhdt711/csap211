using Q1.Models;

namespace Q1
{
    public partial class Form1 : Form
    {
        private readonly PE_PRN211_23SprB1Context _context = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Textboxes.ToList();
        }
    }
}