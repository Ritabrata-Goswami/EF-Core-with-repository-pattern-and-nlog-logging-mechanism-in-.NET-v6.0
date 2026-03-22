using ILoggerContract;
using LoggerManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelRepoManager;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementSystem.Cls_Extensiton
{
    public static class Cls_Extension
    {
        public static void AddRepoManager(this IServiceCollection Collection)
        {
            Collection.AddScoped<IManager, Cls_Manager>();
        }
        public static void AddLoggerManager(this IServiceCollection Collection)
        {
            Collection.AddSingleton<ILoggerManager, Cls_Logger>();
        }
        public static void AddUICors(this IServiceCollection Collection)
        {
            Collection.AddCors(option =>
            {
                option.AddPolicy("ReactUI", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://localhost:5173").AllowAnyHeader().WithMethods("GET","POST","DELETE","PUT");
                });
            });
        }

        public static string GenerateAuthToken(IConfiguration _config, string FullName, string Id, string Dept)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, FullName),
                new Claim(ClaimTypes.Role, Dept),
                new Claim(ClaimTypes.NameIdentifier, Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:AuthTokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ValidateTime"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static void AddJwtAuthentication(this IServiceCollection Collection, IConfiguration _config)
        {
            Collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:AuthTokenKey"]))
                };
            });
        }

    }
}
