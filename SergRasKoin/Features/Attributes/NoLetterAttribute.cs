using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NoLetterAttribute : ValidationAttribute
    {
        public NoLetterAttribute()
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
            return !text.Any(x => char.IsLetter(x));
        }
    }
}