using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public class ScriptArray : IDisposable
    {
        protected TextWriter _writer;

        public ScriptArray(TextWriter textWriter)
        {
            _writer = textWriter;
            _writer.Write("{");
        }

        public void WriteLine(string line)
        {
            _writer.WriteLine(line);
        }

        public void WriteLine(string key, string value, RenderArrayMode mode)
        {
            if (mode == RenderArrayMode.Comma)
            {
            _writer.WriteLine(string.Format("{0}: {1}, ", key, value));
            }
            else if (mode == RenderArrayMode.Empty)
            {
                _writer.WriteLine(string.Format("{0}: {1} ", key, value));
            }
        }
        
        public void Write(string key, string value, RenderArrayMode mode)
        {
            if (mode == RenderArrayMode.Comma)
            {
                _writer.Write(string.Format("{0}: {1}, ", key, value));
            }
            else if (mode == RenderArrayMode.Empty)
            {
                _writer.Write(string.Format("{0}: {1} ", key, value));
            }
        }

        public void Dispose()
        {            
            _writer.WriteLine("}");
        }
    }
}
