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

        // POST: api/floor
        [HttpPost]
        public async Task<ActionResult<Map>> Create([FromBody] CreateFloorDTO payload)
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
                        // associate via navigation after creating the floor
                    };
                    cells.Add(cell);
                }
            }

            floor.Cells = cells;

            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFloor), new { floorId = floor.Id }, floor);
        }

        // PUT: api/floor/5
        [HttpPut("{floorId}")]
        public async Task<IActionResult> EditFloor(int floorId, [FromBody] UpdateFloorDTO payload)
        {
            if (payload == null) return BadRequest();

            if (payload.DimensionX <= 0 || payload.DimensionY <= 0) return BadRequest("The floor dimensions should be positive values");

            var floor = await _context.Floors.FindAsync(floorId);

            if (floor == null)
            {
                return NotFound();
            }

            if (payload.Name != null) floor.Name = payload.Name;
            if (payload.Number != null) floor.Number = (int)payload.Number;

            if (payload.DimensionX != null && payload.DimensionY != null)
            {
                RecalculateCells(floor, (int)payload.DimensionX, (int)payload.DimensionY);
                floor.DimensionX = (int)payload.DimensionX;
                floor.DimensionY = (int)payload.DimensionY;
            }
            else if (payload.DimensionX != null)
            {
                RecalculateCells(floor, (int)payload.DimensionX, floor.DimensionY);
                floor.DimensionX = (int)payload.DimensionX;
            }
            else if (payload.DimensionY != null)
            {
                RecalculateCells(floor, floor.DimensionX, (int)payload.DimensionY);
                floor.DimensionY = (int)payload.DimensionY;
            }

            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        // Help method to edit floor cells
        private void RecalculateCells(Floor floor, int newX, int newY)
        {
            if (floor == null) return;

            var cellMap = floor.Cells.ToDictionary(c => (c.X, c.Y));
            var newCells = new List<Cell>();

            // Create new cells for new dimensions
            for (int x = 0; x < newX; x++)
            {
                for (int y = 0; y < newY; y++)
                {
                    if (!cellMap.ContainsKey((x, y)))
                    {
                        newCells.Add(new Cell
                        {
                            X = x,
                            Y = y,
                            IsFilled = false,
                        });
                    }
                }
            }

            // Remover cells out of new bounds
            var toRemove = floor.Cells
                .Where(c => c.X >= newX || c.Y >= newY)
                .ToList();

            if (toRemove.Any())
                _context.Cells.RemoveRange(toRemove);

            if (newCells.Any())
                _context.Cells.AddRange(newCells);
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
