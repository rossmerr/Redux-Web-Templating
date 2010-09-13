using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public interface IButtonConfiguration
    {
        IList<IButtonSeparator> GetButtons();
        void AddButton(string label);
    }
}
