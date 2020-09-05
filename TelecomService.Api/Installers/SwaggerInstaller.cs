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
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers();

            serviceCollection.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Telecommunication Service API",
                    Version = "v1"
                });

                x.ExampleFilters();

                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                x.IncludeXmlComments(xmlPath);

            });

            serviceCollection.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}
