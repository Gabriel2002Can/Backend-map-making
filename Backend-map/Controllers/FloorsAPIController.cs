using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_map.Data;
using Backend_map.Models;
using Backend_map.DTO;

namespace Backend_map
{
    [Route("api/floor")]
    [ApiController]
    public class FloorAPIController : ControllerBase
    {
        private readonly Backend_mapContext _context;

        public FloorAPIController(Backend_mapContext context)
        {
            _context = context;
        }

        // GET: api/floor/5
        [HttpGet("{floorId}")]
        public async Task<ActionResult<Floor>> GetFloor(int floorId)
        {
            var floor = await _context.Floors
                .Where(f => f.Id == floorId)
                .Include(f => f.Cells)
                .FirstOrDefaultAsync();

            if (floor == null)
            {
                return NotFound();
            }

            return floor;
        }

        // POST: api/layer
        [HttpPost]
        public async Task<ActionResult<Map>> Create(FloorDTO payload)
        {

            var floor = new Floor
            {
                Name = payload.Name,
                Number = payload.Number,
                DimensionX = payload.DimensionX,
                DimensionY = payload.DimensionY,

                MapId = payload.MapId
            };

            if (floor == null)
            {
                return BadRequest();
            }

            List<Cell> cells = new List<Cell>();

            // Will create each cell for the given dimensions
            for (int i = 0; i < floor.DimensionX; i++)
            {
                for (int j = 0; j < floor.DimensionY; j++)
                {
                    var cell = new Cell
                    {
                        X = i,
                        Y = j,
                        IsFilled = false,
                        FloorId = floor.Id
                    };
                    cells.Add(cell);
                }
            }

            floor.Cells = cells;

            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFloor), new { id = floor.Id }, floor);
        }

        // DELETE: api/floor/5
        [HttpDelete("{floorId}")]
        public async Task<IActionResult> DeleteFloor(int floorId)
        {
            var floor = await _context.Floors.FindAsync(floorId);
            if (floor == null)
            {
                return NotFound();
            }
            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
