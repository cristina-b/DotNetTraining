using StrategyFileEncrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StrategyFileEncrypt
{
    class Program
    {
        static void Main()
        {
            string filePath = "testFile.txt";
            Encryption encryption = new Encryption(filePath);
            encryption.Encrypt();
        }
    }
}
