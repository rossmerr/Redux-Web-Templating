using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public class CssWidth
    {
        protected bool Auto = false;
        protected int Width = 0;

        public CssWidth()
        {
            Auto = true;           
        }

        public CssWidth(int width)
        {
            Width = width;
        }

        public bool IsAuto
        {
            get
            {
                return Auto;
            }

        }

        public override string ToString()
        {
            return IsAuto ? "'auto'" : Width.ToString();
        }
    }
}
