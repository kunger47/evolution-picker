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
    public class GeologicalController : Controller
    {
        private readonly EvolutionContext _context;

        public GeologicalController(EvolutionContext context)
        {
            _context = context;

            if (_context.GeologicalTimeScales.Count() == 0)
            {
            }
        }

        // Geological Time Scales
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<GeologicalTimeScale>>> GetScales()
        {
            return await _context.GeologicalTimeScales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeologicalTimeScale>> GetScale(int id)
        {
            var scale = await _context.GeologicalTimeScales.FindAsync(id);

            if(scale == null)
            {
                return NotFound();
            }

            return scale;
        }

        [HttpPost()]
        public async Task<ActionResult<GeologicalTimeScale>> PostScale(GeologicalTimeScale scale)
        {
            _context.GeologicalTimeScales.Add(scale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScale), new { id = scale.Id }, scale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutScale(int id, GeologicalTimeScale scale)
        {
            if (id != scale.Id)
            {
                return BadRequest();
            }

            _context.Entry(scale).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScale(int id)
        {
            var scale = await _context.GeologicalTimeScales.FindAsync(id);

            if (scale == null)
            {
                return NotFound();
            }

            _context.GeologicalTimeScales.Remove(scale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Timescales
        [HttpGet("timescales")]
        public async Task<ActionResult<IEnumerable<Timescale>>> GetTimescales()
        {
            return await _context.Timescales.ToListAsync();
        }

        [HttpGet("timescale/{id}")]
        public async Task<ActionResult<Timescale>> GetTimescale(int id)
        {
            var timescale = await _context.Timescales.FindAsync(id);

            if (timescale == null)
            {
                return NotFound();
            }

            return timescale;
        }

        [HttpPost("timescale")]
        public async Task<ActionResult<Timescale>> PostTimescale(Timescale timescale)
        {
            _context.Timescales.Add(timescale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTimescale), new { id = timescale.Id }, timescale);
        }

        [HttpPut("timescale/{id}")]
        public async Task<IActionResult> PutTimescale(int id, Timescale timescale)
        {
            if (id != timescale.Id)
            {
                return BadRequest();
            }

            _context.Entry(timescale).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("timescale/{id}")]
        public async Task<IActionResult> DeleteTimescale(int id)
        {
            var timescale = await _context.Timescales.FindAsync(id);

            if (timescale == null)
            {
                return NotFound();
            }

            _context.Timescales.Remove(timescale);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
