using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class ButtonToolbar : IToolbarConfiguration
    {
        private List<IButtonSeparator> buttons = new List<IButtonSeparator>();

        public IList<IButtonSeparator> GetButtons()
        {
            return buttons;
        }

        public void AddButton(string label, string onpress)
        {
            buttons.Add(new Button(label, string.Empty, onpress));
        }

        public void AddButton(string label, string bClass, string onpress)
        {
            buttons.Add(new Button(label, bClass, onpress));
        }

        public void AddSeparator()
        {
            buttons.Add(new ButtonSeparator());
        }
    }
}
