using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace Redux.Web.Templating
{
    public interface IDataTableConfiguration<TModel>
    {
        IList<IColumn<TModel>> GetColumns();
        IColumn<TModel> AddColumn(Expression<Func<TModel, object>> property);
    }
}
