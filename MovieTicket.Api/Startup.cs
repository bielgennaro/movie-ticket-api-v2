#region

using System.Text.Json;

using Microsoft.OpenApi.Models;

using MovieTicket.Infra.IoC;

#endregion

namespace MovieTicket.WebApi;

public class Startup
{
    public Startup( IConfiguration configuration )
    {
        this.Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices( IServiceCollection services )
    {
        services.AddControllers()
            .AddJsonOptions( options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            } );

        services.AddSwaggerGen( c =>
        {
            c.SwaggerDoc( "v1",
                new OpenApiInfo
                {
                    Title = "Movie Ticket",
                    Description = "Projeto integrado do 3/4° semestre",
                    Version = "v1"
                } );
            c.ResolveConflictingActions( apiDescriptions => apiDescriptions.First() );
        } );

        services.AddDataProtection();
    }

    public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
    {
        app.UseSwagger();
        app.UseSwaggerUI( c => { c.SwaggerEndpoint( "/swagger/v1/swagger.json", "v1" ); } );

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseStaticFiles();


        app.UseEndpoints( endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}" );
        } );
    }
}