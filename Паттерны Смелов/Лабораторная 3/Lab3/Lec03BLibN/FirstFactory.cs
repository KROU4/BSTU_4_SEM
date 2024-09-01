using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public class FirstFactory : IFactory
    {
        public IBonus getA(float cost1hour)
        {
            return new Bonus1A(cost1hour); // стоимость 1 часа
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new Bonus1B(cost1hour, // стоимость 1 часа
                x); // повышающий/понижающий коэффициент
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new Bonus1C(cost1hour, // стоимость 1 часа
                x, // повышающий/понижающий коэффициент
                y); // величина повышения/понижения
        }

        public IBonus getD(float cost1hour, float x, float y, float z)
        {
            throw new Exception("Бонус недоступен для данного уровня");
        }
    }
}
