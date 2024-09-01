using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class JobVacancy
    {
        public bool isOpen;
        static private int next_id = 12345;
        public int id { get; private set; }
        public string? descriptionOfVacancy;
        public JobTitle titleOfVacancy;
        public List<Employee> employees;
        public Dictionary<Employee, Reason> dissmiss;
        public JobVacancy(bool isOpen, string? descriptionOfVacancy, JobTitle titleOfVacancy)
        {
            this.isOpen = isOpen;
            this.descriptionOfVacancy = descriptionOfVacancy;
            this.id = next_id;
            next_id++;
            this.titleOfVacancy = titleOfVacancy;
            employees = new();
            dissmiss = new();
        }
    }
}
