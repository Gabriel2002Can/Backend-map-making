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

namespace Backend_map.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomsAPIController : ControllerBase
    {
        private readonly Backend_mapContext _context;

        public RoomsAPIController(Backend_mapContext context)
        {
            _context = context;
        }

        // GET: api/RoomsAPI
        [HttpGet("{floorId}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(int floorId)
        {
            return await _context.Rooms
                .Where(r => r.FloorId == floorId)
                .ToListAsync();
        }

        // POST: api/RoomsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(RoomDTO payload)
        {
            
            var room = new Room
            {
                Name = payload.Name ?? string.Empty,
                Color = payload.Color ?? string.Empty,
                Description = payload.Description ?? string.Empty,
            };

            _context.Rooms.Add(room);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // PUT: api/RoomsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom(int id, RoomDTO payload)
        {

            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return BadRequest();
            }


            if(payload.Name != null)
            {
                room.Name = payload.Name;
            }

            if(payload.Color != null)
            {
                room.Color = payload.Color;
            }

            if(payload.Description != null)
            {
                room.Description = payload.Description;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/RoomsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
