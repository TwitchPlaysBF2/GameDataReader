using GameDataReader.Battlefield1942.Reader;
using GameDataReader.Battlefield2.Reader;
using GameDataReader.Battlefield2142.Reader;
using GameDataReader.BattlefieldVietnam.Reader;
using Microsoft.Extensions.DependencyInjection;

namespace GameDataReader;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBfVietnamDataReader(this IServiceCollection services)
    {
        services.AddScoped<IBfVietnamDataReader, BfVietnamDataReader>();
        return services;
    }

    public static IServiceCollection AddBf1942DataReader(this IServiceCollection services)
    {
        services.AddScoped<IBf1942DataReader, Bf1942DataReader>();
        return services;
    }

    public static IServiceCollection AddBf2DataReader(this IServiceCollection services)
    {
        services.AddScoped<IBf2DataReader, Bf2DataReader>();
        return services;
    }

    public static IServiceCollection AddBf2142DataReader(this IServiceCollection services)
    {
        services.AddScoped<IBf2142DataReader, Bf2142DataReader>();
        return services;
    }
}