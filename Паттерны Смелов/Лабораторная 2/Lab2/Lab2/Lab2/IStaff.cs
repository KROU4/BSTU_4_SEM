using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    interface IStaff
    {
        List<JobVacancy> getJobVacancies();
        List<Employee> GetEmployees();
        List<JobTitle> GetJobTitles();
        int addJobTitle(JobTitle jobTitle);
        string printJobVacancies();
        bool delJobTitle(int index);
        int openJobVacancy(JobVacancy jobVacancy); // должен быть void
        bool closeJobVacancy(int index);
        Employee recruit(JobVacancy jobVacancy, Person person);
        void dismiss(int index, Reason reason, int index2); // должен быть bool
    }
}
