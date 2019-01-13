using System;
using System.Collections.Specialized;
using System.Text;

namespace UACHelper.Helpers
{
    internal static class IOPath
    {
        public static string BuildCommandLine(string executableFileName, string arguments)
        {
            var stringBuilder = new StringBuilder();
            var str = executableFileName.Trim();
            var num = !str.StartsWith("\"", StringComparison.Ordinal)
                ? 0
                : (str.EndsWith("\"", StringComparison.Ordinal) ? 1 : 0);

            if (num == 0)
            {
                stringBuilder.Append("\"");
            }

            stringBuilder.Append(str);

            if (num == 0)
            {
                stringBuilder.Append("\"");
            }

            if (!string.IsNullOrEmpty(arguments))
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(arguments);
            }

            return stringBuilder.ToString();
        }

        // ReSharper disable once FlagArgument
        public static byte[] EnvironmentBlockToByteArray(StringDictionary stringDictionary, bool unicode)
        {
            var strArray1 = new string[stringDictionary.Count];
            stringDictionary.Keys.CopyTo(strArray1, 0);
            var strArray2 = new string[stringDictionary.Count];
            stringDictionary.Values.CopyTo(strArray2, 0);
            Array.Sort(strArray1, (Array) strArray2, StringComparer.OrdinalIgnoreCase);
            var stringBuilder = new StringBuilder();

            for (var index = 0; index < stringDictionary.Count; ++index)
            {
                stringBuilder.Append(strArray1[index]);
                stringBuilder.Append('=');
                stringBuilder.Append(strArray2[index]);
                stringBuilder.Append(char.MinValue);
            }

            stringBuilder.Append(char.MinValue);
            byte[] bytes;

            if (unicode)
            {
                bytes = Encoding.Unicode.GetBytes(stringBuilder.ToString());
            }
            else
            {
                bytes = Encoding.Default.GetBytes(stringBuilder.ToString());

                if (bytes.Length > ushort.MaxValue)
                {
                    throw new InvalidOperationException("Environment Block Too Long");
                }
            }

            return bytes;
        }
    }
}