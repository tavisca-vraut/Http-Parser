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
            var key = KeyValue[0];
            var value = KeyValue[1];

            if (IsAListOfValues(value))
            {
                var values = value.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }

                requestParser.requestObject.Add(key, values);
            }
            else
            {
                requestParser.requestObject.Add(key, value.Trim());
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