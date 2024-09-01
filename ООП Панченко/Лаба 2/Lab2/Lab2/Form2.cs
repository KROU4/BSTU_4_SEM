using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Lab2
{
    public partial class Form2 : Form
    {
        Form1 form1 = new();
        Form3 form3 = new();
        public Form2()
        {
            InitializeComponent();
        }

        private void goToForm1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void goToForm3_Click(object sender, EventArgs e)
        {
            form3.Show();
            this.Hide();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            experience.Text = trackBar1.Value.ToString();
        }

        private void create_Click(object sender, EventArgs e)
        {
            try
            {
                Lecturer lecturer = new(department.Text, FIO.Text, auditorium.Text, trackBar1.Value);
                MessageBox.Show($"Лектор {lecturer.fio} с кафедры {lecturer.department} со стажем работы {lecturer.experience} лет с аудитории {lecturer.auditorium} внесён в базу");
                Program.lastAction = "Создание лектора";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool validate(Lecturer lecturer)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(lecturer);
            if (!Validator.TryValidateObject(lecturer, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show($"Ошибка валидации: {error.ErrorMessage}");
                }
                return false;
            }
            else
            {
                MessageBox.Show("Валидация прошла успешно");
                return true;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
