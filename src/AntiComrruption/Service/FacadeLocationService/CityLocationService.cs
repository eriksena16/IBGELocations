using FacadeLocationContract;
using IBGE.Model.IBGEModel;
using LocationModel.DT;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FacadeLocationService
{
    public class CityLocationService : ICityLocationFacade
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IbgeLocationOptions _ibgeLocationOptions;

        public CityLocationService(IHttpClientFactory httpClientFactory, IOptionsMonitor<IbgeLocationOptions> ibgeLocationOptions)
        {
            _httpClientFactory = httpClientFactory;
            _ibgeLocationOptions = ibgeLocationOptions.CurrentValue;
        }

        public async Task<List<CityDTO>> Get(int? ufCode)
        {
            //Metodo que vai fazer a chamada da API do IBGE
            string requestUri = string.Format(_ibgeLocationOptions.RequestUriCity, ufCode);
            HttpClient httpClient = _httpClientFactory.CreateClient(IbgeLocationOptions.Instance);
            httpClient.BaseAddress = new Uri(_ibgeLocationOptions.BaseAddress);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUri);
            string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();
            List<City> cities = JsonConvert.DeserializeObject<List<City>>(jsonContent);

            List<CityDTO> cityDTOs = new List<CityDTO>();

            foreach (var city in cities)
            {
                CityDTO cityDTO = new CityDTO();
                cityDTO.Id = city.id;
                cityDTO.Nome = city.nome;
                cityDTO.SiglaEstado = city.microrregiao.mesorregiao.UF.sigla;
                cityDTO.NomeEstado = city.microrregiao.mesorregiao.UF.nome;
                cityDTOs.Add(cityDTO);
            }
            return await Task.FromResult(cityDTOs);
        }
    }
}
