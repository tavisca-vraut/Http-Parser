namespace HttpRequestParser
{
    internal class HttpResponseParser
    {
        public System.IO.StreamReader File { get; private set; }
        public HttpResponseParser(System.IO.StreamReader file)
        {
            this.File = file;
        }
    }
}