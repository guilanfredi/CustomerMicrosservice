using CustomerMicrosservice.Database;
using CustomerMicrosservice.Model;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicrosservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET: api/<CustomerController>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var items = await _context.Customers.ToListAsync();

            return Ok(items);
        }

        // GET api/<CustomerController>/5
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var items = await _context.Customers.FirstAsync(x => x.Id == id);

            return Ok(items);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CustomerModel value)
        {
            await _context.Customers.AddAsync(value);
            await _context.SaveChangesAsync();

            return Created("", value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerModel value)
        {
            var result = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = value.Name;
                result.Cpf = value.Cpf;
                result.Email = value.Email;
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Entry(new CustomerModel() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
