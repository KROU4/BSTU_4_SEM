using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Lec04LibN
{
    public class Logger : ILogger
    {
        public static ILogger? instance;
        public Stack<string>? _namespace = new();
        public int _id = 0;

        private string LogFileName // имя файла журнала
            = string.Format(@"{0}/LOG{1}.txt", Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyMMdd-HH-mm-ss"));

        public static ILogger create()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        private Logger()
        {
            logWrite("INIT");
        }

        public void start(string title)
        {
            _namespace?.Push(title);
            logWrite("STRT");
        }

        public void log(string message = "")
        {
            logWrite("INFO",message);
        }

        public void logWrite(string? logType, string message = "")
        {
            _id++;
            string namespaces = _namespace.Any() ? string.Join(":", _namespace.Reverse()) + ":" : "";
            File.AppendAllText(LogFileName, $"{_id:d6}-{DateTime.Now:dd.MM.yyyy HH:mm:ss}-{logType} {namespaces} {message}\n");
        }


        public void stop()

        {
            _namespace?.Pop();
            logWrite("STOP");
        }
    }
}
