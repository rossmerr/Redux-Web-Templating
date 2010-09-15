using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.Html
{
    public static class TableExtension
    {

        public static string Table<TModel>(this HtmlHelper htmlHelper, IEnumerable<TModel> collection,
            Action<IDataTableConfiguration<TModel>> columns)
        {
            TableWriter.Writer<TModel>(htmlHelper, collection, columns, null);
            return string.Empty;
        }

        public static string Table<TModel>(this HtmlHelper htmlHelper, IEnumerable<TModel> collection,
            Action<IDataTableConfiguration<TModel>> columns, object htmlAttributes)
        {
            TableWriter.Writer<TModel>(htmlHelper, collection, columns, (IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));
            return string.Empty;
        }

        public static string Table<TModel>(this HtmlHelper htmlHelper, IEnumerable<TModel> collection,
            Action<IDataTableConfiguration<TModel>> columns, IDictionary<string, object> htmlAttributes)
        {
            TableWriter.Writer<TModel>(htmlHelper, collection, columns, htmlAttributes);
            return string.Empty;
        }

        public static string Table<TModel>(this HtmlHelper htmlHelper, IEnumerable<TModel> collection,
            Action<IDataTableConfiguration<TModel>> columns, IDictionary<string, object> htmlAttributes, bool header)
        {
            TableWriter.Writer<TModel>(htmlHelper, collection, columns, htmlAttributes, header);
            return string.Empty;
        }
    }
}
