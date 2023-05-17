using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public StudentsDataController(StudentsDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        // POST: api/StudentsData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDataTable>> PostStudentsDataTable(StudentsDataTable studentsDataTable)
        {
            if (_context.StudentsDataTable == null)
            {
                return Problem("Entity set 'StudentsDataContext.StudentsDataTables'  is null.");
            }
            var students = _mapper.Map<StudentData>(studentsDataTable);
            _context.StudentsDataTable.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsDataTable", new { id = studentsDataTable.RollNo }, studentsDataTable);
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

            var students = _mapper.Map<StudentData>(studentsDataTable);
            _context.Entry(students).State = EntityState.Modified;

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
        //public async Task<IActionResult> PatchStudentsDataTable([FromRoute] int id, [FromRoute] StudentData students, [FromBody] JsonPatchDocument jsonPatch)
        //{
        //    if (id != students.RollNo)
        //    {
        //        return BadRequest();
        //    }

        //    var studentPatch = _mapper.Map<StudentsDataTable>(students.RollNo);

        //    jsonPatch.ApplyTo(studentPatch);

        //    _context.Entry(studentPatch------).State = EntityState.Modified;

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




        // DELETE: api/StudentsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsDataTable(int id)
        {
            if (_context.StudentsDataTable == null)
            {
                return NotFound();
            }
            var students = await _context.StudentsDataTable.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            var studentsDataTable = _mapper.Map<StudentData>(students);
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
