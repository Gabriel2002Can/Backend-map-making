using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_map.Data;
using Backend_map.Models;

namespace Backend_map
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

        // GET: api/map/5/floor/5
        [HttpGet("{mapId}/floor/{floorNumber}")]
        public async Task<ActionResult<Floor>> GetFloor(int mapId, int floorNumber)
        {
            var floor = await _context.Floors
                .Where(f => f.MapId == mapId && f.Number == floorNumber)
                .Include(f => f.Cells)
                .FirstOrDefaultAsync();

            if (floor == null)
            {
                return NotFound();
            }

            return floor;
        }

    }
}
