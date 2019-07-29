using System;
using System.Collections.Generic;

namespace HttpRequestParser
{
    internal class UrlParametersLineParser : IInputLineParser
    {
        public bool TryParse(string line, HttpRequestParser requestParser)
        {
            if (IsUrlParametersLine(line) == false)
                return false;

            Process(line, ref requestParser);
            return true;
        }
        public void Process(string parameters, ref HttpRequestParser requestParser)
        {
            var allParameters = parameters.Split('&');
            Dictionary<string, object> KeyValues = new Dictionary<string, object>();

            foreach (var parameter in allParameters)
            {
                var keyValue = parameter.Split('=');
                KeyValues.Add(keyValue[0], keyValue[1].Replace('+', ' ').Trim());
            }

            requestParser.requestObject.Add("Parameters", KeyValues);
        }

        private bool IsUrlParametersLine(string line)
        {
            return string.IsNullOrWhiteSpace(line) == false &&
                   line.Contains("&") == true;
        }
    }
}