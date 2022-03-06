using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Application.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.FileService
{
    public static class DependencyInjection
    {
        public static void AddFileServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileService, FileService>(opt => new FileService(configuration["FilesRelativePath"]));
        }
    }
}
