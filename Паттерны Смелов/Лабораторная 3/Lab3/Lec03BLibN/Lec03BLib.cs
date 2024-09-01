using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public static class Lec03BLib // уровни вознаграждения
    {
        public static IFactory getL1() // уровень 1
        {
            return new FirstFactory();
        }

        public static IFactory getL2(float a) // уровень 2
        {
            return new SecondFactory(a); // величина снижения/повышения отработанных часов
        }

        public static IFactory getL3(float a, float b) // уровень 3
        {
            return new ThirdFactory(a, // величина снижения/повышения отработанных часов
                b); // величина снижения/повышения стоимости 1 часа
        }
        
        public static IFactory getL4(float a, float b, float c) // уровень 3
        {
            return new FourthFactory(a, // величина снижения/повышения отработанных часов
                b, // величина снижения/повышения стоимости 1 часа
                c);
        }
        
    }
}
