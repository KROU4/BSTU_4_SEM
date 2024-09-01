using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public class FileWriter : IWriter // сохранения сообщения в файл
    {
        private string filename = Constant.FileName;
        public string Filename { get { return filename; } }
        public FileWriter(string? filename = null) 
        {
            this.filename = filename ?? Constant.FileName;
        }
        public string? Save (string? message)
        {
            File.WriteAllText(this.Filename, message);
            return filename;
        }
    }
}
