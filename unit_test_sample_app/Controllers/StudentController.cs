using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unit_test_sample_app.core.BusinessServices.Interfaces;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentBusinessService _studentBusinessService;
        public StudentController(IStudentBusinessService studentBusinessService)
        {
            _studentBusinessService = studentBusinessService;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student _student)
        {
            var student = _studentBusinessService.Create(_student);

            if (student.SudentId > 0)
                return Ok(student);

            return NotFound();
        }
    }
}
