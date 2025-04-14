using MedicalConsulting.Domain.Entities;

namespace MedicalConsulting.Application.Interfaces
{
    public interface IManagementScheduleRepository
    {
        Task<List<Schedule>> GetScheduleAsync(int userId);

        Task ScheduleAsync(Schedule entity);

        Task<Schedule> GetScheduleByIdAsync(int Id);
    }
}

