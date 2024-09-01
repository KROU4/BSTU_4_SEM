using System.Text;
using System.Text.Json;

namespace Lab2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            readObjects.GotFocus += RemoveFlag;
            saveObjects.GotFocus += RemoveFlag;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void goToForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkSave())
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string filePath;
                switch (saveObjects.SelectedIndex)
                {
                    case 0:
                        filePath = "Discipline.json";
                        break;
                    case 1:
                        filePath = "Lecturer.json";
                        break;
                    case 2:
                        filePath = "Literature.json";
                        break;
                    default:
                        return;
                }

                try
                {
                    string jsonData = JsonSerializer.Serialize(GetDataForSerialization(saveObjects.SelectedIndex), options);
                    File.WriteAllText(filePath, jsonData);
                    Program.lastAction = "Сохранение объектов";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<object> GetDataForSerialization(int index)
        {
            switch (index)
            {
                case 0:
                    return Program.discipline.Cast<object>().ToList();
                case 1:
                    return Program.lecturer.Cast<object>().ToList();
                case 2:
                    return Program.literature.Cast<object>().ToList();
                default:
                    return new List<object>();
            }
        }


        private bool checkSave()
        {
            bool flag = true;
            if (saveObjects.SelectedItem == null)
            {
                flag = false;
                redFlag(saveObjects);
            }
            return flag;
        }

        private void redFlag(Control control)
        {
            bool labelExists = Controls.OfType<Label>()
                                       .Any(l => l.Left == control.Right + 5 && l.Top == control.Top + (control.Height - l.Height) / 2);

            if (!labelExists)
            {
                Label label = new Label();
                label.Text = "*";
                label.ForeColor = Color.Red;
                label.Left = control.Right + 5;
                label.Top = control.Top + (control.Height - label.Height) / 2;
                Controls.Add(label);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkRead())
            {
                List<object> newData = GetDataForDeserialization(readObjects.SelectedIndex);
                DisplayData(newData);

                download.Enabled = true;

                Program.lastAction = "Чтение объектов";

                switch (readObjects.SelectedIndex)
                {
                    case 0:
                        download.Click -= (sender, e) => downloadDiscipline(sender, e, newData.Cast<Discipline>().ToList());
                        download.Click -= (sender, e) => downloadLiterature(sender, e, newData.Cast<Literature>().ToList());
                        download.Click += (sender, e) => downloadDiscipline(sender, e, newData.Cast<Discipline>().ToList());
                        break;
                    case 1:
                        download.Click -= (sender, e) => downloadLecturer(sender, e, newData.Cast<Lecturer>().ToList());
                        download.Click -= (sender, e) => downloadLiterature(sender, e, newData.Cast<Literature>().ToList());
                        download.Click += (sender, e) => downloadLecturer(sender, e, newData.Cast<Lecturer>().ToList());
                        break;
                    case 2:
                        download.Click -= (sender, e) => downloadDiscipline(sender, e, newData.Cast<Discipline>().ToList());
                        download.Click -= (sender, e) => downloadLecturer(sender, e, newData.Cast<Lecturer>().ToList());
                        download.Click += (sender, e) => downloadLiterature(sender, e, newData.Cast<Literature>().ToList());
                        break;
                }
            }
        }



        private List<object> GetDataForDeserialization(int index)
        {
            string filePath = "";
            switch (index)
            {
                case 0:
                    filePath = "Discipline.json";
                    break;
                case 1:
                    filePath = "Lecturer.json";
                    break;
                case 2:
                    filePath = "Literature.json";
                    break;
                default:
                    return new List<object>();
            }

            try
            {
                string jsonData = File.ReadAllText(filePath);

                return index switch
                {
                    0 => JsonSerializer.Deserialize<List<Discipline>>(jsonData).Cast<object>().ToList(),
                    1 => JsonSerializer.Deserialize<List<Lecturer>>(jsonData).Cast<object>().ToList(),
                    2 => JsonSerializer.Deserialize<List<Literature>>(jsonData).Cast<object>().ToList(),
                    _ => new List<object>(),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<object>();
            }
        }



        private List<T> DeserializeData<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<T>>(jsonData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new List<T>();
        }

        private void DisplayData(List<object> newData)
        {
            StringBuilder message = new StringBuilder();
            foreach (var item in newData)
            {
                if (item.GetType() == typeof(Discipline))
                {
                    Discipline discipline = (Discipline)item;
                    // Преобразуем StringBuilder в строку перед передачей в метод
                    string messageString = message.ToString();
                    Form1.DisplayDisciplines(discipline, ref messageString);
                    message = new StringBuilder(messageString);
                }
                else if (item.GetType() == typeof(Lecturer))
                {
                    Lecturer lecturer = (Lecturer)item;
                    message.AppendLine($"Лектор {lecturer.fio} с кафедры {lecturer.department} со стажем работы {lecturer.experience} лет с аудитории {lecturer.auditorium}\r\n---------------------------\r\n");
                }
                else if (item.GetType() == typeof(Literature))
                {
                    Literature literature = (Literature)item;
                    message.AppendLine($"Книга {literature.name} {literature.year} года, авторы:");
                    foreach (string author in literature.author)
                    {
                        message.AppendLine(author);
                    }
                    message.AppendLine("---------------------------");
                }
            }
            textBox1.Text = message.ToString();
        }


        private bool checkRead()
        {
            bool flag = true;
            if (readObjects.SelectedItem == null)
            {
                flag = false;
                redFlag(readObjects);
            }
            return flag;
        }

        private void RemoveFlag(object sender, EventArgs e)
        {
            Control activeControl = ActiveControl;

            if (activeControl != null)
            {
                int labelLeft = activeControl.Right + 5;
                int labelTop = activeControl.Top + (activeControl.Height - activeControl.Font.Height) / 2;

                Label labelToRemove = Controls.OfType<Label>()
                                              .FirstOrDefault(l => l.Left == labelLeft && l.Top == labelTop);

                if (labelToRemove != null)
                {
                    Controls.Remove(labelToRemove);
                }
            }
        }

        public void downloadLecturer(object sender, EventArgs e, List<Lecturer> lecturer)
        {
            string[] names = Program.lecturer.Select(l => l.fio).ToArray();
            foreach (var item in lecturer)
            {
                if (!names.Contains(item.fio))
                {
                    Program.lecturer.Add(item);
                }
            }
            Program.lastAction = "Сохранение лекторов";
        }

        public void downloadLiterature(object sender, EventArgs e, List<Literature> literature)
        {
            string[] names = Program.literature.Select(l => l.name).ToArray();
            foreach (var item in literature)
            {
                if (!names.Contains(item.name))
                {
                    Program.literature.Add(item);
                }
            }
            Program.lastAction = "Сохранение литературы";
        }

        public void downloadDiscipline(object sender, EventArgs e, List<Discipline> discipline)
        {
            string[] disciplineNames = Program.discipline.Select(d => d.name).ToArray();
            string[] lecturerNames = Program.lecturer.Select(l => l.fio).ToArray();
            string[] literatureNames = Program.literature.Select(l => l.name).ToArray();

            foreach (var item in discipline)
            {
                if (!disciplineNames.Contains(item.name))
                {
                    Program.discipline.Add(item);
                    if (!lecturerNames.Contains(item.lecturer.fio))
                    {
                        Program.lecturer.Add(item.lecturer);
                    }
                    foreach (var literatureItem in item.literature)
                    {
                        if (!literatureNames.Contains(literatureItem.name))
                        {
                            Program.literature.Add(literatureItem);
                        }
                    }
                }
            }
            Program.lastAction = "Сохранение дисциплин";
        }

        private void Form4_Activated(object sender, EventArgs e)
        {
            download.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void download_Click(object sender, EventArgs e)
        {

        }
    }
}
