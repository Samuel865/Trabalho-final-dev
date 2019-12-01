using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _services.Get();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _services.GetById(id);
            if( user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _services.Create(user);
            return new CreatedAtRouteResult("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User user, int id)
        {
            if( id == user.Id)
            {
                await _services.Update(user);
                return new CreatedAtRouteResult("GetUser", new { id = user.Id }, user);
            }
            else
                return BadRequest("Usuário não encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);
            return RedirectToAction(nameof(Get));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPet([FromBody] Pet pet)
        {
            var user = await _services.GetById(pet.UserId);
            user.AddPet(pet);
            return new CreatedAtRouteResult("GetUser", new { id = user.Id}, user);
        }
        [HttpPost("remove")]
        public async Task<IActionResult> RemovePet([FromBody] Pet pet)
        {
            var user = await _services.GetById(pet.UserId);
            user.RemovePet(pet);
            return new CreatedAtRouteResult("GetUser", new { id = user.Id}, user);
        }
    }
}