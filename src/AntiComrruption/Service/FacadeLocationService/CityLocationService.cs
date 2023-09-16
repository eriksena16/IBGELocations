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

        public async Task<List<CityDTO>> Get(string uf)
        {
            int ufCode = GetCodeUf(uf.ToUpper());
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

        private int GetCodeUf(string uf)
        {
            return uf switch
            {
                "RO" => 11,
                "AC" => 12,
                "AM" => 13,
                "RR" => 14,
                "PA" => 15,
                "AP" => 16,
                "TO" => 17,
                "MA" => 21,
                "PI" => 22,
                "CE" => 23,
                "RN" => 24,
                "PB" => 25,
                "PE" => 26,
                "AL" => 27,
                "SE" => 28,
                "BA" => 29,
                "MG" => 31,
                "ES" => 32,
                "RJ" => 33,
                "SP" => 35,
                "PR" => 41,
                "SC" => 42,
                "RS" => 43,
                "MS" => 50,
                "MT" => 51,
                "GO" => 52,
                "DF" => 53,
                _ => throw new Exception("UF não encontrado")
            };


        }
    }
}
