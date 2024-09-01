using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Employee // сотрудник, получающий вознаграждение
    {
        public IBonus bonus { get; private set; } // алгоритм для вычисления вознаграждения

        public Employee(IBonus bonus) // Dependency Inversion Principle 
        {
            this.bonus = bonus;
        }

        public float calcBonus(float number_hours) // вычисление вознаграждения
        {
            return bonus.calc(number_hours); // вызов внедренного алгоритма
        }
    }
}