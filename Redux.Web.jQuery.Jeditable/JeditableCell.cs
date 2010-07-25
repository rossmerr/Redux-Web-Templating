using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Redux.Web.jQuery.Jeditable
{
    public class JeditableCell
    {
        [DisplayName("id")]
        public string Id { get; set; }

        [DisplayName("value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
