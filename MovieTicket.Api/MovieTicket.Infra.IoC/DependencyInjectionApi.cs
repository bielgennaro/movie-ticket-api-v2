#region

using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

using MovieTicket.Application.Interfaces;
using MovieTicket.Application.Mappings;
using MovieTicket.Application.Services;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;
using MovieTicket.Infra.Data.Repositories;
using MovieTicket.WebApi.MovieTicket.Infra.Data.Repositories;

#endregion

namespace MovieTicket.Infra.IoC
{
    public static class DependencyInjectionApi
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ProdConnection"), b =>
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}