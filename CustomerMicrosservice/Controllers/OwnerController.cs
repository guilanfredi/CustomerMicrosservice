using OwnerMicrosservice.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwnerMicrosservice.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OwnerMicrosservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILogger<OwnerController> _logger;
        // This should be injected - This is only an example
        private readonly OwnerRepository _ownerRepository;

        public OwnerController(ILogger<OwnerController> logger, OwnerRepository repository)
        {
            _logger = logger;
            _ownerRepository = repository;
        }


        // GET: api/<CustomerController>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Owner>>> GetAllOwnersAsync()
        {
            return Ok(await _ownerRepository.GetAllAsync());
        }

        // GET api/<CustomerController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwnerAsync(string id)
        {
            var user = new Owner()
            {
                Id = id
            };

            return Ok(await _ownerRepository.GetAsync(user));
        }

        // POST api/<CustomerController>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Owner>> AddUserAsync(Owner user)
        {
            return Ok(await _ownerRepository.AddAsync(user));
        }


        // PUT api/<CustomerController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Owner>> UpdateUserAsync(string id, Owner user)
        {
            if (id != user.Id)
            {
                return BadRequest("Id must match.");
            }

            return Ok(await _ownerRepository.UpdateAsync(user));
        }

        // DELETE api/<CustomerController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(string id, Owner user)
        {
            if (id != user.Id)
            {
                return BadRequest("Id must match.");
            }

            await _ownerRepository.DeleteAsync(user);

            return Ok();
        }

    }
}
