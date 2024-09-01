using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus1B : IBonus
    {
        public float cost1hour { get; set; } // стоимость 1 часа
        public float X { get; set; } // повышающий/понижающий коэффициент

        public float calc(float number_hours) // передаётся кол-во отработанных часов
        {
            return number_hours * X * cost1hour;
            // кол-во отработанных часов * повышающий/понижающий коэффициент * стоимость 1 часа
        }
        public Bonus1B(float cost1hour, float x)
        {
            this.cost1hour = cost1hour;
            X = x;
        }
    }
}
