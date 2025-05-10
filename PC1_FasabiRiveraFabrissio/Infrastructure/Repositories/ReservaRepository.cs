using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservasController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetAll()
        {
            var reservas = await _reservaRepository.GetAll();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetById(int id)
        {
            var reserva = await _reservaRepository.GetById(id);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            await _reservaRepository.Add(reserva);
            return CreatedAtAction(nameof(GetById), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Reserva reserva)
        {
            if (id != reserva.Id)
                return BadRequest("El ID de la URL no coincide con el del cuerpo");

            await _reservaRepository.Update(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reservaRepository.Delete(id);
            return NoContent();
        }
    }
}

