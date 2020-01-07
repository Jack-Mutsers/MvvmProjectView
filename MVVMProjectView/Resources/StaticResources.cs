using MVVMProjectView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProjectView.Resources
{
    public static class StaticResources
    {
        public static MainWindow mainWindow { get; set; }

        private static Resources _resources = new Resources();
        public static Resources resources
        {
            get
            {
                return _resources;
            }
        }

        public static Guid ApiKey { get; set; } = Guid.Empty;
        public static User UserData { get; set; } = new User();
        public static Category CategorieData { get; set; } = new Category();
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
        public static string Encryptor(string password)
        {
            string encryption = "";

            encryption = password;

            return encryption;
        }
    }
}
