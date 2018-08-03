using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaLibreria.General
{
    public static class Encriptacion
    {
        #region Encriptar
        /// <summary>
        /// Método de Encriptacion que contiene un Key por defecto
        /// </summary>
        /// <param name="texto">Texto a Encriptar</param>
        /// <returns>Texto encriptado</returns>
        public static String Encriptar(String texto)
        {
            try
            {
                String passPhrase = "@1B2c3D4e5F6g7H8s1scl1v3t1211";
                String saltValue = "@1B2c3D4e5F6g7H8";
                String hashAlgorithm = "SHA1";

                Int32 passwordIterations = 2;
                String initVector = "@1B2c3D4e5F6g7H8";
                Int32 keySize = 256;

                Byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                Byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                Byte[] plainTextBytes = Encoding.UTF8.GetBytes(texto);


                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                Byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encriptador = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encriptador, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                Byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                String cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
        #region Desencriptar
        /// <summary>
        /// Metodo de Desencriptacion que contiene un Key por Default
        /// </summary>
        /// <param name="textoEncriptado">Texto a Desencriptar</param>
        /// <returns>Texto Desencriptado</returns>
        public static String Desencriptar(String textoEncriptado)
        {
            try
            {
                String passPhrase = "@1B2c3D4e5F6g7H8s1scl1v3t1211";
                String saltValue = "@1B2c3D4e5F6g7H8";
                String hashAlgorithm = "SHA1";

                Int32 passwordIterations = 2;
                String initVector = "@1B2c3D4e5F6g7H8";
                Int32 keySize = 256;
                // Convert Strings defining encryption key characteristics into Byte
                // arrays. Let us assume that Strings only contain ASCII codes.
                // If Strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.
                Byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                Byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our ciphertext into a Byte array.
                Byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);

                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                Byte[] keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                // Define cryptographic stream (always use Read mode for encryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                Byte[] plainTextBytes = new Byte[cipherTextBytes.Length];

                // Start decrypting.
                Int32 decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert decrypted data into a String. 
                // Let us assume that the original plaintext String was UTF8-encoded.
                String plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                // Return decrypted String.   
                return plainText;
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion        
    }
}
