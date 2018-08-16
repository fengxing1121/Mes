using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Mes.Client.Utility
{
    public class SimpleEncryptor
    {
        public static string MD5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            string md5Str = BitConverter.ToString(s).Replace("-", "");
            return md5Str;
        }

        public static byte[] DESDecrypt(byte[] EncryptedConent)
        {
            if (EncryptedConent == null)
            {
                return null;
            }
            byte[] buffer = new byte[] { 0xda, 0xe9, 190, 0xe0, 0x8d, 0xfb, 0xf3, 0xc2 };
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = buffer;
            provider.IV = buffer;
            MemoryStream stream = new MemoryStream(EncryptedConent);
            ICryptoTransform transform = provider.CreateDecryptor();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(stream2);
            byte[] bytes = Encoding.ASCII.GetBytes(reader.ReadToEnd());
            reader.Close();
            stream2.Close();
            stream.Close();
            return bytes;
        }

        public static byte[] DESEncrypt(byte[] Content)
        {
            if (Content == null)
            {
                return null;
            }
            byte[] buffer = new byte[] { 0xda, 0xe9, 190, 0xe0, 0x8d, 0xfb, 0xf3, 0xc2 };
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = buffer;
            provider.IV = buffer;
            MemoryStream stream = new MemoryStream();
            ICryptoTransform transform = provider.CreateEncryptor();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(Content, 0, Content.Length);
            stream2.Close();
            byte[] buffer2 = stream.ToArray();
            stream.Close();
            return buffer2;
        }

        public static string RSAGetSignature(string PrivateKey, string Code)
        {
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            key.FromXmlString(PrivateKey);
            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("SHA1");
            byte[] bytes = Encoding.ASCII.GetBytes(Code);
            byte[] rgbHash = new SHA1Managed().ComputeHash(bytes);
            return Convert.ToBase64String(formatter.CreateSignature(rgbHash));
        }

        public static bool RSAVerify(string PublicKey, string Code, string Key)
        {
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            key.FromXmlString(PublicKey);
            RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
            deformatter.SetHashAlgorithm("SHA1");
            byte[] rgbSignature = Convert.FromBase64String(Key);
            byte[] rgbHash = new SHA1Managed().ComputeHash(Encoding.ASCII.GetBytes(Code));
            try
            {
                return deformatter.VerifySignature(rgbHash, rgbSignature);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = { 0xEF, 0xAB, 0x56, 0x78, 0x90, 0x34, 0xCD, 0x12 };
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = { 0xEF, 0xAB, 0x56, 0x78, 0x90, 0x34, 0xCD, 0x12 };
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="SourceString">原字符串</param>
        /// <returns></returns>
        public string SHA1Encrypt(string SourceString)
        {
            byte[] StrRes = Encoding.Default.GetBytes(SourceString);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }
    }
}
