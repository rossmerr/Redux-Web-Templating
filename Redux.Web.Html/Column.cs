using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.Html
{
    public class Column<TModel> : IColumn<TModel>
    {
        public string LabelInternal { get; protected set; }
        public bool SortableInternal { get; protected set; }
        public int? WidthInternal { get; protected set; }
        public Align AlignInternal { get; protected set; }
        public bool VisibleInternal { get; protected set; }
        public bool PrimaryInternal { get; protected set; }
        public PostRenderDelegate<TModel> PostRenderDelegate { get; protected set; }
        public PreRenderDelegate<TModel> PreRenderDelegate { get; protected set; }
        public object PostRenderObject { get; protected set; }
        public object PreRenderObject { get; protected set; }

        public IDictionary<string, object> HtmlAttributes { get; protected set; }

        public Column(Expression<Func<TModel, object>> property)
        {
            Property = property;
            VisibleInternal = true;
        }

        public Expression<Func<TModel, object>> Property { get; protected set; }


        public IColumn<TModel> Width(int width)
        {
            WidthInternal = width;
            return this;
        }

        public IColumn<TModel> Align(Align align)
        {
            AlignInternal = align;
            return this;
        }

        public IColumn<TModel> Label(string label)
        {
            LabelInternal = label;
            return this;
        }

        public IColumn<TModel> Sortable(bool sortable)
        {
            SortableInternal = sortable;
            return this;
        }

        public IColumn<TModel> IsVisible(bool visible)
        {
            VisibleInternal = visible;
            return this;
        }

        public IColumn<TModel> IsPrimary(bool primary)
        {
            PrimaryInternal = primary;
            return this;
        }

        public IColumn<TModel> AddAttributes(object htmlAttributes)
        {
            return AddAttributes((IDictionary<string, object>) new RouteValueDictionary(htmlAttributes));
        }

        public IColumn<TModel> AddAttributes(IDictionary<string, object> htmlAttributes)
        {
            HtmlAttributes = htmlAttributes;
            return this;
        }

        public void PreRender(PreRenderDelegate<TModel> preRenderDelegate, object obj)
        {
            PreRenderDelegate = preRenderDelegate;
            PreRenderObject = obj;
        }


        public void PostRender(PostRenderDelegate<TModel> postRenderDelegate, object obj)
        {
            PostRenderDelegate = postRenderDelegate;
            PostRenderObject = obj;
        }
    }
}
