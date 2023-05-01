using appRestAPI.Contracts.Orders;
using appRestAPI.Services.FileService;
using appRestAPI.Services.Verificators;

namespace appRestAPI.Services;

public static class MediatorCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<FileServiceConfig>(config.GetSection("Orders"));
        services.AddScoped<IFileService, FileService.FileService>();
        services.AddScoped<IArgumentVerificator<GetOrdersQuery>, OrdersArgumentVerificator>();
        services.AddAutoMapper(typeof(Program));

        return services;
    }
}