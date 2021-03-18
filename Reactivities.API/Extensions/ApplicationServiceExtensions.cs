using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Reactivities.Reactivities.Application.Activities;
using Reactivities.Reactivities.Application.Core;
using Reactivities.Reactivities.Persistence;

namespace Reactivities.Reactivities.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Reactivities.API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(optionsAction =>
            {
                optionsAction.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection")
                    );
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}