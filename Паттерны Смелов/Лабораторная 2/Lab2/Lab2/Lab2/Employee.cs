using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Employee
    {
        public Person person;
        public JobVacancy jobVacancy;
        static private int next_id = 12345;
        public int id { get; private set; }
        public Employee(Person person, JobVacancy jobVacancy)
        {
            this.id = next_id;
            next_id++;
            this.person = person;
            this.jobVacancy = jobVacancy;
        }
    }
}
