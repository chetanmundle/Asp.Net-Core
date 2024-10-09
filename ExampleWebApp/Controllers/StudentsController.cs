using App.Core;
using App.Core.Models;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto model)
        {
            var student = new Student
            {
                StudentId = model.StudentId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                //DateOfBith = model.DateOfBith,
                StudentCourseMappings = new List<StudentCourseMapping>()
            };

            _studentService.AddStudent(student);

            var result = await Task.FromResult(student);

            model.StudentId = result.StudentId;

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {


            var student = _studentService.GetStudent(id);

            var result = await Task.FromResult(student);

            return Ok(student);
        }
    }
}
