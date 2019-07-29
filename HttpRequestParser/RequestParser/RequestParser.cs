using System.Collections.Generic;
using System.Dynamic;

namespace HttpRequestParser
{
    internal class HttpRequestParser
    {
        public System.IO.StreamReader File { get; private set; }
        public Dictionary<string, object> requestObject { get; private set; }
        public List<IInputLineParser> parsableLines = new List<IInputLineParser>()
        {
            new UrlParametersLineParser(),
            new RequestParamersLineParser(),
            new StatusLineParser()
        };

        public HttpRequestParser(System.IO.StreamReader file)
        {
            this.File = file;
            ProcessFile();
        }

        private void ProcessFile()
        {
            string line;
            requestObject = new Dictionary<string, object>();

            while ((line = this.File.ReadLine()) != null)
            {
                foreach(var parsableLine in parsableLines)
                {
                    if (parsableLine.TryParse(line, this) == true)
                        break;
                }
            }
        }
    }
}