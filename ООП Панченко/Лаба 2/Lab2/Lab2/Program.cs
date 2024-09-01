using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2
{
    public class Discipline
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Неверная длина названия дисциплины")]
        public string? name { get; set; }
        [Semester]
        public int? semester { get; set; }
        [Required(ErrorMessage = "Не выбран курс")]
        public int? course { get; set; }
        [Required(ErrorMessage = "Не выбрана специальность")]
        public string? specialization { get; set; }
        [Range(1, 32, ErrorMessage = "Неверное количество лекций")]
        public int? amountoflections { get; set; }
        [Range(1, 32, ErrorMessage = "Неверное количество лабораторных")]
        public int? amountoflabs { get; set; }
        [Required(ErrorMessage = "Не выбрана форма контроля")]
        public string? control { get; set; }
        [Required(ErrorMessage = "Не выбрана дата проведения контроля")]
        public DateTime? date { get; set; }
        [Required(ErrorMessage = "Не выбран лектор")]
        public Lecturer? lecturer { get; set; }
        [MinLength(1, ErrorMessage = "Не выбран список литературы")]
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
                throw new ArgumentException($"Ошибка валидации: {string.Join(", ", validationErrors)}");
            }
            else
            {
                MessageBox.Show("Дисциплина прошла валидацию");
            }

            Program.discipline.Add(this);
        }
        public Discipline()
        {
        }
    }


    public class Lecturer
    {
        [Required(ErrorMessage = "Не выбрана кафедра")]
        public string? department { get; set; }
        [Required(ErrorMessage = "ФИО обязательно для заполнения")]
        [RegularExpression(@"^[А-Я][а-я]+\s[А-Я]\.\s[А-Я]\.$", ErrorMessage = "Неправильно введено ФИО лектора")]
        public string? fio { get; set; }
        [Required(ErrorMessage = "Аудитория лектора обязательна для заполнения")]
        [RegularExpression(@"^[1-5][1-3][1-9]$", ErrorMessage = "Неправильно введена аудитория лектора")]
        public string? auditorium { get; set; }
        [Required(ErrorMessage = "Не введён стаж работы лектора")]
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
                throw new ArgumentException($"Ошибка валидации: {string.Join(", ", validationErrors)}");
            }
            else
            {
                MessageBox.Show("Лектор прошел валидацию");
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
        [Required(ErrorMessage = "Название литературы обязательно для заполнения")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Неправильно введено название литературы")]
        public string? name { get; set; }
        [Author(ErrorMessage = "Неправильно указан автор")]
        public string[]? author { get; set; }
        [Range(1800, 2024, ErrorMessage = "Неправильно указан год")]
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
                throw new ArgumentException($"Ошибка валидации: {string.Join(", ", validationErrors)}");
            }
            else
            {
                MessageBox.Show("Литература прошла валидацию");
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