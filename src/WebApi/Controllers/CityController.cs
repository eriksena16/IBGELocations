using IBGE.Model.IBGEModel;
using LocationContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationWebApi.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class CityController : ControllerBase
    {
        private readonly ILocationCityService _locationCityService;

        public CityController(ILocationCityService locationCityService)
        {
            
            _locationCityService = locationCityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<City>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> GetCity(int? ufCode)
        {
            if (ufCode is null)
                return BadRequest(ufCode);

            var result = await _locationCityService.Get(ufCode);

            return Ok(result);
        }

    }
}
