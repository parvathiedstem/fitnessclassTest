using fitnessclass.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fitnessclass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;

        public RegistrationController(IRegistrationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            try
            {
                await _service.RegisterForClass(request.ClassId, request.MemberName, request.MemberEmail);
                return Ok(new { message = "Registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }

    public class RegistrationRequest
    {
        public int ClassId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
    }
}
