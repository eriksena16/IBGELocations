using FacadeLocationContract;
using LocationContract;
using LocationModel.DT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationService
{
    public class LocationCityService : ILocationCityService
    {
        private readonly ICityLocationFacade _cityLocationFacade;

        public LocationCityService(ICityLocationFacade cityLocationFacade)
        {
            _cityLocationFacade = cityLocationFacade;
        }

        public async Task<List<CityDTO>> Get(int? ufCode)
        {
            return await _cityLocationFacade.Get(ufCode);
        }
    }
}
