using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.Html
{
    internal class DataTable<TModel> : IDataTableConfiguration<TModel>
    {
        private List<IColumn<TModel>> Columns = new List<IColumn<TModel>>();

        public IColumn<TModel> AddColumn(Expression<Func<TModel, object>> property)
        {
            var column = new Column<TModel>(property);
            Columns.Add(column);
            return column;
        }

        public IList<IColumn<TModel>> GetColumns()
        {
            return Columns;
        }
    }
}
