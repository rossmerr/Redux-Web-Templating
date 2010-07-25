using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Redux.Web.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Jeditable
{
    class JeditableColumn<TModel> : Column<TModel>
    {
        public JeditableColumn(Expression<Func<TModel, object>> property) : base(property)
        {
        }
    }
}
