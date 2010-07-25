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

    }
}
