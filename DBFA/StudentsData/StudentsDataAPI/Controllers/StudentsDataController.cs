using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDataAPI.DbContexts;
using StudentsDataAPI.Entities;
using StudentsDataAPI.Models;
using StudentsDataAPI.Profiles;

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
        public async Task<ActionResult<IEnumerable<StudentData>>> GetStudentsDataTables()
        {
          if (_context.StudentsDataTable == null)
          {
              return NotFound();
          }
            return await _context.StudentsDataTable.ToListAsync();
        }

        // GET: api/StudentsData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentData>> GetStudentsDataTable(int id)
        {
          if (_context.StudentsDataTable == null)
          {
              return NotFound();
          }
            var studentsDataTable = await _context.StudentsDataTable.FindAsync(id);

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

        //// PATCH: api/StudentsData/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> PatchStudentsDataTable(int id, StudentData studentsDataTable)
        //{
        //    if (id != studentsDataTable.RollNo)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(studentsDataTable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentsDataTableExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        // POST: api/StudentsData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentData>> PostStudentsDataTable(StudentData studentsDataTable)
        {
          if (_context.StudentsDataTable == null)
          {
              return Problem("Entity set 'StudentsDataContext.StudentsDataTables'  is null.");
          }
            _context.StudentsDataTable.Add(studentsDataTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsDataTable", new { id = studentsDataTable.RollNo }, studentsDataTable);
        }

        // DELETE: api/StudentsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsDataTable(int id)
        {
            if (_context.StudentsDataTable == null)
            {
                return NotFound();
            }
            var studentsDataTable = await _context.StudentsDataTable.FindAsync(id);
            if (studentsDataTable == null)
            {
                return NotFound();
            }

            _context.StudentsDataTable.Remove(studentsDataTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsDataTableExists(int id)
        {
            return (_context.StudentsDataTable?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
