using System;
using System.IO;

namespace StrategyFileEncrypt
{
    public class InMemory : IEncrypt
    {        
        public void Encrypt(string FileName)
        {
            Console.WriteLine("In memory encryption");
        }
    }
}