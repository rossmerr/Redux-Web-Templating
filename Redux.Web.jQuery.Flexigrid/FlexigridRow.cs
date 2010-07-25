using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridRow<TModel>
    {
        public FlexigridRow()
        {
            cell = new List<string>();            
        }

        [DisplayName("id")]
        public string id { get; set; }

        [DisplayName("cell")]
        public List<string> cell { get; set; }
    }
}
