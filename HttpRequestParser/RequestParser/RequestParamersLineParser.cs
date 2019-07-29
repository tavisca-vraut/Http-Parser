using System;
using System.Collections.Generic;

namespace HttpRequestParser
{
    internal class RequestParamersLineParser : IInputLineParser
    {
        public bool TryParse(string line, HttpRequestParser requestParser)
        {
            if (IsRequestParametersLine(line) == false)
                return false;

            Process(line, ref requestParser);
            return true;
        }

        public void Process(string line, ref HttpRequestParser requestParser)
        {
            var KeyValue = line.Split(':');

            if (IsAListOfValues(KeyValue[1]))
            {
                var split2 = KeyValue[1].Split(',');

                for (int i = 0; i < split2.Length; i++)
                {
                    split2[i] = split2[i].Trim();
                }

                requestParser.requestObject.Add(KeyValue[0], split2);
            }
            else
            {
                requestParser.requestObject.Add(KeyValue[0], KeyValue[1].Trim());
            }
        }

        private bool IsAListOfValues(string line)
        {
            return line.Contains(",") == true;
        }

        private bool IsRequestParametersLine(string line)
        {
            return string.IsNullOrWhiteSpace(line) == false &&
                   line.Contains(":") == true;
        }
    }
}