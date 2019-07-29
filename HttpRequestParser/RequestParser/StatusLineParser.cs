using System;
using System.Collections.Generic;

namespace HttpRequestParser
{
    internal class StatusLineParser : IInputLineParser
    {
        public bool TryParse(string line, HttpRequestParser requestParser)
        {
            if (IsStatusLine(line) == false)
                return false;

            Process(line, ref requestParser);
            return true;
        }

        public void Process(string line, ref HttpRequestParser requestParser)
        {
            var values = line.Split(' ');

            requestParser.requestObject.Add("RequestMethodName", values[0]);
            requestParser.requestObject.Add("RequestURI", values[1]);
            requestParser.requestObject.Add("HttpVersion", values[2]);
        }

        private bool IsStatusLine(string line)
        {
            return string.IsNullOrWhiteSpace(line) == false &&
                   line.Contains(":") == false;
        }
    }
}