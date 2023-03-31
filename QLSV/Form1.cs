using QLSV.Models;
using System.Linq;
using System.Xml.Linq;

namespace QLSV
{
    public partial class Form1 : Form
    {
        int Addbtn = 0;
        private readonly QLDIEM_HoTenSVContext _context = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.TblDiemSvs.ToList();

            // Add new column
            dataGridView1.Columns.Add("TotalScore", "Total Score");

            // Calculate total score for each row
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double diemChuyenCan = Convert.ToDouble(row.Cells["DiemChuyenCan"].Value);
                double diemGiuaKy = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value);
                double diemCuoiKy = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value);

                double totalScore = 0.1 * diemChuyenCan + 0.2 * diemGiuaKy + 0.7 * diemCuoiKy;
                row.Cells["TotalScore"].Value = Math.Round(totalScore, 2);
            }

        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtTen.ReadOnly = false;
            txtChuuyenCAN.ReadOnly = false;
            txtDiemGIUAKI.ReadOnly = false;
            txtTen.Enabled = true;
            txtCuopiki.ReadOnly = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            dateTimePicker1.Enabled = true;
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            btnGHIDULIEU.Enabled = true;
            btnHUY.Enabled = true;
            Addbtn = 5;
        }

        private void btnGHIDULIEU_Click(object sender, EventArgs e)
        {
            try
            {
                if (Addbtn == 10)
                {

                    bool ismale = radioButton1.Checked;
                    TblDiemSv ngu = _context.TblDiemSvs.FirstOrDefault(n => n.MaSv.Equals(txtID.Text));
                    ngu.TenSv = txtTen.Text;
                    ngu.DiemChuyenCan = decimal.Parse(txtChuuyenCAN.Text);
                    ngu.DiemCuoiKy = decimal.Parse(txtCuopiki.Text);
                    ngu.DiemGiuaKy = decimal.Parse(txtDiemGIUAKI.Text);
                    if (ismale)
                    {
                        ngu.GioiTinh = 1;
                    }
                    else
                    {
                        ngu.GioiTinh = 0;
                    }
                    ngu.NgaySinh = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    _context.Update(ngu);
                    _context.SaveChanges();
                    dataGridView1.DataSource = _context.TblDiemSvs.ToList();


                    // Calculate total score for each row
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        double diemChuyenCan = Convert.ToDouble(row.Cells["DiemChuyenCan"].Value);
                        double diemGiuaKy = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value);
                        double diemCuoiKy = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value);

                        double totalScore = 0.1 * diemChuyenCan + 0.2 * diemGiuaKy + 0.7 * diemCuoiKy;
                        row.Cells["TotalScore"].Value = Math.Round(totalScore, 2);
                    }
                    MessageBox.Show("update oce");
                    txtTen.ReadOnly = true;
                    txtChuuyenCAN.ReadOnly = true;
                    txtDiemGIUAKI.ReadOnly = true;
                    txtTen.Enabled = false;
                    txtCuopiki.ReadOnly = true;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    btnSUA.Enabled = true;
                    btnXOA.Enabled = true;
                    btnTHEM.Enabled = true;
                    txtID.Enabled = true;

                }
                else
                {
                    
                    bool ismale = radioButton1.Checked;
                    TblDiemSv ngu = new TblDiemSv();
                    int demsv = _context.TblDiemSvs.ToList().Count +1;
                    ngu.MaSv = "SV00" + demsv;
                    ngu.TenSv = txtTen.Text;
                    ngu.DiemChuyenCan = decimal.Parse(txtChuuyenCAN.Text);
                    ngu.DiemCuoiKy = decimal.Parse(txtCuopiki.Text);
                    ngu.DiemGiuaKy = decimal.Parse(txtDiemGIUAKI.Text);
                    if (ismale)
                    {
                        ngu.GioiTinh = 1;
                    }
                    else
                    {
                        ngu.GioiTinh = 0;
                    }
                    ngu.NgaySinh = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    _context.TblDiemSvs.Add(ngu);
                    _context.SaveChanges();
                    dataGridView1.DataSource = _context.TblDiemSvs.ToList();


                    // Calculate total score for each row
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        double diemChuyenCan = Convert.ToDouble(row.Cells["DiemChuyenCan"].Value);
                        double diemGiuaKy = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value);
                        double diemCuoiKy = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value);

                        double totalScore = 0.1 * diemChuyenCan + 0.2 * diemGiuaKy + 0.7 * diemCuoiKy;
                        row.Cells["TotalScore"].Value = Math.Round(totalScore, 2);
                    }
                    txtTen.ReadOnly = true;
                    txtChuuyenCAN.ReadOnly = true;
                    txtDiemGIUAKI.ReadOnly = true;
                    txtTen.Enabled = false;
                    txtCuopiki.ReadOnly = true;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    btnSUA.Enabled = true;
                    btnXOA.Enabled = true;
                    btnTHEM.Enabled = true;
                    txtID.Enabled = true;
                    MessageBox.Show("them oce");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtTen.ReadOnly = false;
            txtChuuyenCAN.ReadOnly = false;
            txtDiemGIUAKI.ReadOnly = false;
            txtTen.Enabled = true;
            txtCuopiki.ReadOnly = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            dateTimePicker1.Enabled = true;
            btnSUA.Enabled = Enabled;
            btnXOA.Enabled = false;
            btnGHIDULIEU.Enabled = true;
            btnHUY.Enabled = true;
            btnTHEM.Enabled = false;
            Addbtn = 10;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["GioiTinh"].Index && e.Value != null)
            {
                int sex = (int)dataGridView1.Rows[e.RowIndex].Cells["GioiTinh"].Value;
                if (sex == 1)
                {
                    e.Value = "Male";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "Female";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtID.Text = row.Cells["MaSV"].Value.ToString();
                txtTen.Text = row.Cells["TenSV"].Value.ToString();
                txtChuuyenCAN.Text = row.Cells["DiemChuyenCan"].Value.ToString();
                txtDiemGIUAKI.Text = row.Cells["DiemGiuaKy"].Value.ToString();
                txtCuopiki.Text = row.Cells["DiemCuoiKy"].Value.ToString();

                // Set RadioButton value
                if (row.Cells["GioiTinh"].Value.ToString() == "1")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }

                // Set DateTimePicker value
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            try
            {
                var ngu = _context.TblDiemSvs.FirstOrDefault(n => n.TenSv.Equals(txtTen.Text));
                _context.TblDiemSvs.Remove(ngu);
                _context.SaveChanges();
                dataGridView1.DataSource = _context.TblDiemSvs.ToList();


                // Calculate total score for each row
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    double diemChuyenCan = Convert.ToDouble(row.Cells["DiemChuyenCan"].Value);
                    double diemGiuaKy = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value);
                    double diemCuoiKy = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value);

                    double totalScore = 0.1 * diemChuyenCan + 0.2 * diemGiuaKy + 0.7 * diemCuoiKy;
                    row.Cells["TotalScore"].Value = Math.Round(totalScore, 2);
                }
            }
            catch (Exception rx)
            {
                MessageBox.Show(rx.Message);
            }
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            btnTHEM.Enabled = true;
            btnHUY.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnGHIDULIEU.Enabled = false;
            txtID.ReadOnly = false;
            txtTen.ReadOnly = false;
            txtDiemGIUAKI.ReadOnly = false;
            txtCuopiki.ReadOnly = false;
            txtChuuyenCAN.ReadOnly = false;
            txtDiemGIUAKI.ReadOnly = false;
            dateTimePicker1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }
    }
}