using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public interface IFlexigridConfiguration<TModel>
    {
        IFlexigridConfiguration<TModel> Buttons(Action<IToolbarConfiguration> buttons);
        IFlexigridConfiguration<TModel> SearchItems(Action<ISearchConfiguration<TModel>> searchItems);

        IFlexigridConfiguration<TModel> Url(object url);
        IFlexigridConfiguration<TModel> Url(object url, DataType dataType);
        IFlexigridConfiguration<TModel> Url(RouteValueDictionary url, DataType dataType);

        IFlexigridConfiguration<TModel> Sort(Expression<Func<TModel, object>> sort, SortOrder order);

        IFlexigridPagerConfiguration<TModel> UsePager();

        IFlexigridConfiguration<TModel> ShowTableToggleBtn();

        IFlexigridConfiguration<TModel> Width(int width);
        IFlexigridConfiguration<TModel> Height(int height);

        IFlexigridConfiguration<TModel> SingleSelect(bool singleSelect);

        IFlexigridConfiguration<TModel> Title(string title);
    }
}
