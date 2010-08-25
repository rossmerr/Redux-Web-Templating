using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public class Identifier
    {
        public static string GenerateId()
        {
            return "i" + Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string GenerateId(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var c = name[0].ToString();

            if (!ReduxArch.Util.Validation.IsAlpha(c))
            {
                return null;
            }

            var builder = new StringBuilder(name.Length);
            builder.Append(c);

            for (var i = 1; i < name.Length; i++)
            {
                var ch2 = name[i].ToString();
                builder.Append(IsValidIdCharacter(ch2) ? ch2 : "_");
            }

            return builder.ToString();
        }

        private static bool IsValidIdCharacter(string c)
        {
            return ReduxArch.Util.Validation.IsAlphaNumeric(c) || IsAllowableSpecialCharacter(c);
        }

        private static bool IsAllowableSpecialCharacter(string c)
        {
            return ((c == "-") || (c == ":")) || (c == "_");
        }
    }
}
