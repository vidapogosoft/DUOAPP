using ModeloDatos;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Negocio
{
    public class clsNSeguridad
    {
        public string Encriptar(string sClave)
        {
            byte[] key = UTF8Encoding.UTF8.GetBytes(clsParametos.SEMILLA);
            byte[] iv = UTF8Encoding.UTF8.GetBytes(clsParametos.SEMILLA_VECTOR);

            Array.Resize(ref key, clsParametos.keySize);
            Array.Resize(ref iv, clsParametos.ivSize);
            Rijndael RijndaelAlg = Rijndael.Create();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateEncryptor(key, iv),
                                                         CryptoStreamMode.Write);
            byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(sClave);
            cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherMessageBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherMessageBytes);
        }


        public string Desencriptar(string sClaveEncriptada)
        {
            byte[] key = UTF8Encoding.UTF8.GetBytes(clsParametos.SEMILLA);
            byte[] iv = UTF8Encoding.UTF8.GetBytes(clsParametos.SEMILLA_VECTOR);

            Array.Resize(ref key, clsParametos.keySize);
            Array.Resize(ref iv, clsParametos.ivSize);
            byte[] cipherTextBytes = Convert.FromBase64String(sClaveEncriptada);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            Rijndael RijndaelAlg = Rijndael.Create();
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateDecryptor(key, iv),
                                                         CryptoStreamMode.Read);
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
