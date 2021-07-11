using API.Helpers;
using API.Interface;
using API.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApplicatioServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            string Constr = "Data Source=localhost;Initial Catalog=NgDB;User Id=sa;Password=Abc@12345;Connection Lifetime=30;Pooling=True;Min Pool Size=5;Max Pool Size=100;Connection TimeOut=60;";
            services.AddDbContext<Data.DataContext>(option => option.UseLazyLoadingProxies().UseSqlServer(Constr));
            return services; 
        }
    }
}
