namespace Q1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dtpRealease = new System.Windows.Forms.DateTimePicker();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtLang = new System.Windows.Forms.TextBox();
            this.cbProducer = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Genres = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ReleaseDate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Language";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Producer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add new movie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(122, 52);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(282, 23);
            this.txtTitle.TabIndex = 6;
            // 
            // dtpRealease
            // 
            this.dtpRealease.Location = new System.Drawing.Point(125, 126);
            this.dtpRealease.Name = "dtpRealease";
            this.dtpRealease.Size = new System.Drawing.Size(279, 23);
            this.dtpRealease.TabIndex = 7;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(125, 201);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(279, 88);
            this.txtDesc.TabIndex = 8;
            // 
            // txtLang
            // 
            this.txtLang.Location = new System.Drawing.Point(125, 305);
            this.txtLang.Name = "txtLang";
            this.txtLang.Size = new System.Drawing.Size(279, 23);
            this.txtLang.TabIndex = 9;
            // 
            // cbProducer
            // 
            this.cbProducer.FormattingEnabled = true;
            this.cbProducer.Location = new System.Drawing.Point(122, 354);
            this.cbProducer.Name = "cbProducer";
            this.cbProducer.Size = new System.Drawing.Size(282, 23);
            this.cbProducer.TabIndex = 10;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(511, 103);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(276, 274);
            this.listBox1.TabIndex = 11;
            // 
            // Genres
            // 
            this.Genres.AutoSize = true;
            this.Genres.Location = new System.Drawing.Point(511, 60);
            this.Genres.Name = "Genres";
            this.Genres.Size = new System.Drawing.Size(38, 15);
            this.Genres.TabIndex = 12;
            this.Genres.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 531);
            this.Controls.Add(this.Genres);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cbProducer);
            this.Controls.Add(this.txtLang);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.dtpRealease);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private TextBox txtTitle;
        private DateTimePicker dtpRealease;
        private TextBox txtDesc;
        private TextBox txtLang;
        private ComboBox cbProducer;
        private ListBox listBox1;
        private Label Genres;
    }
}