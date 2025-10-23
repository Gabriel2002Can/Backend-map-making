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

        [HttpPost]
        public async Task<ActionResult<Cell>> Create(CellsDTO payload)
        {
            List<Cell> cells = new List<Cell>(); 

            foreach (var newCell in payload.Cells)
            {
                var cell = new Cell
                {
                    X = newCell.X,
                    Y = newCell.Y,
                    IsFilled = newCell.IsFilled,
                    FloorId = payload.FloorId
                };

                if (cell != null)
                {
                    cells.Add(cell);
                }
            }

            _context.Cells.AddRange(cells);
            await _context.SaveChangesAsync();

            var cellToReturn = cells.FirstOrDefault();
            return CreatedAtAction("GetCell", new { cellId = cellToReturn?.Id }, cellToReturn);
        }

    }
}
