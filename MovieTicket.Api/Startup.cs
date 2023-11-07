﻿#region

using Microsoft.OpenApi.Models;

using MovieTicket.Infra.IoC;

using System.Text.Json;

#endregion

namespace MovieTicket.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructure(Configuration);

        services.AddControllers();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Movie Ticket",
                    Description = "Projeto integrado do 3/4° semestre",
                    Version = "v1"
                });
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });

        app.UseRouting();

        app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin());

        app.UseAuthorization();

        app.UseHttpsRedirection();
        app.UseStaticFiles();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}