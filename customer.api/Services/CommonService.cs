using customer.api.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace customer.api.Services
{
    public class CommonService : ICommonService
    {
        private readonly HttpClient _httpClient;
        private readonly string _regionEndPoint = "Region/";
        private readonly string _stateEndPoint = "State/";
        private readonly string _genderEndPoint = "Gender/";
        private readonly string _classificationEndPoint = "Classification/";

        public CommonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<ResponseDto>> GetClassifications()
        {
            return this.GetAll<ResponseDto>(_classificationEndPoint);
        }

        public Task<IEnumerable<ResponseDto>> GetGenders()
        {
            return this.GetAll<ResponseDto>(_genderEndPoint);
        }

        public Task<IEnumerable<ResponseDto>> GetRegions()
        {
            return this.GetAll<ResponseDto>(_regionEndPoint);
        }

        public Task<IEnumerable<StateDto>> GetStatesFromRegion(int regionId)
        {
            return this.GetAll<StateDto>($"{_regionEndPoint}{regionId}/states");
        }

        public Task<IEnumerable<CityDto>> GetCitiesFromState(int stateId)
        {
            return this.GetAll<CityDto>($"{_stateEndPoint}{stateId}/cities");
        }

        private async Task<IEnumerable<TResponse>> GetAll<TResponse>(string endpoint)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(endpoint);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return new List<TResponse>();
            }

            var response = await responseMessage.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TResponse>>(response);

            return result;
        }
    }
}
