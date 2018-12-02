using ConvertApiDotNet;
using ConvertApiDotNet.Exceptions;
using System;
using System.Collections.Generic;

namespace PDFConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var urls = new Dictionary<string, string>
                {
                    {"http://www.tutorialsteacher.com/core/aspnet-core-introduction" , "introduction"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-environment-setup" , "environment-setup"},
                    {"http://www.tutorialsteacher.com/core/first-aspnet-core-application" , "application"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-application-project-structure" , "project-structure"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-wwwroot" , "wwwroot"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-program" , "program"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-startup" , "startup"},
                    {"http://www.tutorialsteacher.com/core/net-core-command-line-interface" , "command-line-interface"},
                    {"http://www.tutorialsteacher.com/core/dependency-injection-in-aspnet-core" , "dependency-injection"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-middleware" , "middleware"},
                     {"http://www.tutorialsteacher.com/core/aspnet-core-logging" , "logging"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-environment-variable" , "environment-variable"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-exception-handling" , "exception-handling"},
                    {"http://www.tutorialsteacher.com/core/aspnet-core-static-file" , "static-file"},
                    {"http://www.tutorialsteacher.com/core/dotnet-core-application-types" , "application-types"},
                    {"http://www.tutorialsteacher.com/core/code-sharing-between-dotnet-frameworks" , "code-sharing-between-dotnet-frameworks"},
                    {"http://www.tutorialsteacher.com/core/target-multiple-frameworks-in-aspnet-core2" , "target-multiple-frameworks-in-aspnet-core2"},
                };
                ConvertApi convertApi = new ConvertApi("u3wcYNsxd7x8IeXF");

                //foreach (var url in urls)
                //{
                //    Console.WriteLine($" url : {url.Key} filename : {url.Value} ");
                //}

                foreach (var url in urls)
                {
                    var saveFiles = convertApi.ConvertAsync("web", "pdf",
                     new ConvertApiParam("Url", url.Key),
                     new ConvertApiParam("FileName", url.Value))
                     .Result.SaveFiles(@"C:\Users\Akash Karve\Desktop\NETCORE");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
                Console.WriteLine(e.InnerException?.Message);
                var httpStatusCode = (e.InnerException as ConvertApiException)?.StatusCode;
                Console.WriteLine("Status Code: " + httpStatusCode);
                Console.WriteLine("Response: " + (e.InnerException as ConvertApiException)?.Response);
            }
            Console.ReadLine();
        }
    }
}
