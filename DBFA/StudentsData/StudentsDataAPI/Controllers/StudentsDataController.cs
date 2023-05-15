using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDataAPI.Models;

namespace StudentsDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDataController : ControllerBase
    {
        private readonly StudentsDataContext _context;

        public StudentsDataController(StudentsDataContext context)
        {
            _context = context;
        }

        // GET: api/StudentsData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsDataTable>>> GetStudentsDataTables()
        {
          if (_context.StudentsDataTables == null)
          {
              return NotFound();
          }
            return await _context.StudentsDataTables.ToListAsync();
        }

        // GET: api/StudentsData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsDataTable>> GetStudentsDataTable(int id)
        {
          if (_context.StudentsDataTables == null)
          {
              return NotFound();
          }
            var studentsDataTable = await _context.StudentsDataTables.FindAsync(id);

            if (studentsDataTable == null)
            {
                return NotFound();
            }

            return studentsDataTable;
        }

        // PUT: api/StudentsData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsDataTable(int id, StudentsDataTable studentsDataTable)
        {
            if (id != studentsDataTable.RollNo)
            {
                return BadRequest();
            }

            _context.Entry(studentsDataTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsDataTableExists(id))
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

        // POST: api/StudentsData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDataTable>> PostStudentsDataTable(StudentsDataTable studentsDataTable)
        {
          if (_context.StudentsDataTables == null)
          {
              return Problem("Entity set 'StudentsDataContext.StudentsDataTables'  is null.");
          }
            _context.StudentsDataTables.Add(studentsDataTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsDataTable", new { id = studentsDataTable.RollNo }, studentsDataTable);
        }

        // DELETE: api/StudentsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsDataTable(int id)
        {
            if (_context.StudentsDataTables == null)
            {
                return NotFound();
            }
            var studentsDataTable = await _context.StudentsDataTables.FindAsync(id);
            if (studentsDataTable == null)
            {
                return NotFound();
            }

            _context.StudentsDataTables.Remove(studentsDataTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsDataTableExists(int id)
        {
            return (_context.StudentsDataTables?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
