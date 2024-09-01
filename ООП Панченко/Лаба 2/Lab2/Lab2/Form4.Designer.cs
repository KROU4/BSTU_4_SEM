namespace Lab2
{
    partial class Form4
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
            goToForm1 = new Button();
            textBox1 = new TextBox();
            saveObjects = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            readObjects = new ComboBox();
            button2 = new Button();
            download = new Button();
            SuspendLayout();
            // 
            // goToForm1
            // 
            goToForm1.Location = new Point(25, 12);
            goToForm1.Name = "goToForm1";
            goToForm1.Size = new Size(123, 29);
            goToForm1.TabIndex = 0;
            goToForm1.Text = "Дисциплина";
            goToForm1.UseVisualStyleBackColor = true;
            goToForm1.Click += goToForm1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(371, 51);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(287, 511);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // saveObjects
            // 
            saveObjects.DropDownStyle = ComboBoxStyle.DropDownList;
            saveObjects.FormattingEnabled = true;
            saveObjects.Items.AddRange(new object[] { "Дисциплины", "Лекторы", "Литература" });
            saveObjects.Location = new Point(25, 133);
            saveObjects.Name = "saveObjects";
            saveObjects.Size = new Size(151, 28);
            saveObjects.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(25, 67);
            label1.Name = "label1";
            label1.Size = new Size(241, 28);
            label1.TabIndex = 3;
            label1.Text = "Сохранить в json формат";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(25, 111);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 4;
            label2.Text = "Объекты";
            // 
            // button1
            // 
            button1.Location = new Point(25, 183);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 7;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(25, 373);
            label4.Name = "label4";
            label4.Size = new Size(261, 28);
            label4.TabIndex = 8;
            label4.Text = "Прочитать из json формата";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(25, 417);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 9;
            label5.Text = "Объекты";
            // 
            // readObjects
            // 
            readObjects.DropDownStyle = ComboBoxStyle.DropDownList;
            readObjects.FormattingEnabled = true;
            readObjects.Items.AddRange(new object[] { "Дисциплины", "Лекторы", "Литература" });
            readObjects.Location = new Point(25, 440);
            readObjects.Name = "readObjects";
            readObjects.Size = new Size(151, 28);
            readObjects.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(25, 485);
            button2.Name = "button2";
            button2.Size = new Size(151, 29);
            button2.TabIndex = 11;
            button2.Text = "Прочитать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // download
            // 
            download.Location = new Point(478, 568);
            download.Name = "download";
            download.Size = new Size(94, 29);
            download.TabIndex = 12;
            download.Text = "Загрузить";
            download.UseVisualStyleBackColor = true;
            download.Click += download_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 613);
            Controls.Add(download);
            Controls.Add(button2);
            Controls.Add(readObjects);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(saveObjects);
            Controls.Add(textBox1);
            Controls.Add(goToForm1);
            Name = "Form4";
            Text = "Хранилище";
            Activated += Form4_Activated;
            FormClosing += Form4_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button goToForm1;
        private TextBox textBox1;
        private ComboBox saveObjects;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label4;
        private Label label5;
        private ComboBox readObjects;
        private Button button2;
        private Button download;
    }
}