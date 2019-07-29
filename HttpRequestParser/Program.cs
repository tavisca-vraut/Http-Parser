using System.IO;

namespace HttpRequestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpRequestParser requestObjectGenerator;
            HttpResponseParser responseObjectGenerator;

            string requestFilePath = @"C:\Vighnesh_Docs\VisualStudioProjects\C#\HttpRequestParser\HttpRequestParser\HttpRequest.txt";
            string responseFilePath = @"C:\Vighnesh_Docs\VisualStudioProjects\C#\HttpRequestParser\HttpRequestParser\HttpResponse.txt";

            using (StreamReader file = new StreamReader(requestFilePath))
            {
                requestObjectGenerator = new HttpRequestParser(file);
            }

            using (StreamReader file = new StreamReader(responseFilePath))
            {
                responseObjectGenerator = new HttpResponseParser(file);
            }

            dynamic requestObject = requestObjectGenerator.requestObject;

            System.Console.WriteLine("Request method name: " + requestObject["RequestMethodName"]);
            System.Console.WriteLine("Request URI: " + requestObject["RequestURI"]);
            System.Console.WriteLine("HTTP Version: " + requestObject["HttpVersion"]);
            System.Console.WriteLine("Host: " + requestObject["Host"]);
            System.Console.WriteLine("\nAccept:");
            foreach(var item in requestObject["Accept"])
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("\nAccept-Language");
            System.Console.WriteLine(requestObject["Accept-Language"]);
            System.Console.WriteLine("\nAccept-Encoding");
            foreach (var item in requestObject["Accept-Encoding"])
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();
            System.Console.WriteLine("User-Agent: " + requestObject["User-Agent"]);
            System.Console.WriteLine("\nParameters: BookID => " + requestObject["Parameters"]["bookId"]);
            System.Console.WriteLine("\nParameters: Author => " + requestObject["Parameters"]["author"]);

            System.Console.ReadKey(true);

        }
    }
}
