using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class ThirdFactory : IFactory
    {
        private float A { get; set; } // величина снижения/повышения отработанных часов
        private float B { get; set; } // величина повышения/понижения стоимости 1 часа

        public ThirdFactory(float a, float b)
        {
            A = a;
            B = b;
        }

        public IBonus getA(float cost1hour)
        {
            return new Bonus3A(cost1hour,  // стоимость 1 часа + величина повышения/понижения стоимости 1 часа
                A, // величина снижения/повышения отработанных часов
                B);  // величина повышения/понижения стоимости 1 часа
        }

        public IBonus getB(float cost1hour, float x)
        {
            return null;
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new Bonus3C(cost1hour,  // стоимость 1 часа + величина повышения/понижения стоимости 1 часа
                A, // величина снижения/повышения отработанных часов
                B,  // величина повышения/понижения стоимости 1 часа
                x, // повышающий/понижающий коэффициент
                y); // величина снижения/повышения
        }
        public IBonus getD(float cost1hour, float x, float y, float z)
        {
            throw new Exception("Бонус недоступен для данного уровня");
        }

    }
}
