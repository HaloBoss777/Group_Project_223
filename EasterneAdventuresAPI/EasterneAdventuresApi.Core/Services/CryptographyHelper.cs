using EasterneAdventuresApi.Core.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EasterneAdventuresApi.Core.Services
{
	public class CryptographyHelper : ICryptographyHelper
	{
		private readonly Random _random = new Random();
		/// <summary>
		/// 216  11 221 160 230 235  91 134  99  36  64  80 130 209 230 219 
		/// 39 109 139  49 189  36 177 168  63 124  86 108 120  27 254  66 
		/// </summary>
		private byte[] Key = new byte[32] { 216, 11, 221, 160, 230, 235, 91, 134, 99, 36, 64, 80, 130, 209, 230, 219, 39, 109, 139, 49, 189, 36, 177, 168, 63, 124, 86, 108, 120, 27, 254, 66 };
		private byte[] IV = new byte[16] { 123, 138, 1, 66, 196, 63, 58, 16, 57, 79, 103, 70, 83, 11, 222, 253 };
		private string key = "JlUpVTypABkHj6AorSNaNaBm3io3b4biRhrt9iDeyqs=";
		private string iv = "oUaPcfRQy/udB9q+/x/mpw==";

		public string Encrypt(string decrypted)
		{
			return encrypt(decrypted, key, iv);
		}

		public string Decrypt(string encrypted)
		{
			return decrypt(encrypted, key, iv);

		}

		public static string encrypt(string prm_text_to_encrypt, string prm_key, string prm_iv)
		{
			var sToEncrypt = prm_text_to_encrypt;

			var rj = new RijndaelManaged()
			{
				Padding = PaddingMode.PKCS7,
				Mode = CipherMode.CBC,
				KeySize = 256,
				BlockSize = 128,
			};

			var key = Convert.FromBase64String(prm_key);
			var IV = Convert.FromBase64String(prm_iv);

			var encryptor = rj.CreateEncryptor(key, IV);

			var msEncrypt = new MemoryStream();
			var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

			var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);

			csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
			csEncrypt.FlushFinalBlock();

			var encrypted = msEncrypt.ToArray();

			return (Convert.ToBase64String(encrypted));
		}

		public static string decrypt(string prm_text_to_decrypt, string prm_key, string prm_iv)
		{

			var sEncryptedString = prm_text_to_decrypt;

			var rj = new RijndaelManaged()
			{
				Padding = PaddingMode.PKCS7,
				Mode = CipherMode.CBC,
				KeySize = 256,
				BlockSize = 128,
			};

			var key = Convert.FromBase64String(prm_key);
			var IV = Convert.FromBase64String(prm_iv);

			var decryptor = rj.CreateDecryptor(key, IV);

			var sEncrypted = Convert.FromBase64String(sEncryptedString);

			var fromEncrypt = new byte[sEncrypted.Length];

			var msDecrypt = new MemoryStream(sEncrypted);
			var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

			csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

			return (Encoding.ASCII.GetString(fromEncrypt));
		}

		public string GetMd5Hash(string input)
        {
            var md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyMd5Hash( string input, string hash)
        {
            var md5Hash = MD5.Create();
            // Hash the input.
            string hashOfInput = GetMd5Hash(input).ToUpper();

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		public string PrivateInternalEncryption(string decrypted)//DO NOT CHANGE
		{
			byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
			AesCryptoServiceProvider endec = new AesCryptoServiceProvider(); ;
			endec.BlockSize = 128;
			endec.KeySize = 256;
			endec.IV = IV;
			endec.Key = Key;
			endec.Padding = PaddingMode.PKCS7;
			endec.Mode = CipherMode.CBC;
			ICryptoTransform icrypt = endec.CreateEncryptor(endec.Key, endec.IV);
			byte[] enc = icrypt.TransformFinalBlock(textBytes, 0, textBytes.Length);
			icrypt.Dispose();
			return Base64UrlTextEncoder.Encode(enc);
		}
		public string PrivateInternalDecryption(string encrypted)
		{
			byte[] textbytes = Base64UrlTextEncoder.Decode(encrypted);
			AesCryptoServiceProvider endec = new AesCryptoServiceProvider();
			endec.BlockSize = 128;
			endec.KeySize = 256;
			endec.IV = IV;
			endec.Key = Key;
			endec.Padding = PaddingMode.PKCS7;
			endec.Mode = CipherMode.CBC;
			ICryptoTransform icrypt = endec.CreateDecryptor(endec.Key, endec.IV);
			byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
			icrypt.Dispose();

			return ASCIIEncoding.ASCII.GetString(enc);
		}
		public string GenerateStudentCodeForGuardian()
		{
			string code = "";

			for (int i = 0; i < 5; i++)
			{
				code += (char)_random.Next(48, 123);
			}

			return code;
		}

		public string GenerateHashedStringForPayFast(Dictionary<string,string> data)
		{
			var myString = "";
			foreach (KeyValuePair<string, string> entry in data)
			{
				myString += entry.Key + '=' + UrlEncodeUpperCase(entry.Value) + '&';
			}
			myString = myString.Remove(myString.Length - 1, 1);
			return GetMd5Hash(myString);
		}

		private static string UrlEncodeUpperCase(string stringToEncode)
		{
			var reg = new Regex(@"%[a-f0-9]{2}");
			stringToEncode = HttpUtility.UrlEncode(stringToEncode);
			return reg.Replace(stringToEncode, m => m.Value.ToUpperInvariant());
		}

	}
}


