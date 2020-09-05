using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;

namespace TelecomService.Api.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        private const string API_VERSION = "v1";

        private const string API_DOCUMENTATION_NAME = "Telecommunication Service API";

        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers();

            serviceCollection.AddSwaggerGen(setupAction: x =>
            {
                x.SwaggerDoc(name: API_VERSION,
                info: new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = API_DOCUMENTATION_NAME,
                    Version = API_VERSION
                });

                x.ExampleFilters();

                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(path1: AppContext.BaseDirectory,
                    path2: xmlfile);
                
                x.IncludeXmlComments(xmlPath);

            });

            serviceCollection.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}
