using LocationModel.DT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationContract
{
    public interface ILocationCityService
    {
        Task<List<CityDTO>> Get(int? ufCode);
    }
}
