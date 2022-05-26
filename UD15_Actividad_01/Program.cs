using UD15_Actividad_01.Ejercicios;

namespace UD15_Actividad_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1.Crea una aplicación que permita obtener y verificar el hash de un fichero cualquiera.

            Console.WriteLine("Ejercicio 01\n-------------------");


            string ValidPassFilePath = Path.Combine(Environment.CurrentDirectory, "Data","Ejercicio_01", "01_ContraseñaValida.txt");
            string testPassFilePath01 = Path.Combine(Environment.CurrentDirectory, "Data","Ejercicio_01", "02_ContraseñaNoValida.txt");
            string testPassFilePath02 = Path.Combine(Environment.CurrentDirectory, "Data","Ejercicio_01", "03_ContraseñaValida.txt");
            
            string validPass = File.ReadAllText(ValidPassFilePath);
            string testPass01 = File.ReadAllText(testPassFilePath01);
            string testPass02 = File.ReadAllText(testPassFilePath02);

            Ejercicio01 ejercicio01 = new Ejercicio01();


            // Estos hash no son iguales
            ejercicio01.VerifyHash(testPass01, validPass);
            // Estos hash si son iguales
            ejercicio01.VerifyHash(testPass02, validPass);




            // 2. Crea una aplicación que permita encriptar/ desencriptar mensajes, utilizando criptografía simétrica.


            Console.WriteLine("\nEjercicio 02\n-------------------");

            byte[] key = Ejercicio02.GenerateKey();
            byte[] iv = Ejercicio02.GenerateIV();
            byte[] message = Ejercicio02.Encrypt("Muy buenos y encriptados días", iv, key);

            string decryptMessage = Ejercicio02.Decrypt(message,iv,key);

            Console.WriteLine(decryptMessage);

            // 3.Crea una aplicación que permita generar un par de claves de criptografía asimétrica.

            Console.WriteLine("\nEjercicio 03\n-------------------");
            
            // Emisor
            string Emisorkeys = Ejercicio03.GenerateKeys(true); // No se utiliza para nada en este ejercicio
            string asimMessage= "Encriptación asimétrica";
            byte[] asimMessageBytes = System.Text.Encoding.UTF8.GetBytes(asimMessage);

            // Receptor
            string receptorKeys = Ejercicio03.GenerateKeys(true);

            // Encrypt message
            byte[] encryptedBytes = Ejercicio03.Encrypt(asimMessageBytes,receptorKeys);

            // DecryptMessage
            byte[] decryptedBytes = Ejercicio03.Decrypt(encryptedBytes,receptorKeys);

            Console.WriteLine(System.Text.Encoding.UTF8.GetString(decryptedBytes));

            Console.WriteLine("\nEjercicio 04\n-------------------");


            byte[] sign = Ejercicio04.GetDigitalSignature(asimMessage,Emisorkeys);
            bool isValid = Ejercicio04.IsValidSignature(asimMessage,sign,Emisorkeys);
            Console.WriteLine(isValid);


        }
    }
}