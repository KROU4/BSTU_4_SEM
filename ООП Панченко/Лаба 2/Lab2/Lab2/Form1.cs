using System.Reflection.Emit;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.ApplicationServices;
using System.DirectoryServices;
using System.Text.Json;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public static List<Discipline> disciplineSort = new();
        public Form1()
        {
            InitializeComponent();
            lector.DataSource = Program.lecturer;
            checkedListBox.DataSource = Program.literature;
            timer1.Interval = 1000;
            timer1.Start();
            UpdateTime();
            monthCalendar1.MinDate = DateTime.Today;
            InitializeToolStrip();
        }

        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;

        private void BackButton_Click(object sender, EventArgs e)
        {
            DateTime newDate = monthCalendar1.SelectionStart.AddMonths(-1);
            if (newDate >= monthCalendar1.MinDate && newDate <= monthCalendar1.MaxDate)
            {
                monthCalendar1.SetDate(newDate);
            }
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            DateTime newDate = monthCalendar1.SelectionStart.AddMonths(1);
            if (newDate >= monthCalendar1.MinDate && newDate <= monthCalendar1.MaxDate)
            {
                monthCalendar1.SetDate(newDate);
            }
        }

        private void InitializeToolStrip()
        {
            toolStrip1 = new ToolStrip();
            toolStrip1.Dock = DockStyle.Bottom;

            ToolStripButton searchButton = new ToolStripButton("�����");
            searchButton.Click += searchbutton_Click;
            toolStrip1.Items.Add(searchButton);

            ToolStripButton sortButton = new ToolStripButton("����������");
            sortButton.Click += sortbutton_Click;
            toolStrip1.Items.Add(sortButton);

            ToolStripButton clearButton = new ToolStripButton("�������� ��");
            clearButton.Click += ClearButton_Click;
            toolStrip1.Items.Add(clearButton);

            ToolStripButton backButton = new ToolStripButton("�����");
            backButton.Click += BackButton_Click;
            toolStrip1.Items.Add(backButton);

            ToolStripButton forwardButton = new ToolStripButton("������");
            forwardButton.Click += ForwardButton_Click;
            toolStrip1.Items.Add(forwardButton);

            ToolStripButton toggleVisibilityButton = new ToolStripButton("������");
            toggleVisibilityButton.Click += ToggleVisibilityButton_Click;
            toolStrip1.Items.Add(toggleVisibilityButton);

            Controls.Add(toolStrip1);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
                Program.discipline.Clear();
                Program.lecturer.Clear();
                Program.literature.Clear();
                textBoxDiscipline.Clear();
        }

        private void ToggleVisibilityButton_Click(object sender, EventArgs e)
        {
                toolStrip1.Visible = !toolStrip1.Visible;
        }

        private void goToForm2_Click(object sender, EventArgs e)
        {
                Form2 form2 = new();
                form2.Show();
                this.Hide();
        }

        private void goToForm3_Click(object sender, EventArgs e)
        {
                Form3 form3 = new();
                form3.Show();
                this.Hide();
        }

        private void goToForm4_Click(object sender, EventArgs e)
        {
                Form4 form4 = new();
                form4.Show();
                this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                System.Windows.Forms.Application.Exit();
        }

        private void create_Click(object sender, EventArgs e)
        {
                List<Literature> selectedLiterature = new();

                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (checkedListBox.GetItemChecked(i))
                    {
                        selectedLiterature.Add(Program.literature[i]);
                    }
                }

                int? semestertext = string.IsNullOrEmpty(semester.Text) ? null : int.Parse(semester.Text);
                int? coursetext = string.IsNullOrEmpty(course.Text) ? null : int.Parse(course.Text);

                if (Program.lecturer.Count == 0 || Program.literature.Count == 0)
                {
                    MessageBox.Show("���� � ���� �� ������� ���������� � ��������, �� �� ������ ��������� ����������");
                    return;
                }

                try
                {
                    Discipline discipline = new(
                        nameOfDiscipline.Text,
                        semestertext,
                        coursetext,
                        specialization.Text,
                        (int)amountLections.Value,
                        (int)amountLabs.Value,
                        control.Text,
                        monthCalendar1.SelectionStart,
                        Program.lecturer[lector.SelectedIndex],
                        selectedLiterature
                    );
                    string? message = "";
                    DisplayDisciplines(discipline, ref message);
                    MessageBox.Show(message);
                    Program.lastAction = "�������� ����������";
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void writeDiscipline_Click(object sender, EventArgs e)
        {
                string? message = "";
                foreach (var item in Program.discipline)
                {
                    DisplayDisciplines(item, ref message);
                }
                textBoxDiscipline.Text = message;
                saveButton.Enabled = false;
                if (!string.IsNullOrEmpty(message))
                {
                    Program.lastAction = "����� ���������";
                }
        }

        private void textBoxDiscipline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private List<Discipline> searchResults = new List<Discipline>();
        private void searchbutton_Click(object sender, EventArgs e)
        {
                string? message = "";
                // ��� ��� ������
                if (radioButton7.Checked) // �� ���������� ����������
                {
                    disciplineSort.Clear();
                    string userInput = searchtext.Text.Trim();
                    string[] parts = userInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2 && int.TryParse(parts[1], out int repetitionCount))
                    {
                        string regexPattern = $"({Regex.Escape(parts[0])}){{{repetitionCount}}}";
                        if (radioButton3.Checked) // �� �������
                        {
                            foreach (var item in Program.discipline)
                            {
                                if (Regex.IsMatch(item.lecturer.fio, regexPattern))
                                {
                                    disciplineSort.Add(item);
                                    DisplayDisciplines(item, ref message);
                                    Program.lastAction = "����� ����������";
                                }
                            }
                        }
                        if (radioButton4.Checked) // �� ��������
                        {
                            foreach (var item in Program.discipline)
                            {
                                if (Regex.IsMatch(item.name, regexPattern))
                                {
                                    disciplineSort.Add(item);
                                    DisplayDisciplines(item, ref message);
                                    Program.lastAction = "����� ����������";
                                }
                            }
                        }
                        if (radioButton5.Checked) // �� �������������
                        {
                            foreach (var item in Program.discipline)
                            {
                                if (Regex.IsMatch(item.specialization, regexPattern))
                                {
                                    disciplineSort.Add(item);
                                    DisplayDisciplines(item, ref message);
                                    Program.lastAction = "����� ����������";
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("������������ ������.������� � ������� '� 3'");
                    }
                }
                else if (radioButton8.Checked) // ������ ������������
                {
                    disciplineSort.Clear();
                    string searchTerm = searchtext.Text.Trim();
                    string pattern = @"^" + Regex.Escape(searchTerm) + @"$";
                    Regex regex = new(pattern, RegexOptions.IgnoreCase);
                    if (radioButton3.Checked)
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.lecturer.fio))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                    if (radioButton4.Checked)
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.name))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                    if (radioButton5.Checked)
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.specialization))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                }
                else if (radioButton6.Checked) // �� ���������
                {
                    disciplineSort.Clear();
                    string inputText = searchtext.Text.Trim();
                    if (inputText.Length != 3 || inputText[1] != '-')
                    {
                        MessageBox.Show("������������ ������. ������� �������� � ������� 'a-z'.");
                        return;
                    }
                    char startChar = inputText[0];
                    char endChar = inputText[2];
                    if (startChar >= endChar)
                    {
                        MessageBox.Show("������������ ��������. ������ ������ ������ ���� ������ �������.");
                        return;
                    }
                    string regexPat = char.ToLower(startChar) + @"-" + char.ToLower(endChar) + char.ToUpper(startChar) + @"-" + char.ToUpper(endChar);
                    string regexPattern = @"^[" + Regex.Escape(regexPat) + @"]+$";

                    Regex regex = new(regexPattern);

                    if (radioButton3.Checked) // �� �������
                    {
                        foreach (var item in Program.discipline)
                        {
                            string cleanedFio = item.lecturer.fio.Replace(" ", "").Replace(".", "");
                            if (regex.IsMatch(cleanedFio))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                    else if (radioButton4.Checked) // �� ��������
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.name))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                    else if (radioButton5.Checked) // �� �������������
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.specialization))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                }
                else if (radioButton9.Checked) // ����� �����
                {
                    disciplineSort.Clear();
                    string searchTerm = searchtext.Text.Trim();
                    string pattern = @"\b\w*" + Regex.Escape(searchTerm) + @"\w*\b";
                    Regex regex = new(pattern, RegexOptions.IgnoreCase);
                    if (radioButton3.Checked)
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.lecturer.fio))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                    if (radioButton4.Checked)
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.name))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                    if (radioButton5.Checked)
                    {
                        foreach (var item in Program.discipline)
                        {
                            if (regex.IsMatch(item.specialization))
                            {
                                disciplineSort.Add(item);
                                DisplayDisciplines(item, ref message);
                                Program.lastAction = "����� ����������";
                            }
                        }
                    }
                }
                textBoxDiscipline.Text = message;
                if (string.IsNullOrEmpty(textBoxDiscipline.Text))
                {
                    saveButton.Enabled = false;
                }
                else
                {
                    saveButton.Enabled = true;
                }

            // ������� ��������� ���������� � ������ �����������
            foreach (var item in disciplineSort)
            {
                searchResults.Add(item);
            }

            if (searchResults.Count > 0) {
                savefinderButton.Enabled = true;
            }
        }

        private void savefinderButton_Click(object sender, EventArgs e)
        {

            // ���������� ���� ��� ���������� ����� JSON
            string filePath = "C:\\Users\\KROU4\\YandexDisk\\����\\��� ��������\\���� 2\\Lab2\\Lab2\\DisciplineFinder.json";

            try
            {
                string json = JsonSerializer.Serialize(searchResults, new JsonSerializerOptions { WriteIndented = true });

                // ���������� JSON-������ � ����
                File.WriteAllText(filePath, json);

                MessageBox.Show("���������� ������ ������� ��������� � ���� " + filePath, "���������� ���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("��������� ������ ��� ���������� ����������� ������: " + ex.Message, "������ ����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sortbutton_Click(object sender, EventArgs e)
        {
                string? message = "";
                Discipline[]? sortedDisciplines = null;
                if (sortComboBox.SelectedIndex == 0)
                {
                    sortedDisciplines = Program.discipline.OrderBy(d => d.amountoflections).ToArray();
                    foreach (var item in sortedDisciplines)
                    {
                        DisplayDisciplines(item, ref message);
                    }
                }
                else if (sortComboBox.SelectedIndex == 1)
                {
                    sortedDisciplines = Program.discipline.OrderBy(d => d.control).ToArray();
                    foreach (var item in sortedDisciplines)
                    {
                        DisplayDisciplines(item, ref message);
                    }
                }
                textBoxDiscipline.Text = message;
                disciplineSort.Clear();
                disciplineSort.AddRange(sortedDisciplines);
                if (string.IsNullOrEmpty(textBoxDiscipline.Text))
                {
                    saveButton.Enabled = false;
                }
                else
                {
                    saveButton.Enabled = true;
                    Program.lastAction = "���������� ���������";
                }
        }

        private void sortbutton3_Click(object sender, EventArgs e)
        {
            string? message = "";
            Discipline[]? sortedDisciplines = null;
            if (sortComboBox.SelectedIndex == 0)
            {
                sortedDisciplines = Program.discipline.OrderByDescending(d => d.amountoflections).ToArray();
                foreach (var item in sortedDisciplines)
                {
                    DisplayDisciplines(item, ref message);
                }
            }
            else if (sortComboBox.SelectedIndex == 1)
            {
                sortedDisciplines = Program.discipline.OrderByDescending(d => d.control).ToArray();
                foreach (var item in sortedDisciplines)
                {
                    DisplayDisciplines(item, ref message);
                }
            }
            textBoxDiscipline.Text = message;
            disciplineSort.Clear();
            disciplineSort.AddRange(sortedDisciplines);
            if (string.IsNullOrEmpty(textBoxDiscipline.Text))
            {
                saveButton.Enabled = false;
            }
            else
            {
                saveButton.Enabled = true;
                Program.lastAction = "���������� ���������";
            }
        }


        public static void DisplayDisciplines(Discipline item, ref string? message)
        {

                message += $"���������� {item.name}. ���������� �� {item.semester} �������� {item.course} �����.\r\n" +
                    $"���������� �� ������������� {item.specialization}.\r\n���-�� ������: {item.amountoflections}, ���-�� ������������: {item.amountoflabs}\r\n" +
                    $"�������� ({item.control}) ����� ����������� {item.date:dd.MM.yyyy}\r\n" +
                    $"������: {item.lecturer.fio} � ������� {item.lecturer.department}, ��������� {item.lecturer.auditorium}, ���� {item.lecturer.experience} ���\r\n" +
                    $"������ ����������: \r\n";
                foreach (var itemm in item.literature)
                {
                    message += $"{itemm.name} {itemm.year} ����. ������: \r\n";
                    foreach (var it in itemm.author)
                    {
                        message += $"{it}\r\n";
                    }
                }
                message += "\r\n--------------------------------\r\n";
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
                XmlSerializer formatter = new(typeof(List<Discipline>));
                using (FileStream fs = new("C:\\Users\\KROU4\\YandexDisk\\����\\��� ��������\\���� 2\\Lab2\\Lab2\\DisciplineSort.xml", FileMode.Create))
                {
                    formatter.Serialize(fs, Program.discipline);
                }
                Program.lastAction = "���������� ����������\n����������";
        }

        private void program_Click(object sender, EventArgs e)
        {
                MessageBox.Show("������� �. �.\n������ 1.3.3.7");
                Program.lastAction = "� ���������";
        }

        private void UpdateTime()
        {
            timeNow.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            amountOfDiscipline.Text = Program.discipline.Count.ToString();
            lastAction.Text = Program.lastAction;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}