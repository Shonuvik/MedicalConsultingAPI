using MedicalConsulting.Application.Dtos;

namespace MedicalConsulting.Domain.Interfaces
{
    public interface IManagementScheduleHandler
    {
        Task<List<ScheduleDto>> GetScheduleAsync(int userId);

        Task CancelScheduleAsync(int id);
    }
}

