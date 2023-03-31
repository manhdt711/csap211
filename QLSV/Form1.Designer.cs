namespace QLSV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHUY = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnTHEM = new System.Windows.Forms.Button();
            this.btnSUA = new System.Windows.Forms.Button();
            this.btnXOA = new System.Windows.Forms.Button();
            this.btnGHIDULIEU = new System.Windows.Forms.Button();
            this.txtCuopiki = new System.Windows.Forms.TextBox();
            this.txtChuuyenCAN = new System.Windows.Forms.TextBox();
            this.txtDiemGIUAKI = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(529, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHUY);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.btnTHEM);
            this.groupBox1.Controls.Add(this.btnSUA);
            this.groupBox1.Controls.Add(this.btnXOA);
            this.groupBox1.Controls.Add(this.btnGHIDULIEU);
            this.groupBox1.Controls.Add(this.txtCuopiki);
            this.groupBox1.Controls.Add(this.txtChuuyenCAN);
            this.groupBox1.Controls.Add(this.txtDiemGIUAKI);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(577, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 380);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // btnHUY
            // 
            this.btnHUY.Enabled = false;
            this.btnHUY.Location = new System.Drawing.Point(235, 351);
            this.btnHUY.Name = "btnHUY";
            this.btnHUY.Size = new System.Drawing.Size(75, 23);
            this.btnHUY.TabIndex = 22;
            this.btnHUY.Text = "huybo";
            this.btnHUY.UseVisualStyleBackColor = true;
            this.btnHUY.Click += new System.EventHandler(this.btnHUY_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(163, 130);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 19);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.Text = "FEMALE";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(70, 127);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 19);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "MALE";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnTHEM
            // 
            this.btnTHEM.Location = new System.Drawing.Point(12, 328);
            this.btnTHEM.Name = "btnTHEM";
            this.btnTHEM.Size = new System.Drawing.Size(75, 23);
            this.btnTHEM.TabIndex = 18;
            this.btnTHEM.Text = "THEM";
            this.btnTHEM.UseVisualStyleBackColor = true;
            this.btnTHEM.Click += new System.EventHandler(this.btnTHEM_Click);
            // 
            // btnSUA
            // 
            this.btnSUA.Location = new System.Drawing.Point(12, 357);
            this.btnSUA.Name = "btnSUA";
            this.btnSUA.Size = new System.Drawing.Size(75, 23);
            this.btnSUA.TabIndex = 17;
            this.btnSUA.Text = "SUA";
            this.btnSUA.UseVisualStyleBackColor = true;
            this.btnSUA.Click += new System.EventHandler(this.btnSUA_Click);
            // 
            // btnXOA
            // 
            this.btnXOA.Location = new System.Drawing.Point(93, 339);
            this.btnXOA.Name = "btnXOA";
            this.btnXOA.Size = new System.Drawing.Size(75, 23);
            this.btnXOA.TabIndex = 16;
            this.btnXOA.Text = "XOA";
            this.btnXOA.UseVisualStyleBackColor = true;
            this.btnXOA.Click += new System.EventHandler(this.btnXOA_Click);
            // 
            // btnGHIDULIEU
            // 
            this.btnGHIDULIEU.Enabled = false;
            this.btnGHIDULIEU.Location = new System.Drawing.Point(235, 322);
            this.btnGHIDULIEU.Name = "btnGHIDULIEU";
            this.btnGHIDULIEU.Size = new System.Drawing.Size(75, 23);
            this.btnGHIDULIEU.TabIndex = 15;
            this.btnGHIDULIEU.Text = "chenDB";
            this.btnGHIDULIEU.UseVisualStyleBackColor = true;
            this.btnGHIDULIEU.Click += new System.EventHandler(this.btnGHIDULIEU_Click);
            // 
            // txtCuopiki
            // 
            this.txtCuopiki.Location = new System.Drawing.Point(98, 273);
            this.txtCuopiki.Name = "txtCuopiki";
            this.txtCuopiki.ReadOnly = true;
            this.txtCuopiki.Size = new System.Drawing.Size(100, 23);
            this.txtCuopiki.TabIndex = 14;
            // 
            // txtChuuyenCAN
            // 
            this.txtChuuyenCAN.Location = new System.Drawing.Point(141, 221);
            this.txtChuuyenCAN.Name = "txtChuuyenCAN";
            this.txtChuuyenCAN.ReadOnly = true;
            this.txtChuuyenCAN.Size = new System.Drawing.Size(100, 23);
            this.txtChuuyenCAN.TabIndex = 13;
            // 
            // txtDiemGIUAKI
            // 
            this.txtDiemGIUAKI.Location = new System.Drawing.Point(131, 170);
            this.txtDiemGIUAKI.Name = "txtDiemGIUAKI";
            this.txtDiemGIUAKI.ReadOnly = true;
            this.txtDiemGIUAKI.Size = new System.Drawing.Size(100, 23);
            this.txtDiemGIUAKI.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(70, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(57, 50);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(100, 23);
            this.txtTen.TabIndex = 9;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(31, 15);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 23);
            this.txtID.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Diem cuoi ky";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Diem chuyen Can";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Diem Giua Ky";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngaysinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "TenSV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button btnTHEM;
        private Button btnSUA;
        private Button btnXOA;
        private Button btnGHIDULIEU;
        private TextBox txtCuopiki;
        private TextBox txtChuuyenCAN;
        private TextBox txtDiemGIUAKI;
        private DateTimePicker dateTimePicker1;
        private TextBox txtTen;
        private TextBox txtID;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button btnHUY;
    }
}