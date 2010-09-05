using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class Button : IButton
    {
        public Button(string label, string onpress)
        {
            Label = label;
            OnPressCallback = onpress;
        }

        public string Label
        {
            get;
            protected set;
        }

        public string BtnClass
        {
            get;
            protected set;
        }

        public string OnPressCallback
        {
            get;
            protected set;
        }
    }
}
