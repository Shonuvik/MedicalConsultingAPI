using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultingAPI.Controllers
{
    [Authorize(Roles = "Doctor")]
	[ApiController]
	[Route("[controller]")]
	public class ManagementDoctorController
	{
		public ManagementDoctorController()
		{
		}
	}
}

