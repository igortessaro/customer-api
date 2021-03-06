﻿using customer.api.Dtos;
using customer.api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public GenderController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public Task<IEnumerable<ResponseDto>> GetAll() => _commonService.GetGenders();
    }
}
