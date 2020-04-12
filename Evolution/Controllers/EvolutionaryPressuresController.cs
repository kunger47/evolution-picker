using Evolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvolutionaryPressuresController : Controller
    {
        private readonly EvolutionContext _context;

        public EvolutionaryPressuresController(EvolutionContext context)
        {
            _context = context;

            if (_context.EvolutionaryPressures.Count() == 0)
            {
                //_context.EvolutionaryPressures.Add(new EvolutionaryPressure { });
                //_context.SaveChanges();
            }
        }

        // EvolutionaryPressures
        [HttpGet("pressures")]
        public async Task<ActionResult<IEnumerable<EvolutionaryPressure>>> GetEvolutionaryPressures()
        {
            return await _context.EvolutionaryPressures.ToListAsync();
        }

        [HttpGet("pressures/{id}")]
        public async Task<ActionResult<EvolutionaryPressure>> GetEvolutionaryPressures(int id)
        {
            var pressure = await _context.EvolutionaryPressures.FindAsync(id);

            if (pressure == null)
            {
                return NotFound();
            }

            return pressure;
        }

        [HttpPost("pressures")]
        public async Task<ActionResult<EvolutionaryPressure>> PostEvolutionaryPressure(EvolutionaryPressure pressure)
        {
            _context.EvolutionaryPressures.Add(pressure);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvolutionaryPressures), new { id = pressure.Id }, pressure);
        }

        [HttpPut("pressures/{id}")]
        public async Task<IActionResult> PutEvolutionaryPressure(int id, EvolutionaryPressure pressure)
        {
            if (id != pressure.Id)
            {
                return BadRequest();
            }

            _context.Entry(pressure).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("pressures/{id}")]
        public async Task<IActionResult> DeleteEvolutionaryPressure(int id)
        {
            var pressure = await _context.EvolutionaryPressures.FindAsync(id);

            if (pressure == null)
            {
                return NotFound();
            }

            _context.EvolutionaryPressures.Remove(pressure);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
