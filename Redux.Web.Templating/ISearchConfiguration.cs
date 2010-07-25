using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Redux.Web.Templating
{
    public interface ISearchConfiguration<TModel>
    {
        IList<ISearchItem<TModel>> GetSearchFields();

        void AddField(Expression<Func<TModel, object>> property);

        void AddField(Expression<Func<TModel, object>> property, string label);
    }
}
