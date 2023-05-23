using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDataAPI.DbContexts;
using StudentsDataAPI.Entities;
using StudentsDataAPI.Models;
using StudentsDataAPI.Services;

namespace StudentsDataAPI.Controllers
{
    [Route("api/StudentsData")]
    [ApiController]
    public class StudentsDataController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentsDataContext _context;
        private readonly IMapper _mapper;

        public StudentsDataController(IStudentRepository studentRepository,
            StudentsDataContext context, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// This gets all the students' data from the table
        /// </summary>
        /// <returns>All Students</returns>
        // GET: api/StudentsData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentData>>> GetAllStudentsData() 
        {            
            var students = await _studentRepository.GetStudentsAsync();
            
            return Ok (students);
        }


        /// <summary>
        /// Gets the student by their IDs
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Student Details using IDs</returns>
        // GET: api/StudentsData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentData>> GetStudentDataById(int id)
        {
            #region k
            //if (_context.StudentsDataTable == null)
            //{
            //    return NotFound();
            //}
            //var studentsDataTable = await _context.StudentsDataTable.FindAsync(id);

            //if (studentsDataTable == null)
            //{
            //    return NotFound();
            //}
            #endregion

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var students = await _studentRepository.GetStudentByIdAsync(id);

            if (students == null)
            {
                return NotFound();
            }

            return Ok (students);
        }

        // POST: api/StudentsData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDataTable>> AddStudentData(StudentData studentData)
        {
            #region k
            //if (_context.StudentsDataTable == null)
            //{
            //    return Problem("Entity set 'StudentsDataContext.StudentsDataTables'  is null.");
            //}
            //var students = _mapper.Map<StudentData>(studentsDataTable);
            //_context.StudentsDataTable.Add(students);
            #endregion

            await _studentRepository.AddStudentAsync(studentData);

            var createdNewStudent = _mapper.Map<Models.StudentsDataTable>(studentData);

            return Ok(createdNewStudent);
        }


        // PUT: api/StudentsData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentsData([FromRoute] int id, [FromBody] StudentsDataTable studentsDataTable)
        {
            if (id != studentsDataTable.RollNo)
            {
                return BadRequest();
            }

            var updatedStudent = await _studentRepository.UpdateStudentAsync(id, studentsDataTable);
            if (updatedStudent == null)
            {
                return NotFound();
            }
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


        // PATCH: api/StudentsData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudentsDataTable([FromRoute] int id, [FromBody] JsonPatchDocument studentPatch)
        {            
            var updatedStudent = await _studentRepository.UpdateStudentPatchAysnc(id, studentPatch);
            if (updatedStudent == null)
            {
                return NotFound();
            }

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




        // DELETE: api/StudentsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsDataTable([FromRoute]int id)
        {
            var student = await _studentRepository.DeleteStudentAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool StudentsDataTableExists(int id)
        {
            return (_context.StudentsDataTable?.Any(e => e.RollNo == id)).GetValueOrDefault();
        }
    }
}
