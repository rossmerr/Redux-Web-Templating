using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class SearchItem<TModel> : ISearchItem<TModel>
    {
        public SearchItem(Expression<Func<TModel, object>> property, string label)
        {
            Display = Property.GetExpressFromProperty(property);
            Name = label;
        }

        public string Display
        {
            get; protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public bool IsDefault
        {
            get;
            protected set;
        }
    }
}
