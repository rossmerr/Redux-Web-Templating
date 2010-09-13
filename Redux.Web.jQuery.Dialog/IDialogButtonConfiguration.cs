using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public interface IDialogButtonConfiguration : IButtonConfiguration
    {
        new IDialogButton AddButton(string label);

        new IList<IDialogButton> GetButtons();
    }
}
