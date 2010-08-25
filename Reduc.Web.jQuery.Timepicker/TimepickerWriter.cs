using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Timepicker
{
    public class TimepickerWriter
    {
        public static void Writer(HtmlHelper htmlHelper, string target)
        {
            using (var script = new TemplateScript(htmlHelper.ViewContext, htmlHelper.ViewContext.Writer, htmlHelper.ViewContext.FormContext))
            {
                script.WriteLine(string.Format("$('#{0}').{1} (", target, Resources.Options.datetimepicker));
                script.WriteLine(");");
            }
        }
    }
}
