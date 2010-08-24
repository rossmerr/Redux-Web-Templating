using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.SmartTextBox
{
    public class SmartTextBoxController : Controller
    {
        private const string PATH = "Redux.Web.jQuery.SmartTextBox";
        private const string SCRIPT = "Script.SmartTextBox.js";
        private const string STYLE = "Content.SmartTextBox.css";
        private const string IMAGE = "Content.images.close.gif";

        [HttpGet]
        public ActionResult Api()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, SCRIPT);
            return Content(ResourceManager.StreamToString(stream));
        }

        [HttpGet]
        public CssResult Style()
        {
            return new CssResult(ResourceManager.GetEmbeddedFile(PATH, STYLE));
        }

        [HttpGet]
        public GifResult Image()
        {            
            var img = System.Drawing.Image.FromStream(ResourceManager.GetEmbeddedFile(PATH, IMAGE));
            return new GifResult { Image = img }; 
        }
    }
}
