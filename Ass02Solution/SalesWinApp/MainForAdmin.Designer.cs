namespace SalesWinApp
{
    partial class MainForAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManagerMem = new System.Windows.Forms.Button();
            this.btnManagerProduct = new System.Windows.Forms.Button();
            this.btnManagerOrder = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagerMem
            // 
            this.btnManagerMem.Location = new System.Drawing.Point(48, 86);
            this.btnManagerMem.Name = "btnManagerMem";
            this.btnManagerMem.Size = new System.Drawing.Size(86, 45);
            this.btnManagerMem.TabIndex = 0;
            this.btnManagerMem.Text = "Manager Member";
            this.btnManagerMem.UseVisualStyleBackColor = true;
            this.btnManagerMem.Click += new System.EventHandler(this.btnManagerMem_Click);
            // 
            // btnManagerProduct
            // 
            this.btnManagerProduct.Location = new System.Drawing.Point(218, 86);
            this.btnManagerProduct.Name = "btnManagerProduct";
            this.btnManagerProduct.Size = new System.Drawing.Size(90, 45);
            this.btnManagerProduct.TabIndex = 1;
            this.btnManagerProduct.Text = "Manager Product";
            this.btnManagerProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManagerProduct.UseVisualStyleBackColor = true;
            this.btnManagerProduct.Click += new System.EventHandler(this.btnManagerProduct_Click);
            // 
            // btnManagerOrder
            // 
            this.btnManagerOrder.Location = new System.Drawing.Point(48, 198);
            this.btnManagerOrder.Name = "btnManagerOrder";
            this.btnManagerOrder.Size = new System.Drawing.Size(87, 61);
            this.btnManagerOrder.TabIndex = 2;
            this.btnManagerOrder.Text = "Manager Order";
            this.btnManagerOrder.UseVisualStyleBackColor = true;
            this.btnManagerOrder.Click += new System.EventHandler(this.btnManagerOrder_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(255, 327);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 375);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManagerOrder);
            this.Controls.Add(this.btnManagerProduct);
            this.Controls.Add(this.btnManagerMem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForAdmin";
            this.Text = "MainForAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagerMem;
        private System.Windows.Forms.Button btnManagerProduct;
        private System.Windows.Forms.Button btnManagerOrder;
        private System.Windows.Forms.Button btnLogout;
    }
}