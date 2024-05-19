using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class OnlyDigitsAttribute : ValidationAttribute
    {
        public OnlyDigitsAttribute()
        {
            ErrorMessage = "Неправильный ввод";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string text = value.ToString();
            return !text.Any(x => !char.IsDigit(x));
        }
    }
}

