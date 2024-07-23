using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(
                                            this IServiceCollection services
                                            , IConfiguration config
                                        )
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenKey = config["TokenKey"] ?? throw new Exception("TokenKey not found.");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, // esta y la sig es p'q revise q este firmado y revise la firma
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });


        //
        // CONFIFURACION  de las policies p' el acceso
        //services.AddAuthorization(opt =>
        //{
        //    opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
        //    opt.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
        //});

        return services;
    }
}
