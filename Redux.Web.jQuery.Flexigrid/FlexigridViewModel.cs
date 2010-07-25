using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridViewModel
    {
        [DisplayName("page")]
        public int Page { get; set; }
        
        [DisplayName("qtype")]
        public string QType { get; set; }

        [DisplayName("query")]
        public string Query { get; set; }

        [DisplayName("rp")]
        public int RP { get; set; }

        [DisplayName("sortname")]
        public string SortName { get; set; }

        [DisplayName("sortorder")]
        public string SortOrder { get; set; }

    }
}
