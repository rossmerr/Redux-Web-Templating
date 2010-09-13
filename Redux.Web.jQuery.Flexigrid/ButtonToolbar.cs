using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class ButtonToolbar : IFlexigridToolbarConfiguration
    {
        private List<IButtonSeparator> buttons = new List<IButtonSeparator>();

        public IList<IButtonSeparator> GetButtons()
        {
            return buttons;
        }

        public void AddButton(string label)
        {
            buttons.Add(new Button(label, string.Empty));
        }

        public void AddButton(string label, string bClass)
        {
            buttons.Add(new Button(label, bClass));
        }

        public void AddSeparator()
        {
            buttons.Add(new ButtonSeparator());
        }

        public void AddButton(string label, string bClass, string pressCallback)
        {
            buttons.Add(new Button(label, bClass, pressCallback));
        }
    }
}
