using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Jeditable
{
    public static class JeditableWriter
    {
        public static string Wrapper(string cssClass)
        {
            return "<span id=\"{1}\" class=\"" + cssClass + "\">{0}</span>";
        }

        public static string Writer<TModel>(HtmlHelper htmlHelper, IColumn<TModel> column)
        {
            var script = new TagBuilder("script");
            script.MergeAttribute("type", "text/javascript");

            var configuration = column.PostRenderObject as JeditableConfiguration;
            var url = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var routeUrl = url.RouteUrl(configuration.Url);

            var sb = new StringBuilder();
            sb.AppendLine("$(document).ready(function() {");
            //sb.AppendLine( string.Format("$('.{0}').editable('{1}');",  configuration.CssClass, routeUrl));

            sb.AppendLine(string.Format("$('.{0}').live('click', function()", configuration.CssClass));
            sb.Append("{");
            sb.AppendLine(string.Format("$(this).editable('{0}');", routeUrl));
            sb.AppendLine("});");

            sb.AppendLine("});");

            script.InnerHtml = sb.ToString();

            return script.ToString(TagRenderMode.Normal);
        }
    }
}
