using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public interface IDialogConfiguration
    {
        IDialogConfiguration Disabled(bool value);
        IDialogConfiguration AutoOpen(bool value);
        IDialogConfiguration Buttons(Action<IDialogButtonConfiguration> buttons);
        IDialogConfiguration CloseOnEscape(bool value);
        IDialogConfiguration CloseText(string value);
        IDialogConfiguration DialogClass(string value);
        IDialogConfiguration Draggable(bool value);
        IDialogConfiguration Height(int value);
        IDialogConfiguration Hide(bool value);
        IDialogConfiguration MaxHeight(int value);
        IDialogConfiguration MaxWidth(int value);
        IDialogConfiguration MinHeight(int value);
        IDialogConfiguration MinWidth(int value);
        IDialogConfiguration Modal(bool value);
        IDialogConfiguration Position(string value);
        IDialogConfiguration Resizable(bool value);
        IDialogConfiguration Show(string value);
        IDialogConfiguration Stack(bool value);
        IDialogConfiguration Title(string value);
        IDialogConfiguration Width(int value);
        IDialogConfiguration ZIndex(int value);

        //events
        IDialogConfiguration OnOpen(string value);
        IDialogConfiguration OnOpen(object routeValues);
        IDialogConfiguration OnOpen(RouteValueDictionary routeValues);

        IDialogConfiguration OnClose(string value);
        IDialogConfiguration OnClose(object routeValues);
        IDialogConfiguration OnClose(RouteValueDictionary routeValues);
    }
}
