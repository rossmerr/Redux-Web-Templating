using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public interface IDialogButton : IButtonSeparator
    {
        IDialogButton Validate();
        IDialogButtonSubmit Submit();
        IDialogButton Reset();
        IDialogButton Close();
        IDialogButton Function(string function);
    }
}
