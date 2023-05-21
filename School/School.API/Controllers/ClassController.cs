using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.DTO;
using School.Application.Interfaces;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassApplication _classApplication;

        public ClassController(IClassApplication classApplication)
        {
            _classApplication = classApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _classApplication.List();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _classApplication.Get(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClassDTO classDTO)
        {
            var data = await _classApplication.Create(classDTO);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClassDTO classDTO)
        {
            var data = await _classApplication.Update(classDTO);
            return Ok(data);
        }

        [HttpPut("{id}/deactive")]
        public async Task<IActionResult> Deactive([FromRoute] int id)
        {
            var data = await _classApplication.Deactive(id);
            return Ok(data);
        }

        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents([FromRoute] int id)
        {
            var data = await _classApplication.GetStudents(id);
            return Ok(data);
        }
    }
}
