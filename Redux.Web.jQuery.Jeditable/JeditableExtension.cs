using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Redux.Web.Html;
using Redux.Web.jQuery.Flexigrid;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Jeditable
{
    public static class JeditableExtension
    {
        public static IColumn<TModel> Editable<TModel>(this IColumn<TModel> column, string cssClass)
        {
            return column.Editable(cssClass, new RouteValueDictionary());
        }

        public static IColumn<TModel> Editable<TModel>(this IColumn<TModel> column, string cssClass, object url)
        {
            return column.Editable(cssClass, new RouteValueDictionary(url));
        }

        public static IColumn<TModel> Editable<TModel>(this IColumn<TModel> column, string cssClass, RouteValueDictionary url)
        {
            var configuration = new JeditableConfiguration { CssClass = cssClass, Url = url };
            column.PreRender(new PreRenderDelegate<TModel>(PreRender), configuration);
            column.PostRender(new PostRenderDelegate<TModel>(PostRender), configuration);
            return column;
        }

        private static string PreRender<TModel>(IColumn<TModel> column)
        {
            var configuration = column.PreRenderObject as JeditableConfiguration;

            return JeditableWriter.Wrapper(configuration.CssClass); 
        }

        private static string PostRender<TModel>(IColumn<TModel> column, HtmlHelper htmlHelper)
        {
            return JeditableWriter.Writer(htmlHelper, column);
        }
    }
}
