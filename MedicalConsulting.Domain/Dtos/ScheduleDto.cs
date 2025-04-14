using MedicalConsulting.Domain.Enums;

namespace MedicalConsulting.Application.Dtos
{
    public class ScheduleDto
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public string Hour { get; set; }

        public string Status { get; set; }
    }
}

public class EditSchedule
{
    public long Id { get; set; }

    public string ActionType { get; set; }
}

