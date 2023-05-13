using Microsoft.AspNetCore.Mvc;
using StudentInfo.API.Models;
using System.Security.Cryptography.X509Certificates;

namespace StudentInfo.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudentInfo()
        {

            return Ok(StudentsDataStore.Current.Students);
        }

        //[HttpGet("{RollNo}")]

        //public IEnumerable<StudentDto> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new StudentDto
        //    {
        //        Name = 
        //    })
        //    .ToArray();
        //}
    }
}