using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class SecondFactory : IFactory
    {
        private float A { get; set; } // величина снижения/повышения отработанных часов

        public SecondFactory(float a)
        {
            A = a;
        }

        public IBonus getA(float cost1hour)
        {
            return new Bonus2A(cost1hour,  // стоимость 1 часа
                A); // величина снижения/повышения отработанных часов
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new Bonus2B(cost1hour,  // стоимость 1 часа
                x,  // повышающий/понижающий коэффициент
                A); // величина снижения/повышения отработанных часов
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new Bonus2C(cost1hour,  // стоимость 1 часа
                x,  // повышающий/понижающий коэффициент
                y,  // величина снижения/повышения
                A); // величина снижения/повышения отработанных часов
        }
        
        public IBonus getD(float cost1hour, float x, float y, float z)
        {
            return new Bonus2D(cost1hour,  // стоимость 1 часа
                x,  // повышающий/понижающий коэффициент
                y,  // величина снижения/повышения
                A,  // величина снижения/повышения отработанных часов
                z);
        }
    }
}
