using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class Button : IButton
    {
        public Button(string label, string bClass)
        {
            Label = label;
            BtnClass = bClass;
        }

        public string Label
        {
            get; protected set;
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
