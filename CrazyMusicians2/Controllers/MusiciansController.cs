using Microsoft.AspNetCore.Mvc;
using CrazyMusiciansAPI.Models;
using CrazyMusiciansAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CrazyMusiciansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly MusicianContext _context;

        public MusiciansController(MusicianContext context)
        {
            _context = context;
        }

        // GET: api/Musicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musician>>> GetMusicians()
        {
            return await _context.Musicians.ToListAsync();
        }

        // GET: api/Musicians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musician>> GetMusician(int id)
        {
            var musician = await _context.Musicians.FindAsync(id);

            if (musician == null)
            {
                return NotFound();
            }

            return musician;
        }

        // POST: api/Musicians
        [HttpPost]
        public async Task<ActionResult<Musician>> PostMusician(Musician musician)
        {
            _context.Musicians.Add(musician);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusician), new { id = musician.Id }, musician);
        }

        // PUT: api/Musicians/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusician(int id, Musician musician)
        {
            if (id != musician.Id)
            {
                return BadRequest();
            }

            _context.Entry(musician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicianExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Musicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            var musician = await _context.Musicians.FindAsync(id);
            if (musician == null)
            {
                return NotFound();
            }

            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicianExists(int id)
        {
            return _context.Musicians.Any(e => e.Id == id);
        }

        // GET: api/Musicians/search?name=Ahmet
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Musician>>> SearchMusicians([FromQuery] string name)
        {
            return await _context.Musicians.Where(m => m.Name.Contains(name)).ToListAsync();
        }
    }
}