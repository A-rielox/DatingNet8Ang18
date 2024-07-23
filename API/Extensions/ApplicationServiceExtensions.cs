﻿using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddAplicationServices(
                            this IServiceCollection services
                            , IConfiguration config
                            )
    {
        services.AddControllers();

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();

        services.AddScoped<ITokenService, TokenService>();

        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //services.AddScoped<IUserRepository, UserRepository>();
        //services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        //services.AddScoped<IPhotoService, PhotoService>();

        //services.AddScoped<LogUserActivity>();

        //services.AddScoped<ILikesRepository, LikesRepository>();
        //services.AddScoped<IMessageRepository, MessageRepository>();
        //services.AddScoped<IUserRepository, UserRepository>();


        return services;
    }
}
