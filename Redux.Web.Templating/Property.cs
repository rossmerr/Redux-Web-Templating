using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Redux.Web.jQuery.Flexigrid
{
    public class Property
    {
        public static string GetExpressFromProperty<TModel>(Expression<Func<TModel, object>> property)
        {
            var expression = (MemberExpression)property.Body;
            return expression.Member.Name;
        }

        public static Delegate CreatePropertyDelegate<TModel, TProperty>(string property)
        {
            var propertyInfo = typeof(TModel).GetProperty(property);

            var method = propertyInfo.GetAccessors(true);
            if (method != null && method.Count() > 0)
            {
                return Delegate.CreateDelegate(typeof(Func<TModel, TProperty>), method.First());
            }

            return null;
        }
    }
}
