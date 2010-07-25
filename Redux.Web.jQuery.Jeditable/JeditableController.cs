using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Jeditable
{
    public class JeditableController : TemplateController 
    {
        [HttpGet]
        public JavaScriptResult Script()
        {
            var javaScriptResult = new JavaScriptResult();
            javaScriptResult.Script = "";

            return javaScriptResult;
        }
    }
}
