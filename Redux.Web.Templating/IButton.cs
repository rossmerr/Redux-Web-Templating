using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public interface IButton : IButtonSeparator
    {
        string Label { get;}
        string BtnClass { get; }
        string OnPressCallback { get; }
    }
}
