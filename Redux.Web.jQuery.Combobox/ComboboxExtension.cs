using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Combobox
{
    public static class ComboboxExtension
    {
        public static string Combobox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> collection)
        {
            htmlHelper.ViewContext.Writer.WriteLine(htmlHelper.DropDownList(name, collection));
            ComboboxWriter.Writer(htmlHelper, name);
            return string.Empty;
        }

        public static string ComboboxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, 
            IEnumerable<SelectListItem> collection)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            name = Identifier.GenerateId(name);

            
            htmlHelper.ViewContext.Writer.WriteLine(htmlHelper.DropDownList(name, collection));
            ComboboxWriter.Writer(htmlHelper, name);
            return string.Empty;
        }
    }
}
