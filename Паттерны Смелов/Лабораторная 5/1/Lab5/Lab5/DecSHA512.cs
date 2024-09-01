using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public class DecSHA512 : Decorator // вычисление хеша SHA512
    {
        public DecSHA512 (IWriter writer) : base (writer) { }
        public override string? Save(string? message)
        {
            using (var sha512 = SHA512.Create())
            {
                if (message == null)
                {
                    message = string.Empty;
                }
                var messagebyte = Encoding.UTF8.GetBytes(message);
                var hash = sha512.ComputeHash(messagebyte);
                var hashstring = Convert.ToBase64String(hash);
                var result = $"{message}{Constant.Delimiter}{hashstring}";
                // сообщение, разделитель, хеш
                return writer?.Save(result);
            }
        }
    }
}