using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.jQuery.SmartTextBox
{
    public static class ControllerExtensions
    {
        public static SmartTextBoxResult SmartTextBoxView(this Controller controller, IEnumerable<string> collection)
        {
            return new SmartTextBoxResult
            {
                Data = new SmartTextBoxResultObject { values = collection },
                ContentType = null,
                ContentEncoding = null,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            
        }

        public class SmartTextBoxResultObject
        {
            public IEnumerable<string> values { get; set; }
        }
    }
}
