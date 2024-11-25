using Microsoft.Extensions.DependencyInjection;
using System.Text;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public static class InitializeSysinfocus
    {
        private const string CDN_LOTTIE_JS = "https://unpkg.com/@lottiefiles/lottie-player@latest/dist/lottie-player.js";
        private const string CDN_MAPS_CSS = "https://unpkg.com/leaflet@1.9.4/dist/leaflet.css";
        private const string CDN_MAPS_JS = "https://unpkg.com/leaflet@1.9.4/dist/leaflet.js";
        private const string CDN_SORTABLE_JS = "https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js";
        private const string CDN_BARCODE_JS = "https://cdnjs.cloudflare.com/ajax/libs/jsbarcode/3.11.6/JsBarcode.all.min.js";
        private const string CDN_QRCODE_JS = "https://cdnjs.cloudflare.com/ajax/libs/qrcodejs/1.0.0/qrcode.min.js";
        private const string CDN_CODESCANNER_JS = "https://unpkg.com/@zxing/library@latest/umd/index.min.js";
        private const string CDN_ECHARTS_JS = "https://cdn.jsdelivr.net/npm/echarts@5.5.1/dist/echarts.min.js";
        internal static string LOTTIE_JS = "_content/Sysinfocus.AspNetCore.Components/lottie-player.js";
        internal static string MAPS_CSS = "_content/Sysinfocus.AspNetCore.Components/leaflet.css";
        internal static string MAPS_JS = "_content/Sysinfocus.AspNetCore.Components/leaflet.js";
        internal static string SORTABLE_JS = "_content/Sysinfocus.AspNetCore.Components/Sortable.min.js";
        internal static string BARCODE_JS = "_content/Sysinfocus.AspNetCore.Components/JsBarcode.all.min.js";
        internal static string QRCODE_JS = "_content/Sysinfocus.AspNetCore.Components/qrcode.min.js";
        internal static string CODESCANNER_JS = "_content/Sysinfocus.AspNetCore.Components/index.min.js";
        internal static string ECHARTS_JS = "_content/Sysinfocus.AspNetCore.Components/echarts.min.js";
        internal static bool IsLicensed;

        public static IServiceCollection AddSysinfocus(
          this IServiceCollection services,
          string? licenseKey = "trial",
          bool jsCssFromCDN = false)
        {
            if (jsCssFromCDN)
            {
                InitializeSysinfocus.LOTTIE_JS = "https://unpkg.com/@lottiefiles/lottie-player@latest/dist/lottie-player.js";
                InitializeSysinfocus.MAPS_CSS = "https://unpkg.com/leaflet@1.9.4/dist/leaflet.css";
                InitializeSysinfocus.MAPS_JS = "https://unpkg.com/leaflet@1.9.4/dist/leaflet.js";
                InitializeSysinfocus.SORTABLE_JS = "https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js";
                InitializeSysinfocus.BARCODE_JS = "https://cdnjs.cloudflare.com/ajax/libs/jsbarcode/3.11.6/JsBarcode.all.min.js";
                InitializeSysinfocus.QRCODE_JS = "https://cdnjs.cloudflare.com/ajax/libs/qrcodejs/1.0.0/qrcode.min.js";
                InitializeSysinfocus.CODESCANNER_JS = "https://unpkg.com/@zxing/library@latest/umd/index.min.js";
                InitializeSysinfocus.ECHARTS_JS = "https://cdn.jsdelivr.net/npm/echarts@5.5.1/dist/echarts.min.js";
            }

            if (licenseKey != "trial" && !string.IsNullOrWhiteSpace(licenseKey))
            {
                InitializeSysinfocus.IsLicensed = InitializeSysinfocus.VerifyLicenseKey(licenseKey);
            }

            services.AddScoped<Initialization>();
            services.AddScoped<StateManager>();
            services.AddScoped<BrowserExtensions>();
            return services;
        }
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
            string MATCH = ComponentExtension.MATCH;
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
        private static bool VerifyLicenseKey(string key)
        {
            try
            {
                string str1 = key.Replace("-", "");
                string str2 = str1;
                int startIndex = int.Parse(str1[0].ToString());
                string str3 = str2.Substring(startIndex, str2.Length - startIndex);
                int index1 = 0;
                if (str3.Length < ComponentExtension.MATCH.Length)
                    return false;
                for (int index2 = 0; index2 < str3.Length; index2 += 2)
                {
                    if ((int)ComponentExtension.MATCH[index1] != (int)str3[index2])
                        return false;
                    if (index1 >= 9)
                        return true;
                    ++index1;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
