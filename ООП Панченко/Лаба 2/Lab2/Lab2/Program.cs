using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2
{
    public class Discipline
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "�������� ����� �������� ����������")]
        public string? name { get; set; }
        [Semester]
        public int? semester { get; set; }
        [Required(ErrorMessage = "�� ������ ����")]
        public int? course { get; set; }
        [Required(ErrorMessage = "�� ������� �������������")]
        public string? specialization { get; set; }
        [Range(1, 32, ErrorMessage = "�������� ���������� ������")]
        public int? amountoflections { get; set; }
        [Range(1, 32, ErrorMessage = "�������� ���������� ������������")]
        public int? amountoflabs { get; set; }
        [Required(ErrorMessage = "�� ������� ����� ��������")]
        public string? control { get; set; }
        [Required(ErrorMessage = "�� ������� ���� ���������� ��������")]
        public DateTime? date { get; set; }
        [Required(ErrorMessage = "�� ������ ������")]
        public Lecturer? lecturer { get; set; }
        [MinLength(1, ErrorMessage = "�� ������ ������ ����������")]
        public List<Literature>? literature { get; set; }
        public Discipline(string? name, int? semester, int? course, string? specialization, int? amountoflections, int? amountoflabs, string? control, DateTime? date, Lecturer? lecturer, List<Literature>? literature)
        {
            this.name = name;
            this.semester = semester;
            this.course = course;
            this.specialization = specialization;
            this.amountoflections = amountoflections;
            this.amountoflabs = amountoflabs;
            this.control = control;
            this.date = date;
            this.lecturer = lecturer;
            this.literature = literature;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                var validationErrors = results.Select(r => r.ErrorMessage);
                throw new ArgumentException($"������ ���������: {string.Join(", ", validationErrors)}");
            }
            else
            {
                MessageBox.Show("���������� ������ ���������");
            }

            Program.discipline.Add(this);
        }
        public Discipline()
        {
        }
    }


    public class Lecturer
    {
        [Required(ErrorMessage = "�� ������� �������")]
        public string? department { get; set; }
        [Required(ErrorMessage = "��� ����������� ��� ����������")]
        [RegularExpression(@"^[�-�][�-�]+\s[�-�]\.\s[�-�]\.$", ErrorMessage = "����������� ������� ��� �������")]
        public string? fio { get; set; }
        [Required(ErrorMessage = "��������� ������� ����������� ��� ����������")]
        [RegularExpression(@"^[1-5][1-3][1-9]$", ErrorMessage = "����������� ������� ��������� �������")]
        public string? auditorium { get; set; }
        [Required(ErrorMessage = "�� ����� ���� ������ �������")]
        public int experience { get; set; }
        public Lecturer(string? department, string? fio, string? auditorium, int experience)
        {
            this.department = department;
            this.fio = fio;
            this.auditorium = auditorium;
            this.experience = experience;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                var validationErrors = results.Select(r => r.ErrorMessage);
                throw new ArgumentException($"������ ���������: {string.Join(", ", validationErrors)}");
            }
            else
            {
                MessageBox.Show("������ ������ ���������");
            }
            Program.lecturer.Add(this);
        }
        public override string ToString()
        {
            return fio; 
        }
        public Lecturer()
        {
        }
    }

    public class Literature
    {
        [Required(ErrorMessage = "�������� ���������� ����������� ��� ����������")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "����������� ������� �������� ����������")]
        public string? name { get; set; }
        [Author(ErrorMessage = "����������� ������ �����")]
        public string[]? author { get; set; }
        [Range(1800, 2024, ErrorMessage = "����������� ������ ���")]
        public int year { get; set; }
        public Literature(string? name, string[]? author, int year)
        {
            this.name = name;
            this.author = author;
            this.year = year;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                var validationErrors = results.Select(r => r.ErrorMessage);
                throw new ArgumentException($"������ ���������: {string.Join(", ", validationErrors)}");
            }
            else
            {
                MessageBox.Show("���������� ������ ���������");
            }


            Program.literature.Add(this);
        }
        public override string ToString()
        {
            return name;
        }
        public Literature()
        {
        }

    }
    public static class Program
    {
        public static List<Lecturer> lecturer = new();
        public static List<Literature> literature = new();
        public static List<Discipline> discipline = new();
        public static string? lastAction = "";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}