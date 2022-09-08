using System.Collections.Generic;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface ICryptographyHelper
    {
        string GetMd5Hash(string input);
        bool VerifyMd5Hash(string input, string hash);
		string Encrypt(string decrypted);
		string Decrypt(string encrypted);
		string PrivateInternalDecryption(string encrypted);
		string PrivateInternalEncryption(string decrypted);
		string GenerateStudentCodeForGuardian();
		string GenerateHashedStringForPayFast(Dictionary<string, string> data);

	}
}
