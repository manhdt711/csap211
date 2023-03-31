using Q1.Models;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCB();
            loadLB();
        }
        public void loadCB()
        {
            using (var db = new PE_PRN_Fall22B1Context())
            {
                cbProducer.DataSource = db.Producers.Select(x => x.Name).ToList();
            }
        }
        public void loadLB()
        {
            using (var db = new PE_PRN_Fall22B1Context())
            {
                listBox1.DataSource = db.Genres.Select(x => x.Title).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new PE_PRN_Fall22B1Context())
            {
                Movie m = new Movie();
                m.Title = txtTitle.Text;
                m.ReleaseDate = DateTime.Parse(dtpRealease.Value.ToString("yyyy-MM-dd"));
                m.Description = txtDesc.Text;
                m.Language = txtLang.Text;
                Producer p = db.Producers.Where(x => x.Name == cbProducer.Text).FirstOrDefault();
                m.ProducerId = p.Id;

                db.Add(m);
                db.SaveChanges();
                MessageBox.Show("Add new movie successfully");
            }
        }
    }
}