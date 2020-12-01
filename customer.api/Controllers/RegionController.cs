using customer.api.Dtos;
using customer.api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public RegionController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public Task<IEnumerable<ResponseDto>> GetAll() => _commonService.GetRegions();

        [HttpGet("{id}/states")]
        public Task<IEnumerable<StateDto>> GetStates(int id) => _commonService.GetStatesFromRegion(id);
    }
}
