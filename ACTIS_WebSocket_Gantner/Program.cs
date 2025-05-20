using ACTIS_WebSocket_Gantner;
using Microsoft.AspNetCore;

namespace ACTIS_WebSocket_Gantner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseUrls("http://*:5000").UseStartup<Startup>();
    }
}