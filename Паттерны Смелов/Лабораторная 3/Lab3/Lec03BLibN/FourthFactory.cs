using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class FourthFactory : IFactory
    {
        private float A { get; set; } // величина снижения/повышения отработанных часов
        private float B { get; set; } // величина повышения/понижения стоимости 1 часа
        private float C { get; set; }

        public FourthFactory(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }

        public IBonus getA(float cost1hour)
        {
            return new Bonus4A(cost1hour,  // стоимость 1 часа
                A, // величина снижения/повышения отработанных часов
                B, // величина повышения/понижения стоимости 1 часа
                C);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new Bonus4B(cost1hour,  // стоимость 1 часа + величина повышения/понижения стоимости 1 часа
                A, // величина снижения/повышения отработанных часов
                B,  // величина повышения/понижения стоимости 1 часа
                x, // повышающий/понижающий коэффициент
                C);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new Bonus4C(cost1hour,  // стоимость 1 часа + величина повышения/понижения стоимости 1 часа
                A, // величина снижения/повышения отработанных часов
                B,  // величина повышения/понижения стоимости 1 часа
                x, // повышающий/понижающий коэффициент
                y, // величина снижения/повышения
                C);
        }
        public IBonus getD(float cost1hour, float x, float y, float z)
        {
            throw new Exception("Бонус недоступен для данного уровня");
        }

    }
}
