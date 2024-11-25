// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Helpers
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public static class Helpers
    {
        public static string AppendTo(this string? source, string? value, char separator = ' ')
        {
            string str1 = source;
            string str2;
            if (!string.IsNullOrEmpty(source))
            {
                ReadOnlySpan<char> readOnlySpan1 = value; // Assuming 'value' is a compatible type
                char separatorChar = separator;
                ReadOnlySpan<char> readOnlySpan2 = new ReadOnlySpan<char>(new[] { separatorChar });
                str2 = readOnlySpan1.ToString() + readOnlySpan2.ToString();
            }

            else
                str2 = value;
            return source = str1 + str2;
        }

        public static void Print(params object[] objects)
        {
            foreach (object obj in objects)
                Console.WriteLine(obj);
        }
    }
}
