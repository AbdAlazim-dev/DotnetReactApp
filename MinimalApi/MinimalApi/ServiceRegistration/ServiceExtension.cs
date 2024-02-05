using MinimalApi.Services;

namespace MinimalApi.ServiceRegistration;

public static class ServiceExtension
{
    public static void RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IHouseRepository, HouseRerpository>();
        services.AddScoped<IBidRerpository, BidRepository>();
    }
}
