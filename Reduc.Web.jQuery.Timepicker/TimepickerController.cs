using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Timepicker
{
    public class TimepickerController : Controller
    {
        private const string PATH = "Redux.Web.jQuery.Timepicker";
        private const string SCRIPT = "Script.jquery-ui-timepicker-addon-0.5.js";

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Api()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, SCRIPT);
            return Content(ResourceManager.StreamToString(stream));
        }


    }
}
