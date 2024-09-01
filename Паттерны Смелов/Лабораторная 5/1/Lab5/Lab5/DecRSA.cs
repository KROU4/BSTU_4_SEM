using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public class DecRSA : Decorator // RSA-шифровать хеш
    {
        public DecRSA(IWriter writer) : base(writer) { }

        public override string? Save(string? message)
        {
            string publicKey;
            byte[] encyptedData;
            
            int delimiter = message.IndexOf(Constant.Delimiter);
            if (delimiter == -1)
            {
                throw new Exception("Разделитель не найден");
            }
            string xs = message.Substring(0, delimiter); // сообщение
            string hesh = message.Substring(delimiter + 1); // хеш
            byte[] heshbyte = Convert.FromBase64String(hesh);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(true);
                rsa.ImportParameters(rsa.ExportParameters(false));
                encyptedData = rsa.Encrypt(heshbyte, false);
            }
            string result = $"{xs}{Constant.Delimiter}{Convert.ToBase64String(encyptedData)}{Constant.Delimiter}{publicKey}";
            // сообщение, разделитель, зашифрованный хеш, разделитель, публичный ключ
            return writer?.Save(result);
        }
    }
}
