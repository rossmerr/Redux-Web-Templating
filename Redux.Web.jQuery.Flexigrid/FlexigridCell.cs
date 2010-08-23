using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridCell<TModel>
    {
        public string Wrapper { get; set; }
        public Delegate Delegate { get; set; }
        public string Id { get; set; }
    }
}
