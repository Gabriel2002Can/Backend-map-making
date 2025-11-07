using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_map.Data;
using Backend_map.Models;

namespace Backend_map.Controllers
{
    [Route("api/map")]
    [ApiController]
    public class MapsAPIController : ControllerBase
    {
        private readonly Backend_mapContext _context;

        public MapsAPIController(Backend_mapContext context)
        {
            _context = context;
        }

        // GET: api/map
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Map>>> GetMap()
        {
            return await _context.Maps
                .Include(x => x.Floors)
                .ToListAsync();
        }

        // GET: api/map/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Map>> GetMap(int id)
        {
            var map = await _context.Maps
                .Include(x => x.Floors)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (map == null)
            {
                return NotFound();
            }

            return map;
        }

        // POST: api/map
        [HttpPost]
        public async Task<ActionResult<Map>> Create(string name)
        {
            var map = new Map
            {
                Name = name,
                Floors = new List<Floor>()
            };

            if (map == null)
            {
                return BadRequest();
            }

            _context.Maps.Add(map);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMap), new { id = map.Id }, map);
        }

        // PUT: api/map/UpdateMap/5
        [HttpPut]
        [Route("updateMap/{id}")]
        public async Task<IActionResult> EditMap(int id, [FromBody] string newName)
        {
            var map = await _context.Maps.FindAsync(id);

            if (map == null)
            {
                return NotFound();
            }

            map.Name = newName;

            _context.Entry(map).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Maps.Any(e => e.Id == id))
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

        // DELETE: api/map/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMap(int id)
        {
            var map = await _context.Maps.FindAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            _context.Maps.Remove(map);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
