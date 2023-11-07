#region

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MovieTicket.Application.Interfaces;
using MovieTicket.Application.Mappings;
using MovieTicket.Application.Services;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;
using MovieTicket.Infra.Data.Repositories;

#endregion

namespace MovieTicket.Infra.IoC;

public static class DependencyInjectionApi
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b =>
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //services.AddIdentity<ApplicationUser, IdentityRole>()
        //.AddEntityFrameworkStores<ApplicationDbContext>()
        //.AddDefaultTokenProviders();

#if DEBUG
        services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DevConnection"), b =>
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
#endif

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IUserService, UserService>();

        //services.AddScoped(IAuthenticate, AuthenticateService);

        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        services.AddAutoMapper(typeof(DtoToCommandMappingProfile));

        System.Reflection.Assembly myHandlers = AppDomain.CurrentDomain.Load("MovieTicket.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

        return services;
    }
}