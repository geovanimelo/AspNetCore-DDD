using Microsoft.OpenApi.Models;

namespace DDD.Services.Api.StartupExtensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASPNET Core DDD Project",
                    Description = string.Empty,
                    Contact = new OpenApiContact { Name = "Geovani Melo", Email = "sales@allianceinformatica.com", Url = new Uri("https://allianceinformatica.com/") },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://github.com/geovanimelo/AspNetCore-DDD/blob/master/LICENSE") },
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "ASPNET Core DDD Project",
                    Description = string.Empty,
                    Contact = new OpenApiContact { Name = "Geovani Melo", Email = "sales@allianceinformatica.com", Url = new Uri("https://allianceinformatica.com/") },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://github.com/geovanimelo/AspNetCore-DDD/blob/master/LICENSE") },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()

                        // new string[] { }
                    },
                });

                // Add custom header request
                // c.OperationFilter<AddRequiredHeaderParameter>();
            });
        }

        return services;
    }

    public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASPNET Core DDD Project API v1.0");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "ASPNET Core DDD Project API v2.0");

                // Show V1 first in Swagger
                // foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                // {
                //     c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                //         description.GroupName.ToUpperInvariant());
                // }

                // Show V2 first in Swagger
                // foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                // {
                //     options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                //         description.GroupName.ToUpperInvariant());
                // }
            });
        }

        return app;
    }
}
