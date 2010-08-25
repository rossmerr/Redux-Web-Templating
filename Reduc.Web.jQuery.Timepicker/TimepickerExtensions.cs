using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Timepicker
{
    public static class TimepickerExtensions
    {
        public static string TimepickerFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            name = Identifier.GenerateId(name);

            htmlHelper.ViewContext.Writer.WriteLine(htmlHelper.TextBoxFor(expression).ToHtmlString());
            TimepickerWriter.Writer(htmlHelper, name);
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
