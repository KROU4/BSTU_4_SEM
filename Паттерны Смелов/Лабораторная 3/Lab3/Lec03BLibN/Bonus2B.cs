using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus2B : IBonus
    {
        public float cost1hour { get; set; } // стоимость 1 часа
        public float A { get; set; } // величина снижения/повышения отработанных часов
        public float X { get; set; } // повышающий/понижающий коэффициент

        public float calc(float number_hours) // передаётся кол-во отработанных часов
        {
            return (number_hours + A) * X * cost1hour;
            // (кол-во отработанных часов + величина снижения/повышения отработанных часов) * повышающий/понижающий коэффициент * стоимость 1 часа
        }
        public Bonus2B(float cost1hour, float x, float a)
        {
            this.cost1hour = cost1hour;
            X = x;
            A = a;
        }
    }
}
