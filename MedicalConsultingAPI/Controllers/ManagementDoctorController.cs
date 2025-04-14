using MedicalConsulting.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultingAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ManagementDoctorController : ControllerBase
    {
        private readonly IManagementScheduleHandler _managementScheduleHandler;
        public ManagementDoctorController(IManagementScheduleHandler managementScheduleHandler)
        {
            _managementScheduleHandler = managementScheduleHandler;
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("get-schedule")]
        public async Task<IActionResult> GetAsync()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

            if (!(string.IsNullOrEmpty(authHeader) && authHeader.Contains("Bearer ")))
                return BadRequest("Token Inválido.");

            var id = int.Parse(HttpContext.User.FindFirst("sub")?.Value);

            var result = _managementScheduleHandler.GetScheduleAsync(id);

            return Ok(result);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("cancel-schedule/id")]
        public async Task<IActionResult> CancelAsync(int id)
        {
            try
            {
                await _managementScheduleHandler.CancelScheduleAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

