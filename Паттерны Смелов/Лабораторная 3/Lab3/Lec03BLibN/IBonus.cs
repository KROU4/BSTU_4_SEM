using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLibN
{
    public interface IBonus // вознаграждение
    {
        float cost1hour { get; set; } // стоимость одного часа

        float calc(float number_hours);  // вычисление вознаграждения
    }
}
