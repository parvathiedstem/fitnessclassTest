using fitnessclass.Models;
using fitnessclass.Models.Dto;
using fitnessclass.Services;
using Microsoft.AspNetCore.Mvc;

namespace fitnessclass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FitnessClassController : ControllerBase
    {
        private readonly IFitnessClassService _service;

        public FitnessClassController(IFitnessClassService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] FitnessClassRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedClass = await _service.AddClassAsync(request);

            return CreatedAtAction(nameof(GetClassById), new { id = addedClass.Id }, addedClass);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var fitnessClass = await _service.GetClassByIdAsync(id);
            
            if (fitnessClass == null)
                return NotFound();
            
            return Ok(fitnessClass);
        }

        [HttpGet("classes")]
        public async Task<ActionResult<IEnumerable<FitnessClass>>> GetAvailableClasses([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string instructor, [FromQuery] string className)
        {
            var classes = await _service.GetAvailableClasses(startDate, endDate, instructor, className);
            return Ok(new { classes });
        }
    }
}
