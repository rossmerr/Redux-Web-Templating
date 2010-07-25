using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Redux.Web.Templating
{
    public class OptionsArray : IDisposable
    {
        protected TextWriter _writer;

        public OptionsArray(TextWriter textWriter, string name)
        {
            _writer = textWriter;
            _writer.Write(string.Format("{0} : ", name));
            _writer.Write("[");
        }

        public void WriteLine(string line)
        {
            _writer.WriteLine(line);
        }

        public void Write(string line)
        {
            _writer.Write(line);
        }

        public void Dispose()
        {            
            _writer.WriteLine("]");
        }
    }
}
