using fitnessclass.Models;
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

        [HttpGet("classes")]
        public async Task<ActionResult<IEnumerable<FitnessClass>>> GetAvailableClasses([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] string instructor, [FromQuery] string className)
        {
            var classes = await _service.GetAvailableClasses(startDate, endDate, instructor, className);
            return Ok(new { classes });
        }
    }
}
