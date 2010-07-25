using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.Templating
{
    public class TemplateScript : IDisposable
    {
        protected ViewContext _viewContext;
        protected TextWriter _writer;
        protected FormContext _originalFormContext;

        public TemplateScript(ViewContext viewContext, TextWriter write, FormContext originalFormContextr) 
        {
            _viewContext = viewContext;
            _originalFormContext = originalFormContextr;

            Initialize(write);

            _writer.Write(ScriptTag.Rendar(TagRenderMode.StartTag));
        }

        public TemplateScript(TextWriter textWriter)
        {
            Initialize(textWriter);
        }

        private void Initialize(TextWriter textWriter)
        {
            _writer = textWriter;            
        }

        public void Dispose()
        {
            _writer.Write(ScriptTag.Rendar(TagRenderMode.EndTag));

            if (_viewContext != null)
            {
                _viewContext.OutputClientValidation();
                _viewContext.FormContext = _originalFormContext;
            }

            GC.SuppressFinalize(this);
        }

        public void WriteLine(string line)
        {
            _writer.WriteLine(line);            
        }
    }
}
