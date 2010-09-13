using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public interface IFlexigridToolbarConfiguration : IToolbarConfiguration
    {
        void AddButton(string label, string bClass, string pressCallback);
    }
}
