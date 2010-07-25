using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.Templating
{
    public static class ScriptTag
    {
        public static string Rendar(TagRenderMode renderMode)
        {
            if (renderMode == TagRenderMode.StartTag)
            {
                return ScriptOpen();
            }
            else if (renderMode == TagRenderMode.EndTag)
            {
                return ScriptClose();
            }
            else
            {
                return ScriptOpen() + ScriptClose();
            }
        }

        private static string ScriptOpen()
        {
            var _script = new TagBuilder("script");
            _script.MergeAttribute("type", "text/javascript");

            return _script.ToString(TagRenderMode.StartTag);
        }

        private static string ScriptClose()
        {
            return "</script>";
        }

    }
}
