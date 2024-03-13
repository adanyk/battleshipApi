using Battleship.Services;

namespace Battleship
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ISetUpService, SetUpService>();
            services.AddScoped<IModelMappingService, ModelMappingService>();
            services.AddScoped<IGameplayService, GameplayService>();
        }
    }
}
