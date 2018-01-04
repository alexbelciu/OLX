namespace OLX
{
    partial class Form1
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
            this.panel_up = new System.Windows.Forms.Panel();
            this.locationandstuff = new System.Windows.Forms.Panel();
            this.Search = new System.Windows.Forms.Button();
            this.Produs = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Oras = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Judet = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Account = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_up.SuspendLayout();
            this.locationandstuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_up
            // 
            this.panel_up.Controls.Add(this.locationandstuff);
            this.panel_up.Controls.Add(this.Account);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(1115, 122);
            this.panel_up.TabIndex = 0;
            // 
            // locationandstuff
            // 
            this.locationandstuff.Controls.Add(this.Search);
            this.locationandstuff.Controls.Add(this.Produs);
            this.locationandstuff.Controls.Add(this.textBox3);
            this.locationandstuff.Controls.Add(this.Oras);
            this.locationandstuff.Controls.Add(this.textBox2);
            this.locationandstuff.Controls.Add(this.Judet);
            this.locationandstuff.Controls.Add(this.textBox1);
            this.locationandstuff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.locationandstuff.Location = new System.Drawing.Point(0, 76);
            this.locationandstuff.Name = "locationandstuff";
            this.locationandstuff.Size = new System.Drawing.Size(1115, 46);
            this.locationandstuff.TabIndex = 1;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(631, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(58, 47);
            this.Search.TabIndex = 2;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.button2_Click);
            // 
            // Produs
            // 
            this.Produs.AutoSize = true;
            this.Produs.Location = new System.Drawing.Point(513, 17);
            this.Produs.Name = "Produs";
            this.Produs.Size = new System.Drawing.Size(40, 13);
            this.Produs.TabIndex = 5;
            this.Produs.Text = "Produs";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(406, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            // 
            // Oras
            // 
            this.Oras.AutoSize = true;
            this.Oras.Location = new System.Drawing.Point(345, 17);
            this.Oras.Name = "Oras";
            this.Oras.Size = new System.Drawing.Size(29, 13);
            this.Oras.TabIndex = 3;
            this.Oras.Text = "Oras";
            this.Oras.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(238, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // Judet
            // 
            this.Judet.AutoSize = true;
            this.Judet.Location = new System.Drawing.Point(169, 17);
            this.Judet.Name = "Judet";
            this.Judet.Size = new System.Drawing.Size(33, 13);
            this.Judet.TabIndex = 1;
            this.Judet.Text = "Judet";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(12, 23);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(58, 47);
            this.Account.TabIndex = 0;
            this.Account.Text = "Account";
            this.Account.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 328);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1115, 234);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 100);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1115, 100);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 608);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel_up);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_up.ResumeLayout(false);
            this.locationandstuff.ResumeLayout(false);
            this.locationandstuff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_up;
        private System.Windows.Forms.Panel locationandstuff;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label Produs;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label Oras;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Judet;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Account;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

