using System.ComponentModel;

namespace MedicalConsulting.Application.Helpers
{
    public static class Utils
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return null;

            if (value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false) is DescriptionAttribute[] source && source.Any())
            {
                return source.FirstOrDefault().Description;
            }

            return value.ToString();
        }
    }
}

