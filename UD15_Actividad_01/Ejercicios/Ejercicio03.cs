using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UD15_Actividad_01.Ejercicios
{
    public  static class Ejercicio03
    {
        public static string GenerateKeys(bool includePrivateKey)
        {
            string xmlKeys = string.Empty;
            using (RSACryptoServiceProvider rsaAlgorithm = new RSACryptoServiceProvider())
            {
                xmlKeys = rsaAlgorithm.ToXmlString(includePrivateKey);
                
            }
            return xmlKeys;
        }
        public static byte[] Encrypt(byte[] clearBytes, string xmlKeys)
        {
            byte[] encryptedBytes = null;
            using (RSA rsaAlg = RSA.Create())
            {
                rsaAlg.FromXmlString(xmlKeys);
                encryptedBytes = rsaAlg.Encrypt(clearBytes, RSAEncryptionPadding.Pkcs1);
            }
            return encryptedBytes;
        }


        public static byte[] Decrypt(byte[] encryptedBytes, string xmlKeys)
        {
            byte[] decryptedBytes = null;
            using (RSA rsaAlgorithm = RSA.Create())
            {
                rsaAlgorithm.FromXmlString(xmlKeys);
                decryptedBytes = rsaAlgorithm.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
            }
            return decryptedBytes;
        }

    }
}
