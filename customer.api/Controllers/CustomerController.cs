using customer.api.Commands;
using customer.api.Entities;
using customer.api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace customer.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DefaultDbContext _defaultDbContext;

        public CustomerController(DefaultDbContext defaultDbContext)
        {
            _defaultDbContext = defaultDbContext;
        }

        [HttpGet]
        public IAsyncEnumerable<Customer> Get() => _defaultDbContext.Customers.OrderBy(x => x.FirstName).AsAsyncEnumerable();


        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            return _defaultDbContext.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Customer>> CreateAsync([FromBody] CreateCustomerCommand customer)
        {
            var entity = customer.Build();

            await _defaultDbContext.AddAsync(entity);
            await _defaultDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> Update(int id, [FromBody] UpdateCustomerCommand customer)
        {
            var entity = _defaultDbContext.Customers.FirstOrDefault(x => x.Id == id);

            if (entity is null)
            {
                return NotFound();
            }

            entity.Update(customer.FirstName, customer.LastName, customer.Phone, customer.LastPurchase, customer.GenderId, customer.ClassificationId);
            entity.UpdateRegion(customer.RegionId,customer.StateId, customer. CityId);
            _defaultDbContext.Update(entity);
            _defaultDbContext.SaveChanges();

            return Ok(entity);
        }
    }
}
