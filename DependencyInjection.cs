using ZooApp_EF.Mapper;
using ZooApp_EF.Repository.Implementation;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF;
public static class DependencyInjection
{
    public static IServiceCollection zooRepository(this IServiceCollection services)
    {
        services.AddScoped<IZooRepository, ZooRepository>();
        services.AddScoped<ICageRepository, CageRepository>();
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddAutoMapper(typeof(ZooMapping));
        return services; 
    }
}
