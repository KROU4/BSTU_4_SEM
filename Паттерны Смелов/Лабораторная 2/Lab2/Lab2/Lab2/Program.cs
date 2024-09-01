using System;
using System.Diagnostics.Metrics;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Department department1 = new("Информационных систем и технологий", "ИСиТ", "каб. 412-1");
            Department department2 = new("Высшей математики", "ВМ", "каб. 301-4");
            Department department3 = new("Программной инженерии", "ПИ", "каб. 302-1");

            department1.printInfo();
            department2.printInfo();
            department3.printInfo();

            Faculty IT = new();
            Console.WriteLine("\n");
            IT.addDepartment(department1);
            IT.addDepartment(department2);
            IT.printInfo();
            IT.delDepartment(1);
            Console.WriteLine("\n");
            IT.printInfo();
            Console.WriteLine("\nПопытка обновить факультет: " + IT.updDepartment(department3) + "\n");
            List<Department> departments = IT.getDepartments();
            foreach (var item in departments)
            {
                Console.WriteLine(item.name);
            }

            JobTitle jobTitle1 = new("Сисадмин");
            JobTitle jobTitle2 = new("Повар");
            JobTitle jobTitle3 = new("Лектор");

            JobVacancy jobVacancy1 = new(false, "задача быть сисадмином", jobTitle1);
            JobVacancy jobVacancy2 = new(true, "задача быть поваром", jobTitle2);
            JobVacancy jobVacancy3 = new(false, "задача быть лектором", jobTitle3);

            IT.addJobVacancy(jobVacancy1);
            IT.addJobVacancy(jobVacancy2);
            IT.addJobVacancy(jobVacancy3);
            int count;
            count = IT.addJobTitle(jobTitle1);
            count = IT.addJobTitle(jobTitle2);
            count = IT.addJobTitle(jobTitle3);

            Console.WriteLine("\nВакансии на факультете:");
            List<JobTitle> jobTitle = IT.GetJobTitles();
            foreach(var item in jobTitle)
            {
                Console.WriteLine(item.nameOfTitle);
            }

            Console.WriteLine("\nОткрыты ли вакансии?\n");

            List<JobVacancy> jobVacancies11 = IT.getJobVacancies();
            foreach (var item in jobVacancies11)
            {
                Console.WriteLine($"{item.titleOfVacancy.nameOfTitle} - {item.isOpen}");
            }


            IT.openJobVacancy(jobVacancy3);
            Console.WriteLine("\nОткрыты ли вакансии?\n");

            List<JobVacancy> jobVacancies12 = IT.getJobVacancies();
            foreach (var item in jobVacancies12)
            {
                Console.WriteLine($"{item.titleOfVacancy.nameOfTitle} - {item.isOpen}");
            }

            Person person = new(false, "Mike");

            Employee employee = IT.recruit(jobVacancy3, person);

            Console.WriteLine($"\nПроверка:");

            foreach (var item in IT.jobVacancies)
            {
                if (item.employees.Count == 0)
                {
                    Console.WriteLine($"На {item.titleOfVacancy.nameOfTitle} нет работников");
                }
                else
                {
                    Console.WriteLine($"На {item.titleOfVacancy.nameOfTitle} работают:");
                    foreach (var it in item.employees)
                    {
                        Console.WriteLine(it.person.name);
                    }

                }
            }
            Console.WriteLine("\nРаботает ли сейчас Mike? " + person.isWork);
            Reason reason = new("плохо компы чинит");
            IT.dismiss(2, reason, 0);
            Console.WriteLine("Работает ли сейчас Mike? " + person.isWork + "\n");

            Organization organization = new("АртЛайн", "АЛ", "ул. Киселёва, 24");
            organization.printInfo();

            University BSTU = new();
            BSTU.addFaculty(IT);
            BSTU.printInfo();
        }
    }
}