using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridCollection<TModel>
    {
        public FlexigridCollection()
        {
            rows = new List<FlexigridRow<TModel>>();
        }

        [DisplayName("page")]
        public int page { get; set; }

        [DisplayName("total")]
        public int total { get; set; }

        [DisplayName("rows")]
        public List<FlexigridRow<TModel>> rows { get; set; }
    }
}
