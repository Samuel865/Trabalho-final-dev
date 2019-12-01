using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController:ControllerBase
    {
        private readonly IPetServices _services;

        public PetController(IPetServices services)
        {
            _services = services;
        }

        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var petList = await _services.Get();
            return Ok(petList);
        }

        [HttpGet("{id}", Name = "GetPet")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _services.GetById(id);
            if( pet == null)
                return NotFound("Não Encontrado");
            else
                return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pet pet)
        {
            await _services.Create(pet);
            return new CreatedAtRouteResult("GetPet", new {id = pet.Id}, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pet pet)
        {
            if( id != pet.Id)
                return BadRequest("Pet não encontrado");
            else
            {
                await _services.Update(pet);
                return new CreatedAtRouteResult("GetPet", new { id = pet.Id}, pet);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] Pet pet)
        {
            await _services.Delete(id);
            return RedirectToAction(nameof(Get));
        }
    }
}