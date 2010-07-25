using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.Templating
{
    public delegate string PostRenderDelegate<TModel>(IColumn<TModel> column, HtmlHelper htmlHelper);
    public delegate string PreRenderDelegate<TModel>(IColumn<TModel> column);

    public interface IColumn<TModel>
    {
        Expression<Func<TModel, object>> Property { get; }
        object PostRenderObject { get; }
        object PreRenderObject { get; }

        IColumn<TModel> Width(int width);
        IColumn<TModel> Align(Align align);
        IColumn<TModel> Label(string label);
        IColumn<TModel> Sortable(bool sortable);
        IColumn<TModel> IsVisible(bool visible);
        IColumn<TModel> IsPrimary(bool primary);


        IColumn<TModel> AddAttributes(object htmlAttributes);
        IColumn<TModel> AddAttributes(IDictionary<string, object> htmlAttributes);

        void PreRender(PreRenderDelegate<TModel> preRenderDelegate, object obj);
        void PostRender(PostRenderDelegate<TModel> postRenderDelegate, object obj);
    }
}
