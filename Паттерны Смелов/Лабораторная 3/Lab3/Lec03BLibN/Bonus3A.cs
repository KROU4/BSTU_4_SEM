using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus3A : IBonus
    {
        public float cost1hour { get; set; }  // стоимость 1 часа
        public float A { get; set; } // величина снижения/повышения отработанных часов
        public float B { get; set; } // величина повышения/понижения стоимости 1 часа

        public float calc(float number_hours) // кол-во отработанных часов
        {
            return (number_hours + A) * (cost1hour + B);
            // (кол-во отработанных часов + величина снижения/повышения отработанных часов) * (стоимость 1 часа + величина повышения/понижения стоимости 1 часа)
        }
        public Bonus3A(float cost1hour, float a, float b)
        {
            this.cost1hour = cost1hour;
            A = a;
            B = b;
        }
    }
}
