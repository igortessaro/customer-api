using customer.api.Dtos;
using customer.api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public StateController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("{id}/cities")]
        public Task<IEnumerable<CityDto>> Get(int id) => _commonService.GetCitiesFromState(id);
    }
}
