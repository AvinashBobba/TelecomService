using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TelecomService.Api;

namespace TelecomService.Tests
{

    public class BaseTest
    {
        private IWebHost _host;
        public BaseTest()
        {
            Initialize();
        }


        public void Initialize()
        {
            if (_host == null)
            {
                _host = new WebHostBuilder()
                             .UseKestrel()
                             .UseContentRoot(Directory.GetCurrentDirectory())
                             .UseStartup<Startup>()
                             .ConfigureAppConfiguration((context, builder) =>
                             {
                                 var env = context.HostingEnvironment;
                                 builder.SetBasePath(env.ContentRootPath)
                                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                                     .AddEnvironmentVariables();
                             })
                             .UseUrls("http://*:0")
                             .Build();
                _host.Start();
            }

        }

        public IServiceProvider ServiceProvider { get { return _host.Services; } }
    }
}
