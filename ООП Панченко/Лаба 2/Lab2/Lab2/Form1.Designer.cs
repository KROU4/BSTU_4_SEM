namespace Lab2
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
            components = new System.ComponentModel.Container();
            goToForm2 = new Button();
            goToForm3 = new Button();
            label1 = new Label();
            nameOfDiscipline = new TextBox();
            course = new ComboBox();
            label2 = new Label();
            specialization = new ComboBox();
            label3 = new Label();
            amountLections = new NumericUpDown();
            label4 = new Label();
            amountLabs = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            control = new ComboBox();
            monthCalendar1 = new MonthCalendar();
            label7 = new Label();
            lector = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            checkedListBox = new CheckedListBox();
            create = new Button();
            goToForm4 = new Button();
            textBoxDiscipline = new TextBox();
            writeDiscipline = new Button();
            searchtext = new TextBox();
            searchbutton = new Button();
            label10 = new Label();
            groupBox2 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            groupBox3 = new GroupBox();
            radioButton9 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            sortComboBox = new ComboBox();
            label11 = new Label();
            sortbutton = new Button();
            saveButton = new Button();
            program = new Button();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            amountOfDiscipline = new Label();
            lastAction = new Label();
            timeNow = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            semester = new TextBox();
            label15 = new Label();
            savefinderButton = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)amountLections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountLabs).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // goToForm2
            // 
            goToForm2.Location = new Point(22, 16);
            goToForm2.Margin = new Padding(3, 2, 3, 2);
            goToForm2.Name = "goToForm2";
            goToForm2.Size = new Size(82, 22);
            goToForm2.TabIndex = 0;
            goToForm2.Text = "Лектор";
            goToForm2.UseVisualStyleBackColor = true;
            goToForm2.Click += goToForm2_Click;
            // 
            // goToForm3
            // 
            goToForm3.Location = new Point(124, 16);
            goToForm3.Margin = new Padding(3, 2, 3, 2);
            goToForm3.Name = "goToForm3";
            goToForm3.Size = new Size(93, 22);
            goToForm3.TabIndex = 1;
            goToForm3.Text = "Литература";
            goToForm3.UseVisualStyleBackColor = true;
            goToForm3.Click += goToForm3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 51);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 2;
            label1.Text = "Название";
            // 
            // nameOfDiscipline
            // 
            nameOfDiscipline.Location = new Point(22, 68);
            nameOfDiscipline.Margin = new Padding(3, 2, 3, 2);
            nameOfDiscipline.Name = "nameOfDiscipline";
            nameOfDiscipline.Size = new Size(149, 23);
            nameOfDiscipline.TabIndex = 3;
            // 
            // course
            // 
            course.DropDownStyle = ComboBoxStyle.DropDownList;
            course.FormattingEnabled = true;
            course.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            course.Location = new Point(22, 177);
            course.Margin = new Padding(3, 2, 3, 2);
            course.Name = "course";
            course.Size = new Size(149, 23);
            course.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 160);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 8;
            label2.Text = "Курс";
            // 
            // specialization
            // 
            specialization.DropDownStyle = ComboBoxStyle.DropDownList;
            specialization.FormattingEnabled = true;
            specialization.Items.AddRange(new object[] { "ИСиТ", "ПОИТ", "ПОИБМС", "ДЭиВИ" });
            specialization.Location = new Point(22, 226);
            specialization.Margin = new Padding(3, 2, 3, 2);
            specialization.Name = "specialization";
            specialization.Size = new Size(149, 23);
            specialization.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 208);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 10;
            label3.Text = "Специальность";
            // 
            // amountLections
            // 
            amountLections.Location = new Point(22, 280);
            amountLections.Margin = new Padding(3, 2, 3, 2);
            amountLections.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            amountLections.Name = "amountLections";
            amountLections.Size = new Size(149, 23);
            amountLections.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 262);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 12;
            label4.Text = "Количество лекций";
            // 
            // amountLabs
            // 
            amountLabs.Location = new Point(22, 328);
            amountLabs.Margin = new Padding(3, 2, 3, 2);
            amountLabs.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            amountLabs.Name = "amountLabs";
            amountLabs.Size = new Size(149, 23);
            amountLabs.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 311);
            label5.Name = "label5";
            label5.Size = new Size(156, 15);
            label5.TabIndex = 14;
            label5.Text = "Количество лабораторных";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 364);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 15;
            label6.Text = "Вид контроля";
            // 
            // control
            // 
            control.DropDownStyle = ComboBoxStyle.DropDownList;
            control.FormattingEnabled = true;
            control.Items.AddRange(new object[] { "Зачёт", "Экзамен" });
            control.Location = new Point(22, 382);
            control.Margin = new Padding(3, 2, 3, 2);
            control.Name = "control";
            control.Size = new Size(149, 23);
            control.TabIndex = 16;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(300, 245);
            monthCalendar1.Margin = new Padding(8, 7, 8, 7);
            monthCalendar1.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            monthCalendar1.MinDate = new DateTime(2024, 2, 27, 0, 0, 0, 0);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(300, 226);
            label7.Name = "label7";
            label7.Size = new Size(87, 15);
            label7.TabIndex = 18;
            label7.Text = "Дата контроля";
            // 
            // lector
            // 
            lector.DropDownStyle = ComboBoxStyle.DropDownList;
            lector.FormattingEnabled = true;
            lector.Location = new Point(300, 68);
            lector.Margin = new Padding(3, 2, 3, 2);
            lector.Name = "lector";
            lector.Size = new Size(168, 23);
            lector.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(300, 50);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 21;
            label8.Text = "Лектор";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(300, 105);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 22;
            label9.Text = "Литература";
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(301, 124);
            checkedListBox.Margin = new Padding(3, 2, 3, 2);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(168, 76);
            checkedListBox.TabIndex = 23;
            // 
            // create
            // 
            create.Location = new Point(201, 445);
            create.Margin = new Padding(3, 2, 3, 2);
            create.Name = "create";
            create.Size = new Size(82, 22);
            create.TabIndex = 24;
            create.Text = "Создать";
            create.UseVisualStyleBackColor = true;
            create.Click += create_Click;
            // 
            // goToForm4
            // 
            goToForm4.Location = new Point(239, 16);
            goToForm4.Margin = new Padding(3, 2, 3, 2);
            goToForm4.Name = "goToForm4";
            goToForm4.Size = new Size(90, 22);
            goToForm4.TabIndex = 25;
            goToForm4.Text = "Хранилище";
            goToForm4.UseVisualStyleBackColor = true;
            goToForm4.Click += goToForm4_Click;
            // 
            // textBoxDiscipline
            // 
            textBoxDiscipline.Location = new Point(540, 61);
            textBoxDiscipline.Margin = new Padding(3, 2, 3, 2);
            textBoxDiscipline.Multiline = true;
            textBoxDiscipline.Name = "textBoxDiscipline";
            textBoxDiscipline.ScrollBars = ScrollBars.Vertical;
            textBoxDiscipline.Size = new Size(225, 368);
            textBoxDiscipline.TabIndex = 26;
            textBoxDiscipline.KeyPress += textBoxDiscipline_KeyPress;
            // 
            // writeDiscipline
            // 
            writeDiscipline.Location = new Point(531, 16);
            writeDiscipline.Margin = new Padding(3, 2, 3, 2);
            writeDiscipline.Name = "writeDiscipline";
            writeDiscipline.Size = new Size(225, 22);
            writeDiscipline.TabIndex = 27;
            writeDiscipline.Text = "Вывести все дисциплины";
            writeDiscipline.UseVisualStyleBackColor = true;
            writeDiscipline.Click += writeDiscipline_Click;
            // 
            // searchtext
            // 
            searchtext.Location = new Point(795, 61);
            searchtext.Margin = new Padding(3, 2, 3, 2);
            searchtext.Name = "searchtext";
            searchtext.Size = new Size(187, 23);
            searchtext.TabIndex = 28;
            // 
            // searchbutton
            // 
            searchbutton.Location = new Point(988, 61);
            searchbutton.Margin = new Padding(3, 2, 3, 2);
            searchbutton.Name = "searchbutton";
            searchbutton.Size = new Size(27, 23);
            searchbutton.TabIndex = 29;
            searchbutton.Text = "🔎";
            searchbutton.UseVisualStyleBackColor = true;
            searchbutton.Click += searchbutton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(795, 44);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 30;
            label10.Text = "Поиск";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton5);
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Location = new Point(795, 97);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(211, 94);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Критерии поиска";
            groupBox2.UseCompatibleTextRendering = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(5, 64);
            radioButton5.Margin = new Padding(3, 2, 3, 2);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(128, 19);
            radioButton5.TabIndex = 2;
            radioButton5.Text = "По специальности";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(5, 42);
            radioButton4.Margin = new Padding(3, 2, 3, 2);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(98, 19);
            radioButton4.TabIndex = 1;
            radioButton4.Text = "По названию";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(5, 20);
            radioButton3.Margin = new Padding(3, 2, 3, 2);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(88, 19);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "По лектору";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton9);
            groupBox3.Controls.Add(radioButton6);
            groupBox3.Controls.Add(radioButton7);
            groupBox3.Controls.Add(radioButton8);
            groupBox3.Location = new Point(795, 209);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(212, 116);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "Критерии поиска";
            groupBox3.UseCompatibleTextRendering = true;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new Point(5, 87);
            radioButton9.Margin = new Padding(3, 2, 3, 2);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new Size(91, 19);
            radioButton9.TabIndex = 3;
            radioButton9.Text = "Часть слова";
            radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(5, 64);
            radioButton6.Margin = new Padding(3, 2, 3, 2);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(101, 19);
            radioButton6.TabIndex = 2;
            radioButton6.Text = "По диапазону";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(5, 42);
            radioButton7.Margin = new Padding(3, 2, 3, 2);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(176, 19);
            radioButton7.TabIndex = 1;
            radioButton7.Text = "По количеству повторений";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Checked = true;
            radioButton8.Location = new Point(5, 20);
            radioButton8.Margin = new Padding(3, 2, 3, 2);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(143, 19);
            radioButton8.TabIndex = 0;
            radioButton8.TabStop = true;
            radioButton8.Text = "Полное соответствие";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // sortComboBox
            // 
            sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortComboBox.FormattingEnabled = true;
            sortComboBox.Items.AddRange(new object[] { "Количеству лекций", "Виду контроля" });
            sortComboBox.Location = new Point(795, 354);
            sortComboBox.Margin = new Padding(3, 2, 3, 2);
            sortComboBox.Name = "sortComboBox";
            sortComboBox.Size = new Size(187, 23);
            sortComboBox.TabIndex = 33;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(795, 337);
            label11.Name = "label11";
            label11.Size = new Size(90, 15);
            label11.TabIndex = 34;
            label11.Text = "Сортировка по";
            // 
            // sortbutton
            // 
            sortbutton.Location = new Point(988, 354);
            sortbutton.Margin = new Padding(3, 2, 3, 2);
            sortbutton.Name = "sortbutton";
            sortbutton.Size = new Size(27, 25);
            sortbutton.TabIndex = 35;
            sortbutton.Text = "🔎";
            sortbutton.UseVisualStyleBackColor = true;
            sortbutton.Click += sortbutton_Click;
            // 
            // saveButton
            // 
            saveButton.Enabled = false;
            saveButton.Location = new Point(796, 395);
            saveButton.Margin = new Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(211, 22);
            saveButton.TabIndex = 36;
            saveButton.Text = "Сохранить сортировку";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // program
            // 
            program.Location = new Point(929, 445);
            program.Margin = new Padding(3, 2, 3, 2);
            program.Name = "program";
            program.Size = new Size(133, 22);
            program.TabIndex = 37;
            program.Text = "О программе";
            program.UseVisualStyleBackColor = true;
            program.Click += program_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1059, 23);
            label12.Name = "label12";
            label12.Size = new Size(126, 15);
            label12.TabIndex = 38;
            label12.Text = "Количество объектов";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1059, 70);
            label13.Name = "label13";
            label13.Size = new Size(119, 15);
            label13.TabIndex = 39;
            label13.Text = "Последнее действие";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1124, 425);
            label14.Name = "label14";
            label14.Size = new Size(91, 15);
            label14.TabIndex = 40;
            label14.Text = "Текущее время";
            // 
            // amountOfDiscipline
            // 
            amountOfDiscipline.AutoSize = true;
            amountOfDiscipline.Location = new Point(1059, 46);
            amountOfDiscipline.Name = "amountOfDiscipline";
            amountOfDiscipline.Size = new Size(13, 15);
            amountOfDiscipline.TabIndex = 41;
            amountOfDiscipline.Text = "0";
            // 
            // lastAction
            // 
            lastAction.AutoSize = true;
            lastAction.Location = new Point(1059, 94);
            lastAction.Name = "lastAction";
            lastAction.Size = new Size(12, 15);
            lastAction.TabIndex = 42;
            lastAction.Text = "-";
            // 
            // timeNow
            // 
            timeNow.AutoSize = true;
            timeNow.Location = new Point(1127, 448);
            timeNow.Name = "timeNow";
            timeNow.Size = new Size(12, 15);
            timeNow.TabIndex = 43;
            timeNow.Text = "-";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // semester
            // 
            semester.Location = new Point(22, 122);
            semester.Margin = new Padding(3, 2, 3, 2);
            semester.Name = "semester";
            semester.Size = new Size(149, 23);
            semester.TabIndex = 44;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(22, 105);
            label15.Name = "label15";
            label15.Size = new Size(54, 15);
            label15.TabIndex = 45;
            label15.Text = "Семестр";
            // 
            // savefinderButton
            // 
            savefinderButton.Enabled = false;
            savefinderButton.Location = new Point(796, 19);
            savefinderButton.Margin = new Padding(3, 2, 3, 2);
            savefinderButton.Name = "savefinderButton";
            savefinderButton.Size = new Size(211, 22);
            savefinderButton.TabIndex = 46;
            savefinderButton.Text = "Сохранить поиск";
            savefinderButton.UseVisualStyleBackColor = true;
            savefinderButton.Click += savefinderButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1021, 354);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(27, 25);
            button1.TabIndex = 47;
            button1.Text = "🔎";
            button1.UseVisualStyleBackColor = true;
            button1.Click += sortbutton3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 512);
            Controls.Add(button1);
            Controls.Add(savefinderButton);
            Controls.Add(label15);
            Controls.Add(semester);
            Controls.Add(timeNow);
            Controls.Add(lastAction);
            Controls.Add(amountOfDiscipline);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(program);
            Controls.Add(saveButton);
            Controls.Add(sortbutton);
            Controls.Add(label11);
            Controls.Add(sortComboBox);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label10);
            Controls.Add(searchbutton);
            Controls.Add(searchtext);
            Controls.Add(writeDiscipline);
            Controls.Add(textBoxDiscipline);
            Controls.Add(goToForm4);
            Controls.Add(create);
            Controls.Add(checkedListBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(lector);
            Controls.Add(label7);
            Controls.Add(monthCalendar1);
            Controls.Add(control);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(amountLabs);
            Controls.Add(label4);
            Controls.Add(amountLections);
            Controls.Add(label3);
            Controls.Add(specialization);
            Controls.Add(label2);
            Controls.Add(course);
            Controls.Add(nameOfDiscipline);
            Controls.Add(label1);
            Controls.Add(goToForm3);
            Controls.Add(goToForm2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Дисциплина";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)amountLections).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountLabs).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button goToForm2;
        private Button goToForm3;
        private Label label1;
        private TextBox nameOfDiscipline;
        private ComboBox course;
        private Label label2;
        private ComboBox specialization;
        private Label label3;
        private NumericUpDown amountLections;
        private Label label4;
        private NumericUpDown amountLabs;
        private Label label5;
        private Label label6;
        private ComboBox control;
        private MonthCalendar monthCalendar1;
        private Label label7;
        private ComboBox lector;
        private Label label8;
        private Label label9;
        private CheckedListBox checkedListBox;
        private Button create;
        private Button goToForm4;
        private TextBox textBoxDiscipline;
        private Button writeDiscipline;
        private TextBox searchtext;
        private Button searchbutton;
        private Label label10;
        private GroupBox groupBox2;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private GroupBox groupBox3;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private ComboBox sortComboBox;
        private Label label11;
        private Button sortbutton;
        private Button saveButton;
        private Button program;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label amountOfDiscipline;
        private Label lastAction;
        private Label timeNow;
        private System.Windows.Forms.Timer timer1;
        private TextBox semester;
        private Label label15;
        private Button savefinderButton;
        private Button button1;
    }
}