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

        protected StringBuilder _sb;

        public ScriptArray(TextWriter textWriter)
        {
            _sb = new StringBuilder();
            _writer = textWriter;
            _writer.Write("{");
        }

        public void WriteLine(string line)
        {           
            _sb.AppendLine(line);
        }

        public void WriteLine(string key, string value, RenderArrayMode mode)
        {
            if (mode == RenderArrayMode.Comma)
            {
                _sb.AppendLine(string.Format("{0}: {1}, ", key, value));
            }
            else if (mode == RenderArrayMode.Empty)
            {
                _sb.AppendLine(string.Format("{0}: {1} ", key, value));
            }
        }
        
        public void Write(string key, string value, RenderArrayMode mode)
        {
            if (mode == RenderArrayMode.Comma)
            {
                _sb.Append(string.Format("{0}: {1}, ", key, value));
            }
            else if (mode == RenderArrayMode.Empty)
            {
                _sb.Append(string.Format("{0}: {1} ", key, value));
            }           
        }

        public void Remove(int startIndex, int length)
        {            
            _sb = _sb.Remove(startIndex, length);          
        }

        public int Length
        {
            get { return _sb.Length; }
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        public void Dispose()
        {
            _writer.Write(_sb);
            _writer.WriteLine("}");
        }
    }
}
