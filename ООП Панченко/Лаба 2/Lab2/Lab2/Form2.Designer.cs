namespace Lab2
{
    partial class Form2
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
            this.goToForm3 = new System.Windows.Forms.Button();
            this.department = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.auditorium = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.experience = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // goToForm1
            // 
            this.goToForm1.Location = new System.Drawing.Point(35, 24);
            this.goToForm1.Name = "goToForm1";
            this.goToForm1.Size = new System.Drawing.Size(110, 29);
            this.goToForm1.TabIndex = 0;
            this.goToForm1.Text = "Дисциплина";
            this.goToForm1.UseVisualStyleBackColor = true;
            this.goToForm1.Click += new System.EventHandler(this.goToForm1_Click);
            // 
            // goToForm3
            // 
            this.goToForm3.Location = new System.Drawing.Point(176, 24);
            this.goToForm3.Name = "goToForm3";
            this.goToForm3.Size = new System.Drawing.Size(114, 29);
            this.goToForm3.TabIndex = 1;
            this.goToForm3.Text = "Литература";
            this.goToForm3.UseVisualStyleBackColor = true;
            this.goToForm3.Click += new System.EventHandler(this.goToForm3_Click);
            // 
            // department
            // 
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.FormattingEnabled = true;
            this.department.Items.AddRange(new object[] {
            "Информационных систем и технологий",
            "Информатики и веб-дизайна",
            "Программной инженерии",
            "Физики",
            "Инженерной графики",
            "Высшей математики"});
            this.department.Location = new System.Drawing.Point(35, 105);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(337, 28);
            this.department.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кафедра";
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(35, 169);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(337, 27);
            this.FIO.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "ФИО";
            // 
            // auditorium
            // 
            this.auditorium.Location = new System.Drawing.Point(35, 232);
            this.auditorium.Name = "auditorium";
            this.auditorium.Size = new System.Drawing.Size(337, 27);
            this.auditorium.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Аудитория";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Стаж";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(176, 425);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(94, 29);
            this.create.TabIndex = 12;
            this.create.Text = "Создать";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(35, 297);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(370, 56);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // experience
            // 
            this.experience.AutoSize = true;
            this.experience.Location = new System.Drawing.Point(128, 274);
            this.experience.Name = "experience";
            this.experience.Size = new System.Drawing.Size(17, 20);
            this.experience.TabIndex = 14;
            this.experience.Text = "0";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 477);
            this.Controls.Add(this.experience);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.auditorium);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.goToForm3);
            this.Controls.Add(this.goToForm1);
            this.Name = "Form2";
            this.Text = "Лектор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button goToForm1;
        private Button goToForm3;
        private ComboBox department;
        private Label label1;
        private TextBox FIO;
        private Label label2;
        private TextBox auditorium;
        private Label label3;
        private Label label4;
        private Button create;
        private TrackBar trackBar1;
        private Label experience;
    }
}