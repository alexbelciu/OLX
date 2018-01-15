namespace OLX
{
    partial class AddAnunt
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
            this.label1 = new System.Windows.Forms.Label();
            this.tboxTitlu = new System.Windows.Forms.TextBox();
            this.tboxStare = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCategorie = new System.Windows.Forms.ComboBox();
            this.comboBoxSubcategorie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxNegociabil = new System.Windows.Forms.CheckBox();
            this.tboxDescriere = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdaugaAnunt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCautaFoto = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBoxLocIntalnire = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titlu";
            // 
            // tboxTitlu
            // 
            this.tboxTitlu.Location = new System.Drawing.Point(138, 56);
            this.tboxTitlu.Name = "tboxTitlu";
            this.tboxTitlu.Size = new System.Drawing.Size(306, 20);
            this.tboxTitlu.TabIndex = 1;
            // 
            // tboxStare
            // 
            this.tboxStare.Location = new System.Drawing.Point(138, 93);
            this.tboxStare.Name = "tboxStare";
            this.tboxStare.Size = new System.Drawing.Size(208, 20);
            this.tboxStare.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categorie";
            // 
            // comboBoxCategorie
            // 
            this.comboBoxCategorie.FormattingEnabled = true;
            this.comboBoxCategorie.Location = new System.Drawing.Point(138, 128);
            this.comboBoxCategorie.Name = "comboBoxCategorie";
            this.comboBoxCategorie.Size = new System.Drawing.Size(208, 21);
            this.comboBoxCategorie.TabIndex = 5;
            this.comboBoxCategorie.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategorie_SelectedIndexChanged);
            // 
            // comboBoxSubcategorie
            // 
            this.comboBoxSubcategorie.FormattingEnabled = true;
            this.comboBoxSubcategorie.Location = new System.Drawing.Point(138, 166);
            this.comboBoxSubcategorie.Name = "comboBoxSubcategorie";
            this.comboBoxSubcategorie.Size = new System.Drawing.Size(208, 21);
            this.comboBoxSubcategorie.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subcategorie";
            // 
            // tboxPret
            // 
            this.tboxPret.Location = new System.Drawing.Point(138, 200);
            this.tboxPret.Name = "tboxPret";
            this.tboxPret.Size = new System.Drawing.Size(100, 20);
            this.tboxPret.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pret";
            // 
            // cboxNegociabil
            // 
            this.cboxNegociabil.AutoSize = true;
            this.cboxNegociabil.Location = new System.Drawing.Point(280, 206);
            this.cboxNegociabil.Name = "cboxNegociabil";
            this.cboxNegociabil.Size = new System.Drawing.Size(76, 17);
            this.cboxNegociabil.TabIndex = 10;
            this.cboxNegociabil.Text = "Negociabil";
            this.cboxNegociabil.UseVisualStyleBackColor = true;
            // 
            // tboxDescriere
            // 
            this.tboxDescriere.Location = new System.Drawing.Point(138, 229);
            this.tboxDescriere.Multiline = true;
            this.tboxDescriere.Name = "tboxDescriere";
            this.tboxDescriere.Size = new System.Drawing.Size(218, 138);
            this.tboxDescriere.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Descriere";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Loc intalnire";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(474, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 76);
            this.panel1.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Adaugare anunt";
            // 
            // btnAdaugaAnunt
            // 
            this.btnAdaugaAnunt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdaugaAnunt.Location = new System.Drawing.Point(379, 563);
            this.btnAdaugaAnunt.Name = "btnAdaugaAnunt";
            this.btnAdaugaAnunt.Size = new System.Drawing.Size(124, 44);
            this.btnAdaugaAnunt.TabIndex = 16;
            this.btnAdaugaAnunt.Text = "Adauga anunt!";
            this.btnAdaugaAnunt.UseVisualStyleBackColor = false;
            this.btnAdaugaAnunt.Click += new System.EventHandler(this.btnAdaugaAnunt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(138, 472);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCautaFoto
            // 
            this.btnCautaFoto.Location = new System.Drawing.Point(43, 512);
            this.btnCautaFoto.Name = "btnCautaFoto";
            this.btnCautaFoto.Size = new System.Drawing.Size(84, 48);
            this.btnCautaFoto.TabIndex = 19;
            this.btnCautaFoto.Text = "Incarca fotografie";
            this.btnCautaFoto.UseVisualStyleBackColor = true;
            this.btnCautaFoto.Click += new System.EventHandler(this.btnCautaFoto_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(379, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 388);
            this.panel2.TabIndex = 20;
            // 
            // richTextBoxLocIntalnire
            // 
            this.richTextBoxLocIntalnire.Location = new System.Drawing.Point(138, 393);
            this.richTextBoxLocIntalnire.Name = "richTextBoxLocIntalnire";
            this.richTextBoxLocIntalnire.Size = new System.Drawing.Size(218, 54);
            this.richTextBoxLocIntalnire.TabIndex = 21;
            this.richTextBoxLocIntalnire.Text = "";
            // 
            // AddAnunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 630);
            this.Controls.Add(this.richTextBoxLocIntalnire);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCautaFoto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAdaugaAnunt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tboxDescriere);
            this.Controls.Add(this.cboxNegociabil);
            this.Controls.Add(this.tboxPret);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxSubcategorie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxCategorie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxStare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxTitlu);
            this.Controls.Add(this.label1);
            this.Name = "AddAnunt";
            this.Text = "AddAnunt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxTitlu;
        private System.Windows.Forms.TextBox tboxStare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCategorie;
        private System.Windows.Forms.ComboBox comboBoxSubcategorie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxPret;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboxNegociabil;
        private System.Windows.Forms.TextBox tboxDescriere;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdaugaAnunt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCautaFoto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBoxLocIntalnire;
    }
}