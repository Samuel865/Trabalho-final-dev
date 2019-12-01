using Microsoft.AspNetCore.Mvc;
using PetShop.Services;
using PetShop.Models;
using System.Threading.Tasks;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderServices _services;
        public OrderController(IOrderServices services)
        {
            _services = services;
        }

        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var listOrder = await _services.Get();
            return Ok(listOrder);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _services.GetById(id);

            if( order != null)
                return Ok(order);
            else
                return NotFound("Pedido não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível criar o pedido");
            else
                {
                    await _services.Create(order);
                    return new CreatedAtRouteResult("GetOrder", new { id = order.Id }, order);
                }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Order order)
        {
            if( id == order.Id)
            {
                await _services.Update(order);
                return new CreatedAtRouteResult("GetOrder", new { id = order.Id }, order);
            }
            else
                return BadRequest("Não foi possível atuliar o pedido");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);
            return RedirectToAction(nameof(Get));
        }
    }
}