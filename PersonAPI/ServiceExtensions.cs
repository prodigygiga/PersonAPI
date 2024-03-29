﻿using Microsoft.Extensions.DependencyInjection;

namespace PersonDirectory.Presentation.WebApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AnyPolicy", builder => builder
                    .AllowAnyOrigin() // დაშვება ეძლევა მოთხოვნას ნებისმიერი წყაროდან
                    .AllowAnyMethod() // დაშვებას იძლევა HTTP ყველა მეთოდზე
                    .AllowAnyHeader()
                    .WithExposedHeaders("AccessToken", "CurrentPage", "PageSize", "TotalPages", "TotalCount", "HasPreviousPage", "HasNextPage"));
            });
        }
    }
}
