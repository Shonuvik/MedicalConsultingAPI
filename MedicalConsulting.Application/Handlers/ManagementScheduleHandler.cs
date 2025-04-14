using MedicalConsulting.Application.Dtos;
using MedicalConsulting.Application.Helpers;
using MedicalConsulting.Application.Interfaces;
using MedicalConsulting.Domain.Entities;
using MedicalConsulting.Domain.Enums;
using MedicalConsulting.Domain.Interfaces;

namespace MedicalConsulting.Application.Handlers
{
    public class ManagementScheduleHandler : IManagementScheduleHandler
    {
        private readonly IManagementScheduleRepository _managementScheduleRepository;

        public ManagementScheduleHandler(IManagementScheduleRepository managementScheduleRepository)
        {
            _managementScheduleRepository = managementScheduleRepository;
        }

        public async Task<List<ScheduleDto>> GetScheduleAsync(int userId)
        {
            if (userId == default)
                throw new Exception("Id inválido.");

            var scheduleList = await _managementScheduleRepository.GetScheduleAsync(userId);

            var dto = ParseToDto(scheduleList);

            return dto;
        }

        public async Task CancelScheduleAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            var schedule = await _managementScheduleRepository.GetScheduleByIdAsync(id) ??
                throw new Exception("Voce nao possui agendamentos.");

            await _managementScheduleRepository.ScheduleAsync(new Schedule
            {
                DoctorId = schedule.DoctorId,
                UserId = schedule.UserId,
                Status = StatusType.CANCELADO
            });
        }

        private static List<ScheduleDto> ParseToDto(List<Schedule> entity)
        {
            var schedule = new List<ScheduleDto>();
            foreach (var item in entity)
            {
                schedule.Add(new ScheduleDto
                {
                    Id = item.Id,
                    Date = item.Date,
                    Hour = item.Hour,
                    Status = item.Status.GetDescription()
                });
            }

            return schedule;
        }
    }
}