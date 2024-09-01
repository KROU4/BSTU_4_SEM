using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus3B : IBonus
    {
        public float cost1hour { get; set; } // стоимость 1 часа
        public float A { get; set; } // величина снижения/повышения отработанных часов
        public float B { get; set; } // величина повышения/понижения стоимости 1 часа
        public float X { get; set; } // повышающий/понижающий коэффициент

        public float calc(float number_hours) // передаётся кол-во отработанных часов
        {
            return (number_hours + A) * X * (cost1hour + B);
            // (кол-во отработанных часов + величина снижения/повышения отработанных часов) * повышающий/понижающий коэффициент * (стоимость 1 часа + величина повышения/понижения стоимости 1 часа)
        }
        public Bonus3B(float cost1hour, float a, float b, float x)
        {
            this.cost1hour = cost1hour;
            A = a;
            B = b;
            X = x;
        }
    }
}
