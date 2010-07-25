using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public interface ISearchItem<TModel>
    {
        string Display { get; }
        string Name { get; }
        bool IsDefault { get; }
    }
}
