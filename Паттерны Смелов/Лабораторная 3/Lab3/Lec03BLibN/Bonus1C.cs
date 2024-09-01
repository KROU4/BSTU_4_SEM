using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class Bonus1C : IBonus
    {
        public float cost1hour { get; set; } // стоимость 1 часа
        public float X { get; set; } // повышающий/понижающий коэффициент
        public float Y { get; set; } // величина снижения/повышения

        public float calc(float number_hours)
        {
            return number_hours * X * cost1hour + Y;
            // кол-во отработанных часов * повышающий/понижающий коэффициент * стоимость 1 часа + величина снижения/повышения
        }
        public Bonus1C(float cost1hour, float x, float y)
        {
            this.cost1hour = cost1hour;
            X = x;
            Y = y;
        }
    }
}
