using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public interface IFactory // типы вознаграждения
    {
        IBonus getA( // тип вознаграждения А
            float cost1hour // стоимость 1 часа
            );

        IBonus getB( // тип вознаграждения В
            float cost1hour, // стоимость 1 часа
            float x // повышающий/понижающий коэффициент
            );

        IBonus getC( // тип вознаграждения С
            float cost1hour, // стоимость 1 часа
            float x, // повышающий/понижающий коэффициент
            float y // величина снижения/повышения
            );
        IBonus getD( // тип вознаграждения С
            float cost1hour, // стоимость 1 часа
            float x, // повышающий/понижающий коэффициент
            float y, // величина снижения/повышения
            float z
            );
    }
}
