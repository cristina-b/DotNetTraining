using GeneralStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore
{
    public static class HashFactory
    {
        public static string GetHash(Category item)
        {
            if (item == null)
            {
                return string.Empty;
            }
            var itemText = $"{item.Id}|{item.Name}|{item.Description}";
            using (var md5 = MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(itemText));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
