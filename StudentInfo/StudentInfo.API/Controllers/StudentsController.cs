using Microsoft.AspNetCore.Mvc;
using StudentInfo.API.Models;

namespace StudentInfo.API.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class StudentsController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    //    private readonly ILogger<StudentsController> _logger;

    //    public StudentsController(ILogger<StudentsController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet(Name = "GetStudentInfo")]
    //    public IEnumerable<StudentDto> Get()
    //    {
    //        return Enumerable.Range(1, 5).Select(index => new StudentDto
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = Random.Shared.Next(-20, 55),
    //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}
}