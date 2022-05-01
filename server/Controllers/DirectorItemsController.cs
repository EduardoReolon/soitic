#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soitic.Models;

namespace soitic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorItemsController : ControllerBase
    {
        private readonly SoiticContext _context;

        public DirectorItemsController(SoiticContext context)
        {
            _context = context;
        }

        // GET: api/DirectorItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectorItem()
        {
            return await _context.Director.ToListAsync();
        }

        // GET: api/DirectorItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirectorItem(uint id)
        {
            var directorItem = await _context.Director.FindAsync(id);

            if (directorItem == null)
            {
                return NotFound();
            }

            return directorItem;
        }

        // PUT: api/DirectorItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectorItem(uint id, Director directorItem)
        {
            if (id != directorItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(directorItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorItemExists(id))
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

        // POST: api/DirectorItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Director>> PostDirectorItem(Director directorItem)
        {
            _context.Director.Add(directorItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDirectorItem), new { id = directorItem.Id }, directorItem);
        }

        // DELETE: api/DirectorItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectorItem(uint id)
        {
            var directorItem = await _context.Director.FindAsync(id);
            if (directorItem == null)
            {
                return NotFound();
            }

            _context.Director.Remove(directorItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorItemExists(uint id)
        {
            return _context.Director.Any(e => e.Id == id);
        }
    }
}
