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
    public class MovieItemsController : ControllerBase
    {
        private readonly SoiticContext _context;

        public MovieItemsController(SoiticContext context)
        {
            _context = context;
        }

        // GET: api/MovieItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieItems()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/MovieItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieItem(uint id)
        {
            var movieItem = await _context.Movie.FindAsync(id);

            if (movieItem == null)
            {
                return NotFound();
            }

            return movieItem;
        }

        // PUT: api/MovieItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieItem(uint id, Movie movieItem)
        {
            if (id != movieItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieItemExists(id))
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

        // POST: api/MovieItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovieItem(Movie movieItem)
        {
            _context.Movie.Add(movieItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovieItem), new { id = movieItem.Id }, movieItem);
        }

        // DELETE: api/MovieItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieItem(uint id)
        {
            var movieItem = await _context.Movie.FindAsync(id);
            if (movieItem == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movieItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieItemExists(uint id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
