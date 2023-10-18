﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;
using MovieTicket.Infra.Data.Repositories;

namespace MovieTicket.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services,
            IConfiguration configuration )
        {
            services.AddDbContext<ApplicationDbContext>( options =>
                options.UseSqlServer( configuration.GetConnectionString( "DefaultConnection" ), b =>
                    b.MigrationsAssembly( typeof( ApplicationDbContext ).Assembly.FullName ) ) );

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}