using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Lenkie_Assessment.Helpers
{
    public class MiscUse
    {
        #region HashMethods enum

        public enum HashMethods
        {
            SHA512
        }

        #endregion
        private string _siteWideSalt;

        internal void SetSiteWideSalt(string siteWideSalt)
        {
            this._siteWideSalt = siteWideSalt;
        }

        public string Hash(string password, string passwordSalt, HashMethods method)
        {
            SetSiteWideSalt("THIS IS A SITE WIDE SALT, BUT COULD BE A GUID");
            string encryptedPassword;
            switch (method)
            {
                default:
                    encryptedPassword =
                        HashSHA512Managed($"{_siteWideSalt}{password}{passwordSalt}");
                    break;
            }

            return encryptedPassword;
        }

        public static string HashSHA512Managed(string saltedPassword)
        {
            var uniEncode = new UnicodeEncoding();
            using (var sha = new SHA512Managed())
            {
                var bytePassword = uniEncode.GetBytes(saltedPassword);
                var hash = sha.ComputeHash(bytePassword);
                return Convert.ToBase64String(hash);
            }
        }

        public static string GetIpAddress() // Get IP Address
        {
            var str = "";
            str = Dns.GetHostName();
            var ipEntry = Dns.GetHostEntry(str);
            var address = ipEntry.AddressList;
            return address[address.Length - 1].ToString();
        }


    }
}
