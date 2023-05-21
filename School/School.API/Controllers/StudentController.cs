using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application;
using School.Application.DTO;
using School.Application.Interfaces;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentApplication _studentApp;

        public StudentController(IConfiguration configuration, IStudentApplication studentApp)
        {
            _configuration = configuration;
            _studentApp = studentApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _studentApp.List();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _studentApp.Get(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDTO student)
        {
            var data = await _studentApp.Create(student);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentDTO student)
        {
            var data = await _studentApp.Update(student);
            return Ok(data);
        }

        [HttpPut("{id}/deactive")]
        public async Task<IActionResult> Deactive([FromRoute] int id)
        {
            var data = await _studentApp.Deactive(id);
            return Ok(data);
        }
    }
}