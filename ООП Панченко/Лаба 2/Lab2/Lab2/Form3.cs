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

namespace Lab2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            name.GotFocus += RemoveFlag;
            auther.GotFocus += RemoveFlag;
        }

        private void goToForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new();
            form1.Show();
            this.Hide();
        }

        private void goToForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new();
            form2.Show();
            this.Hide();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string authorsText = auther.Text;
            string message;
            string[] authors = authorsText.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Literature? literature = new(name.Text, authors, (int)numericUpDown.Value);
                if (literature?.author?.Length == 1)
                {
                    message = $"Книга {literature.name} {literature.year} года добавлена в библиотеку, автор: {literature.author[0]}";
                }
                else
                {
                    message = $"Книга {literature.name} {literature.year} года добавлена в библиотеку, авторы:\n";
                    foreach (string? item in literature.author)
                    {
                        message += item + "\n";
                    }
                }
                MessageBox.Show(message);
                Program.lastAction = "Создание литературы";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void redFlag(Control control)
        {
            bool labelExists = false;
            foreach (Control existingControl in this.Controls)
            {
                if (existingControl is Label existingLabel &&
                    existingLabel.Left == control.Right + 5 &&
                    existingLabel.Top == control.Top + (control.Height - existingLabel.Height) / 2)
                {
                    labelExists = true;
                    break;
                }
            }

            if (!labelExists)
            {
                Label label = new();
                label.Text = "*";
                label.ForeColor = Color.Red;

                label.Left = control.Right + 5;
                label.Top = control.Top + (control.Height - label.Height) / 2;

                this.Controls.Add(label);
            }
        }
        private void RemoveFlag(object sender, EventArgs e)
        {
            Control activeControl = this.ActiveControl;

            if (activeControl != null)
            {
                int labelLeft = activeControl.Right + 5;
                int labelTop = activeControl.Top + (activeControl.Height - activeControl.Font.Height) / 2;

                System.Windows.Forms.Label labelToRemove = (System.Windows.Forms.Label)this.GetChildAtPoint(new Point(labelLeft, labelTop));

                if (labelToRemove != null)
                {
                    this.Controls.Remove(labelToRemove);
                }
            }
        }
    }
}
