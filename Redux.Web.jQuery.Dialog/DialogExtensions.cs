using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Redux.Web.jQuery.Dialog
{
    public static class DialogExtensions
    {
        public static IDialogConfiguration Dialog(this HtmlHelper htmlHelper, string target)
        {
            return htmlHelper.Dialog(target, null);
        }

        public static IDialogConfiguration Dialog(this HtmlHelper htmlHelper, string target, object routeValues)
        {
            return htmlHelper.Dialog(target, new RouteValueDictionary(routeValues));
        }

        public static IDialogConfiguration Dialog(this HtmlHelper htmlHelper, string target, RouteValueDictionary routeValues)
        {
            return new DialogConfiguration(htmlHelper, target, routeValues);
        }

        public static IDialogConfiguration Dialog(this HtmlHelper htmlHelper, string target, RouteValueDictionary routeValues, Postback postback)
        {
            return new DialogConfiguration(htmlHelper, target, routeValues, postback);
        }

        public static string DialogForm(this HtmlHelper htmlHelper)
        {
            var script = new TagBuilder("script");
            script.MergeAttribute("type", "text/javascript");
            script.MergeAttribute("src", "/Dialog/Form");
            return script.ToString(TagRenderMode.Normal);
        }

        public static string DialogValidate(this HtmlHelper htmlHelper)
        {
            var script = new TagBuilder("script");
            script.MergeAttribute("type", "text/javascript");
            script.MergeAttribute("src", "/Dialog/Validate");
            return script.ToString(TagRenderMode.Normal);
        }
    }
}
