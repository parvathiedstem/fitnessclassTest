using fitnessclass.Models;
using fitnessclass.Models.Dto;
using fitnessclass.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace fitnessclass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FitnessClassController : ControllerBase
    {
        private readonly IFitnessClassService _service;
        private readonly ILogger<FitnessClassController> _logger;

        public FitnessClassController(IFitnessClassService service, ILogger<FitnessClassController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] FitnessClassRequest request)
        {

            try
            {
                var addedClass = await _service.AddClassAsync(request);
                return CreatedAtAction(nameof(GetClassById), new { id = addedClass.Id }, addedClass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new fitness class.");
                return StatusCode(500, "An error occurred while adding the class. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            try
            {
                var fitnessClass = await _service.GetClassByIdAsync(id);

                if (fitnessClass == null)
                    return NotFound();

                return Ok(fitnessClass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the fitness class");
                return StatusCode(500, "An error occurred while retrieving the class");
            }
        }

        [HttpGet("classes")]
        public async Task<ActionResult<IEnumerable<FitnessClass>>> GetAvailableClasses([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string instructor, [FromQuery] string className)
        {
            try
            {
                var classes = await _service.GetAvailableClasses(startDate, endDate, instructor, className);
                return Ok(new { classes });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving available fitness classes.");
                return StatusCode(500, "An error occurred while retrieving classes");
            }
        }
    }
}
