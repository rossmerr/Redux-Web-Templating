using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Redux.Web.jQuery.Combobox
{
    public static class ComboboxExtension
    {
        public static void ComboboxFor(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> collection)
        {
            htmlHelper.ViewContext.Writer.WriteLine(htmlHelper.DropDownList(name, collection));
            ComboboxWriter.Writer(htmlHelper, name);
        }
    }
}
