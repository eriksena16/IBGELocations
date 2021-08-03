using IBGE.Model.IBGEModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocationWebApi.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class CityController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IbgeLocationOptions _ibgeLocationOptions;

        public CityController(IHttpClientFactory httpClientFactory, IOptionsMonitor<IbgeLocationOptions> ibgeLocationOptions)
        {
           this._httpClientFactory = httpClientFactory;
            _ibgeLocationOptions = ibgeLocationOptions.CurrentValue;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<City>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> GetCity(int? ufCode)
        {
            if (ufCode is null)
                return BadRequest(ufCode);

            string requestUri = string.Format(_ibgeLocationOptions.RequestUriCity, ufCode);
            HttpClient httpClient = _httpClientFactory.CreateClient(IbgeLocationOptions.Instance);
            httpClient.BaseAddress = new Uri(_ibgeLocationOptions.BaseAddress);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUri);
            string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();
            List<City> cities = JsonConvert.DeserializeObject<List<City>>(jsonContent);

            return Ok(cities);
        }

    }
}
