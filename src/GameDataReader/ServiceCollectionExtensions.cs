using GameDataReader.Battlefield2.Reader;
using Microsoft.Extensions.DependencyInjection;

namespace GameDataReader;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBf2DataReader(this IServiceCollection services)
    {
        services.AddScoped<IBf2DataReader, Bf2DataReader>();
        return services;
    }
}