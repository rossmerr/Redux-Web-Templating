using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.Templating
{
    public class TemplateController : Controller
    {
        private static Stream GetEmbeddedFile(string assemblyName, string fileName)
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.Load(assemblyName);
                Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);

                if (str == null)
                    throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
                return str;
            }
            catch (Exception e)
            {
                throw new Exception(assemblyName + ": " + e.Message);
            }
        }

        private static string StreamToString(Stream stream)
        {
            var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();

            reader.Dispose();
            stream.Dispose();

            return contents;
        }
    }
}
