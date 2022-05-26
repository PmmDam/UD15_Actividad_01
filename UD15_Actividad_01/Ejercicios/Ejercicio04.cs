using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UD15_Actividad_01.Ejercicios
{
    public class Ejercicio04
    {
        public static Byte[] GetDigitalSignature(String message, String xmlKeys)
        {
            Byte[] signedBytes = null;
            SHA512 sha512Algorithm = SHA512.Create();
            try
            {
                RSACryptoServiceProvider rsaAlgorithm = new RSACryptoServiceProvider();
                try
                {
                    rsaAlgorithm.FromXmlString(xmlKeys);
                    RSAPKCS1SignatureFormatter formatter = new
                    RSAPKCS1SignatureFormatter(rsaAlgorithm);
                    formatter.SetHashAlgorithm("SHA512");
                    Byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    Byte[] hashedBytes = sha512Algorithm.ComputeHash(messageBytes);
                    signedBytes = formatter.CreateSignature(hashedBytes);
                }
                finally
                {
                    if (rsaAlgorithm != null)
                    {
                        rsaAlgorithm.Dispose();
                        rsaAlgorithm = null;
                    }
                }
            }
            finally
            {
                if (sha512Algorithm != null)
                {
                    sha512Algorithm.Dispose();
                    sha512Algorithm = null;
                }
            }
            return signedBytes;
        }

        public static bool IsValidSignature(string message,byte[] digitalSignature,string xmlPublicKey)
        {
            bool isValid = false;
            SHA512 sha512Algorithm = SHA512.Create();
            try
            {
                RSACryptoServiceProvider rsaAlgorithm = new RSACryptoServiceProvider();
                try
                {
                    Byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    Byte[] hashedBytes = sha512Algorithm.ComputeHash(messageBytes);
                    rsaAlgorithm.FromXmlString(xmlPublicKey);
                    RSAPKCS1SignatureDeformatter deformatter = new
                    RSAPKCS1SignatureDeformatter(rsaAlgorithm);
                    deformatter.SetHashAlgorithm("SHA512");
                    if (deformatter.VerifySignature(hashedBytes, digitalSignature))
                    {
                        isValid = true;
                    }
                }
                finally
                {
                    if (rsaAlgorithm != null)
                    {
                        rsaAlgorithm.Dispose();
                        rsaAlgorithm = null;
                    }
                }
            }
            finally
            {
                if (sha512Algorithm != null)
                {
                    sha512Algorithm.Dispose();
                    sha512Algorithm = null;
                }
            }
            return isValid;
        }

    }
}
