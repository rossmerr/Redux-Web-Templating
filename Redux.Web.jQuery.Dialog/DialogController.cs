using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class DialogController : Controller
    {
        private const string PATH = "Redux.Web.jQuery.Dialog";
        private const string FROM = "Scripts.jquery.form.js";
        private const string VALIDATE = "Scripts.jquery.validate.js";

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Form()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, FROM);
            return Content(ResourceManager.StreamToString(stream));
        }

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Validate()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, VALIDATE);
            return Content(ResourceManager.StreamToString(stream));
        }
    }
}
