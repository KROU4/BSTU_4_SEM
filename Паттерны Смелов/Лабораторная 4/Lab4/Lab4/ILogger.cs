using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec04LibN
{
    public interface ILogger
    {
        void start(             // старт пространства имён
            string title        // имя пространства
            );
        void log(               // вывод сообщения в текущем пространстве
            string message      // текст
            );
        void stop();            // завершить пространство имён
    }
}
