using System;

namespace StrategyFileEncrypt
{ 
    public class ToDisk : IEncrypt
    {
        public void Encrypt(string FileName)
        {
            Console.WriteLine("To disk encryption");
        }
    }
}