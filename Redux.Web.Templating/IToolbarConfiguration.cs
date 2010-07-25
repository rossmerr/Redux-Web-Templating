using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Redux.Web.Templating
{
    public interface IToolbarConfiguration
    {
        IList<IButtonSeparator> GetButtons();

        void AddButton(string label, string bClass, string onpress);
        void AddSeparator();
    }
}
