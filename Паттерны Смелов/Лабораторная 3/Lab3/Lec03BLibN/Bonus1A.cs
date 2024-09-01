using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus1A : IBonus
    {
        public float cost1hour { get; set; }  // стоимость 1 часа

        public float calc(float number_hours) // кол-во отработанных часов
        {
            return number_hours * cost1hour;
            // (кол-во отработанных часов * стоимость 1 часа
        }
        public Bonus1A(float cost1hour)
        {
            this.cost1hour = cost1hour;
        }
    }
}
