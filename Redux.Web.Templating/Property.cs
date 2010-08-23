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
            var type = property.Body.NodeType;
            if (type == ExpressionType.Convert)
            {
                var unary = (UnaryExpression)property.Body;
                var expression = (MemberExpression)unary.Operand;
                return expression.Member.Name;
            }
            else
            {
                var expression = (MemberExpression) property.Body;
                return expression.Member.Name;
            }
        }

        public static Delegate CreatePropertyDelegate<TModel, TProperty>(string property)
        {
            var propertyInfo = typeof(TModel).GetProperty(property);
            var method = propertyInfo.GetAccessors(true);

            if (method != null && method.Count() > 0)
            {
                if (propertyInfo.PropertyType == typeof(Guid))
                {
                    return  Delegate.CreateDelegate(typeof(Func<TModel, Guid>), method.First());
                }
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    return Delegate.CreateDelegate(typeof(Func<TModel, int>), method.First());
                }

                return Delegate.CreateDelegate(typeof(Func<TModel, TProperty>), method.First());
            }

            return null;
        }
    }
}
