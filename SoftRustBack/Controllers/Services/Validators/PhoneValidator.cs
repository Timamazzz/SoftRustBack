using System.Text.RegularExpressions;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class PhoneValidator
    {
        public static bool IsPhoneNumber(string Phone)
        {
            return Regex.Match(Phone, @"^(\+7[0-9]{10})$").Success;
        }
    }
}
