using Sysinfocus.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.KeyGenerator
{
    public static class LicenseKeyGenerator
    {
        public static string MATCH = "9599465319";

      

        public static string GenerateKey()
        {
            Random rand = new Random();
            int startIndex = rand.Next(1, 9); // Choose a startIndex between 1 and 8

            // Initialize str1 with the startIndex digit
            StringBuilder str1Builder = new StringBuilder();
            str1Builder.Append(startIndex.ToString());

            // Add random characters to reach the startIndex position
            for (int i = 1; i < startIndex; i++)
            {
                str1Builder.Append(GetRandomChar(rand));
            }

            // Build str3 according to the MATCH pattern
            StringBuilder str3Builder = new StringBuilder();

            for (int i = 0; i < 19; i++)
            {
                if (i % 2 == 0)
                {
                    // Even index: use character from MATCH
                    str3Builder.Append(MATCH[i / 2]);
                }
                else
                {
                    // Odd index: use a random character
                    str3Builder.Append(GetRandomChar(rand));
                }
            }

            // Combine str1 and str3
            str1Builder.Append(str3Builder.ToString());

            // Insert dashes every 5 characters to format the key
            StringBuilder keyBuilder = new StringBuilder();
            string str1 = str1Builder.ToString();
            for (int i = 0; i < str1.Length; i++)
            {
                keyBuilder.Append(str1[i]);
                if ((i + 1) % 5 == 0 && i != str1.Length - 1)
                {
                    keyBuilder.Append('-');
                }
            }

            string key = keyBuilder.ToString();
            return key;
        }

        private static char GetRandomChar(Random rand)
        {
            // Generate a random uppercase letter or digit
            int num = rand.Next(0, 36);
            if (num < 10)
                return (char)('0' + num);
            else
                return (char)('A' + num - 10);
        }
    }
}
