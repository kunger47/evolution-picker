using Evolution.Messages;
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
    public class SpeciesController : Controller
    {
        private readonly EvolutionContext _context;

        public SpeciesController(EvolutionContext context)
        {
            _context = context;

            if (_context.TheSpecies.Count() == 0)
            {
                //_context.TheSpecies.Add(new Species { Id = 0 } );
                //_context.SaveChanges();
            }
        }

        // Species
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Species>>> GetTheSpecies()
        {
            return await _context.TheSpecies.ToListAsync();
        }

        [HttpGet("Details")]
        public IEnumerable<SpeciesMessage> GetTheSpeciesDetails()
        {
            var species = _context.TheSpecies.ToList();
            var classifications = _context.Classifications.ToList();
            var timespans = _context.Timescales.ToList();

            return from sp in species
                   join cl in classifications on sp.Classification_Id equals cl.Id
                   join ts in timespans on sp.Timespan_Id equals ts.Id
                   select new SpeciesMessage {
                        Id = sp.Id,
                        SpeciesName = sp.SpeciesName,
                        CommonName = sp.CommonName,
                        Adaption = sp.Adaption,
                        Ancestor_Id = sp.Ancestor_Id,
                        Classification = cl.Name,
                        Info = sp.Info,
                        Pressure_Id = sp.Pressure_Id,
                        Timespan = ts.Name
                    };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Species>> GetSpecies(int id)
        {
            var species = await _context.TheSpecies.FindAsync(id);

            if(species == null)
            {
                return NotFound();
            }

            return species;
        }

        [HttpPost()]
        public async Task<ActionResult<Species>> PostSpecies(Species species)
        {
            _context.TheSpecies.Add(species);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTheSpecies), new { id = species.Id }, species);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecies(int id, Species species)
        {
            if (id != species.Id)
            {
                return BadRequest();
            }

            _context.Entry(species).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            var species = await _context.TheSpecies.FindAsync(id);

            if (species == null)
            {
                return NotFound();
            }

            _context.TheSpecies.Remove(species);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
