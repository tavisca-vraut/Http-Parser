using System.Collections.Generic;

namespace HttpRequestParser
{
    internal interface IInputLineParser
    {
        bool TryParse(string line, HttpRequestParser requestParser);
        void Process(string line, ref HttpRequestParser requestParser);
    }
}