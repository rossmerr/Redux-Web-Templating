using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
        private const string SCRIPT = "Script.flexigrid.js";
        private const string STYLE = "Content.flexigrid.css";
        private const string IMAGE = "Content.images.";

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Api()
        {
            var stream = ResourceManager.GetEmbeddedFile(PATH, SCRIPT);
            return Content(ResourceManager.StreamToString(stream));
        }

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public CssResult Style()
        {
            return new CssResult(ResourceManager.GetEmbeddedFile(PATH, STYLE));
        }

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public ImageResult Images(string id)
        {
            var bmp = System.Drawing.Image.FromStream(ResourceManager.GetEmbeddedFile(PATH, IMAGE + id));

            var info = new FileInfo(id);
            ImageFormat format = ImageFormat.Bmp;

            switch(info.Extension.TrimStart('.').ToLower())
            {
                case "jpg" :
                    format = ImageFormat.Jpeg;
                    break;
                case "gif":
                    format = ImageFormat.Gif;
                    break;
                case "png":
                    format = ImageFormat.Png;
                    break;
                default:
                    break;
            }

            return new ImageResult { Image = bmp, ImageFormat = format }; 
        }
    }
}
