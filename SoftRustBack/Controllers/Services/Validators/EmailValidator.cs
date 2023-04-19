using System.ComponentModel.DataAnnotations;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class EmailValidator
    {
        public static bool isEmail(string Email) 
        {
            return new EmailAddressAttribute().IsValid(Email);
        }
    }
}
