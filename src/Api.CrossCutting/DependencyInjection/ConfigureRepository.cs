using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }

            
        }
    }
}
