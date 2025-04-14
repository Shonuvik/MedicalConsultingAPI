using System.ComponentModel;

namespace MedicalConsulting.Domain.Enums
{
    public enum StatusType
	{
		[Description("Agendamento Confirmado")]
		CONFIRMADO = 0,

        [Description("Agendamento Pendente")]
        PENDENTE = 1,

        [Description("Agendamento Cancelado")]
        CANCELADO = 2
	}
}

