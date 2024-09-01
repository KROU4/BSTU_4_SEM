namespace Lab2
{
    partial class Form3
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
            this.goToForm1 = new System.Windows.Forms.Button();
            this.goToForm2 = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.auther = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Create = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // goToForm1
            // 
            this.goToForm1.Location = new System.Drawing.Point(35, 26);
            this.goToForm1.Name = "goToForm1";
            this.goToForm1.Size = new System.Drawing.Size(107, 29);
            this.goToForm1.TabIndex = 0;
            this.goToForm1.Text = "Дисциплина";
            this.goToForm1.UseVisualStyleBackColor = true;
            this.goToForm1.Click += new System.EventHandler(this.goToForm1_Click);
            // 
            // goToForm2
            // 
            this.goToForm2.Location = new System.Drawing.Point(162, 26);
            this.goToForm2.Name = "goToForm2";
            this.goToForm2.Size = new System.Drawing.Size(99, 29);
            this.goToForm2.TabIndex = 1;
            this.goToForm2.Text = "Лектор";
            this.goToForm2.UseVisualStyleBackColor = true;
            this.goToForm2.Click += new System.EventHandler(this.goToForm2_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(35, 98);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(186, 27);
            this.name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Автор";
            // 
            // auther
            // 
            this.auther.Location = new System.Drawing.Point(35, 172);
            this.auther.Multiline = true;
            this.auther.Name = "auther";
            this.auther.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.auther.Size = new System.Drawing.Size(186, 46);
            this.auther.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Год";
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(35, 381);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(94, 29);
            this.Create.TabIndex = 8;
            this.Create.Text = "Создать";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(35, 259);
            this.numericUpDown.Maximum = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.numericUpDown.TabIndex = 9;
            this.numericUpDown.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 450);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.auther);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.goToForm2);
            this.Controls.Add(this.goToForm1);
            this.Name = "Form3";
            this.Text = "Литература";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button goToForm1;
        private Button goToForm2;
        private TextBox name;
        private Label label1;
        private Label label2;
        private TextBox auther;
        private Label label3;
        private Button Create;
        private NumericUpDown numericUpDown;
    }
}