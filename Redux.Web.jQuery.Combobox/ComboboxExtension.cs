using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Redux.Web.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Combobox
{
    public static class ComboboxExtension
    {
        public static string Combobox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> collection)
        {
            SelectWriter.Writer(htmlHelper, collection, new { Name = name, id = name });
            ComboboxWriter.Writer(htmlHelper, name);
            return string.Empty;
        }

        public static string ComboboxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, 
            IEnumerable<SelectListItem> collection)
        {
            return htmlHelper.ComboboxFor(expression, collection,
                                 (IDictionary<string, object>)new RouteValueDictionary());
        }

        public static string ComboboxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
            IEnumerable<SelectListItem> collection, object htmlAttributes)
        {
            return htmlHelper.ComboboxFor(expression, collection,
                                 (IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));
        }

        public static string ComboboxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression,
            IEnumerable<SelectListItem> collection, IDictionary<string, object> htmlAttributes)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            name = Identifier.GenerateId(name);

            htmlAttributes.Add("Name", name);
            htmlAttributes.Add("Id", name);

            SelectWriter.Writer(htmlHelper, collection, htmlAttributes);
            ComboboxWriter.Writer(htmlHelper, name);
            return string.Empty;
        }


        public static string ComboboxApi(this HtmlHelper htmlHelper)
        {
            var script = new TagBuilder("script");
            script.MergeAttribute("type", "text/javascript");
            script.MergeAttribute("src", "/Combobox/Api");
            return script.ToString(TagRenderMode.Normal);
        }
    }
}
