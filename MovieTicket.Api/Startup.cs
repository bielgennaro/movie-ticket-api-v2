using Microsoft.OpenApi.Models;

using MovieTicket.Infra.IoC;

namespace MovieTicket.WebApi
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers();

            services.AddInfrastructure( this.Configuration );

            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new OpenApiInfo { Title = "MovieTicket.WebApi", Version = "v1" } );
            } );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            app.UseSwagger();
            app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "MovieTicket.WebApi v1" ) );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllers();
            } );

            app.UseCors( builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() );

            app.UseDeveloperExceptionPage();
        }
    }
}
