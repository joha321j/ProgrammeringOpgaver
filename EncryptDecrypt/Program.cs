using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            int hashValue = 27;
            Vault vault = new Vault(hashValue);

            int encryptedHashValue = Encrypt(hashValue);
        }

        private static int Encrypt(int hashValue)
        {
            throw new NotImplementedException();
        }
    }
}
