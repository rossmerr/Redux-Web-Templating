using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Reduc.Web.jQuery.Timepicker
{
    public static class TimepickerExtensions
    {
        public static string TimepickerFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            htmlHelper.ViewContext.Writer.WriteLine(htmlHelper.TextBoxFor(expression).ToHtmlString());
            var target = ExpressionHelper.GetExpressionText(expression);
            TimepickerWriter.Writer(htmlHelper, target);
            return string.Empty;
        }

        public static string TimepickerApi(this HtmlHelper htmlHelper)
        {
            var script = new TagBuilder("script");
            script.MergeAttribute("type", "text/javascript");
            script.MergeAttribute("src", "/Timepicker/Api");
            return script.ToString(TagRenderMode.Normal);
        }
    }
}
