using System.IO;

namespace StrategyFileEncrypt
{   
    public class Encryption
    {        
        private IEncrypt algorithm;
        private string filePath;

        public Encryption(string filePath)
        {
            this.filePath = filePath;
            long length = new System.IO.FileInfo(filePath).Length;
            if (length < 2048)
            {
                this.algorithm = new InMemory();
            }
            else
            {
                this.algorithm = new ToDisk();
            }            
        }
        
        public void Encrypt()
        {
            algorithm.Encrypt(filePath);
        }
    }
}