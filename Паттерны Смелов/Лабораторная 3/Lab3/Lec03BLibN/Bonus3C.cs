using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus3C : IBonus
    {
        public float cost1hour { get; set; } // стоимость 1 часа
        public float A { get; set; } // величина снижения/повышения отработанных часов
        public float B { get; set; } // величина повышения/понижения стоимости 1 часа
        public float X { get; set; } // повышающий/понижающий коэффициент
        public float Y { get; set; } // величина снижения/повышения

        public float calc(float number_hours)
        {
            return (number_hours + A) * X * (cost1hour + B) + Y;
            // (кол-во отработанных часов + величина снижения/повышения отработанных часов) * повышающий/понижающий коэффициент * стоимость 1 часа + величина снижения/повышения
        }
        public Bonus3C(float cost1hour, float a, float b, float x, float y)
        {
            this.cost1hour = cost1hour;
            A = a;
            B = b;
            X = x;
            Y = y;
        }
    }
}
