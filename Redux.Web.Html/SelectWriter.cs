using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Redux.Web.Html
{
    public class SelectWriter
    {
        public static void Writer(HtmlHelper htmlHelper, IEnumerable<SelectListItem> collection, object htmlAttributes)
        {
            Writer(htmlHelper, collection, new RouteValueDictionary(htmlAttributes));
        }

        public static void Writer(HtmlHelper htmlHelper, IEnumerable<SelectListItem> collection, IDictionary<string, object> htmlAttributes)
        {
            var select = new TagBuilder("select");
            select.MergeAttributes(htmlAttributes);

            var sb = new StringBuilder();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    var option = new TagBuilder("option");
                    option.MergeAttribute("value", item.Value);

                    if (item.Selected)
                    {
                        option.MergeAttribute("selected", "selected");
                    }

                    option.SetInnerText(item.Text);

                    sb.AppendLine(option.ToString(TagRenderMode.Normal));
                }
            }

            select.InnerHtml = sb.ToString();

            htmlHelper.ViewContext.Writer.Write(select.ToString(TagRenderMode.Normal));
        }
    }
}
