using System.Text;

namespace Logic.Tools
{
    /// <summary>
    /// set of useful security functions
    /// </summary>
    public class CryptoEncreption
    {
        /// <summary>
        /// get upper case md5 encryption
        /// </summary>
        /// <param name="input">data</param>
        /// <returns>UPPER case md5 hash</returns>
        public static string Md5Encrypt(string input)
        {
            if (input == null || input.Length == 0)
            {
                return "";
            }

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}