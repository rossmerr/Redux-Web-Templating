using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class ButtonToolbar : IDialogButtonConfiguration
    {
        private List<IDialogButton> buttons = new List<IDialogButton>();


        public IList<IButtonSeparator> GetButtons()
        {
            return buttons.ToList<IButtonSeparator>();

        }

        IDialogButton IDialogButtonConfiguration.AddButton(string label)
        {
            var btn = new Button(label);
            buttons.Add(btn);
            return btn;
        }

        IList<IDialogButton> IDialogButtonConfiguration.GetButtons()
        {
            return buttons;
        }

        public void AddButton(string label)
        {
            AddButton(label);
        }
    }
}
