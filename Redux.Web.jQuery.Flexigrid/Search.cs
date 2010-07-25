using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class Search<TModel> : ISearchConfiguration<TModel>
    {
        private IList<ISearchItem<TModel>> serach = new List<ISearchItem<TModel>>();

        public IList<ISearchItem<TModel>> GetSearchFields()
        {
            return serach;
        }

        public void AddField(Expression<Func<TModel, object>> property)
        {
            throw new NotImplementedException();
        }

        public void AddField(Expression<Func<TModel, object>> property, string label)
        {
            serach.Add(new SearchItem<TModel>(property, label));
        }
    }
}
