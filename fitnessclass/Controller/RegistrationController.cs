using fitnessclass.Models.Dto;
using fitnessclass.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelRegistration(int id, [FromQuery] string reason)
        {
            try
            {
                await _service.CancelRegistration(id, reason);
                return Ok(new { message = "Registration canceled successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
