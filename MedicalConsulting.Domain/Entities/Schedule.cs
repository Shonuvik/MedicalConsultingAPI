using MedicalConsulting.Domain.Enums;

namespace MedicalConsulting.Domain.Entities
{
    public class Schedule
    {
        public long Id { get; set; }

        public string UserId { get; set; }

        public string DoctorId { get; set; }

        public DateTime Date { get; set; }

        public string UserName { get; set; }

        public string Hour { get; set; }

        public StatusType Status { get; set; }
    }
}

