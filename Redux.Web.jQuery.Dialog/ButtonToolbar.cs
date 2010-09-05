using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class ButtonToolbar : IButtonConfiguration
    {
        private List<IButtonSeparator> buttons = new List<IButtonSeparator>();

        public IList<IButtonSeparator> GetButtons()
        {
            return buttons;
        }

        public void AddButton(string label, string onpress)
        {
            buttons.Add(new Button(label,  onpress));
        }
    }
}
