using customer.api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer.api.Services
{
    public interface ICommonService
    {
        Task<IEnumerable<ResponseDto>> GetClassifications();
        Task<IEnumerable<ResponseDto>> GetGenders();
        Task<IEnumerable<ResponseDto>> GetRegions();
        Task<IEnumerable<StateDto>> GetStatesFromRegion(int regionId);
        Task<IEnumerable<CityDto>> GetCitiesFromState(int stateId);
    }
}
