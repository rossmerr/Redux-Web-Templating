using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.Templating
{
    public class CssResult : ActionResult
    {
        public CssResult(Stream stream)
        {
            Stream = stream;
        }

        public Stream Stream { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/css";
            CopyStream(Stream, context.HttpContext.Response.OutputStream);
        }

        public static void CopyStream(Stream input, Stream output)
        {
            var buffer = new byte[32768];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }

    }
}