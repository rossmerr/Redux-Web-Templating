using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.Templating
{
    public class GifResult : ActionResult
    {
        public Image Image { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "image/gif";

            Image.Save(context.HttpContext.Response.OutputStream, ImageFormat.Gif);
        }
    }
}
