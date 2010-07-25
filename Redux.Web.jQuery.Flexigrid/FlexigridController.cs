using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridController : TemplateController
    {
        private const string PATH = "Redux.Web.jQuery.Flexigrid";
        private const string SCRIPT = "Scripts.flexigrid.js";

        [HttpGet]
        public JavaScriptResult Script()
        {
            var javaScriptResult = new JavaScriptResult();
            javaScriptResult.Script = "";
            
            return javaScriptResult;
        }
    }
}
