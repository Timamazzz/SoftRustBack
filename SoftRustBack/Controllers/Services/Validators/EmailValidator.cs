using System.ComponentModel.DataAnnotations;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class EmailValidator
    {
        /// <summary>
        /// Валидация email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static bool isEmail(string? Email) 
        {
            if(Email == null)
                return false;
            return new EmailAddressAttribute().IsValid(Email);
        }
    }
}
