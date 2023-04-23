using System.Text.RegularExpressions;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class PhoneValidator
    {
        /// <summary>
        /// Валидация телефона
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string? Phone)
        {
            if(Phone == null)
                return false;
            return Regex.Match(Phone, @"^(\+7[0-9]{10})$").Success;
        }
    }
}
