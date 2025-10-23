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
    [Route("api/cell")]
    [ApiController]
    public class CellAPIController : ControllerBase
    {
        private readonly Backend_mapContext _context;

        public CellAPIController(Backend_mapContext context)
        {
            _context = context;
        }

        // Will update a List of cells considering their coordenates and their new state
        [HttpPost("update")]
        public async Task<IActionResult> UpdateCells(CellsDTO payload)
        {
            foreach (var cellUpdate in payload.Cells)
            {
                var cell = await _context.Cells
                    .Where(c => c.FloorId == payload.FloorId && c.X == cellUpdate.X && c.Y == cellUpdate.Y)
                    .FirstOrDefaultAsync();

                if (cell != null)
                {
                    cell.IsFilled = cellUpdate.IsFilled;
                }

            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
