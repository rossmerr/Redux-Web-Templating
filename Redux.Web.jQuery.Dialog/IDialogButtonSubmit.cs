using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Redux.Web.jQuery.Dialog
{
    public interface IDialogButtonSubmit : IDialogButton
    {
        IDialogButtonSubmit Target(string value);

        IDialogButtonSubmit BeforeSubmit(string value);

        IDialogButtonSubmit Success(string value);

        IDialogButtonSubmit Data(object value);

        IDialogButtonSubmit Data(IDictionary<string, object> value);

        IDialogButtonSubmit Options(string value);
    }
}
