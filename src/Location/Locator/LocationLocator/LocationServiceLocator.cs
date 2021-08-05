using FacadeLocationContract;
using FacadeLocationService;
using LocationContract;
using LocationService;
using Microsoft.Extensions.DependencyInjection;

namespace LocationLocator
{
    public static class LocationServiceLocator
    {
        public static void ConfigureLocationService(this IServiceCollection services)
        {
            services.AddScoped<ILocationCityService, LocationCityService>();
            services.AddScoped<ICityLocationFacade, CityLocationService>();

        }
    }
}
