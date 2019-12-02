using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    public class Vault
    {
        public int CorrectHashValue { private get; set; }

        public Vault(int CHV)
        {
            CorrectHashValue = CHV;
        }

        public bool Authenticate(int allegedHashValue)
        {
            return (allegedHashValue == CorrectHashValue);
        }
    }

}
