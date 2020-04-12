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
    public class ClassificationsController : Controller
    {
        private readonly EvolutionContext _context;

        public ClassificationsController(EvolutionContext context)
        {
            _context = context;

            if (_context.ClassificationsOfLife.Count() == 0)
            {
                _context.ClassificationsOfLife.Add(new ClassificationOfLife { LevelName = "Domain", Info = "Top Level" });
                _context.SaveChanges();
            }

            if (_context.Classifications.Count() == 0)
            {
                _context.Classifications.Add(new Classification  { Id = 0 });
                _context.SaveChanges();
            }
        }

        // Classifications of Life
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ClassificationOfLife>>> GetClassificationsOfLife()
        {
            return await _context.ClassificationsOfLife.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassificationOfLife>> GetClassificationOfLife(int id)
        {
            var classification = await _context.ClassificationsOfLife.FindAsync(id);

            if(classification == null)
            {
                return NotFound();
            }

            return classification;
        }

        [HttpPost()]
        public async Task<ActionResult<ClassificationOfLife>> PostClassificationOfLife(ClassificationOfLife classification)
        {
            _context.ClassificationsOfLife.Add(classification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassificationsOfLife), new { id = classification.Id }, classification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassification(int id, ClassificationOfLife classification)
        {
            if (id != classification.Id)
            {
                return BadRequest();
            }

            _context.Entry(classification).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassificationOfLife(int id)
        {
            var classification = await _context.ClassificationsOfLife.FindAsync(id);

            if (classification == null)
            {
                return NotFound();
            }

            _context.ClassificationsOfLife.Remove(classification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Classifications
        [HttpGet("classifications")]
        public async Task<ActionResult<IEnumerable<Classification>>> GetClassifications()
        {
            return await _context.Classifications.ToListAsync();
        }

        [HttpGet("classifications/{id}")]
        public async Task<ActionResult<Classification>> GetClassifications(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if (classification == null)
            {
                return NotFound();
            }

            return classification;
        }

        [HttpPost("classifications")]
        public async Task<ActionResult<Classification>> PostClassification(Classification classification)
        {
            _context.Classifications.Add(classification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassifications), new { id = classification.Id }, classification);
        }

        [HttpPut("classifications/{id}")]
        public async Task<IActionResult> PutClassification(int id, Classification classification)
        {
            if (id != classification.Id)
            {
                return BadRequest();
            }

            _context.Entry(classification).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("classifications/{id}")]
        public async Task<IActionResult> DeleteClassification(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if (classification == null)
            {
                return NotFound();
            }

            _context.Classifications.Remove(classification);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
