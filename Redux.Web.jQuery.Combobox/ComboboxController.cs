using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Combobox
{
    public class ComboboxController : Controller
    {
        private const string PATH = "Redux.Web.jQuery.Combobox";
        private const string SCRIPT = "Script.combobox.js";
        private const string SCRIPTchained = "Script.jquery.chainedSelects.js";

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Api()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, SCRIPT);
            return Content(ResourceManager.StreamToString(stream));
        }

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult ChainedApi()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, SCRIPTchained);
            return Content(ResourceManager.StreamToString(stream));
        }
    }
}
