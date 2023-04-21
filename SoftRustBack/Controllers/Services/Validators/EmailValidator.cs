using System.ComponentModel.DataAnnotations;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class EmailValidator
    {
        public static bool isEmail(string? Email) 
        {
            if(Email == null)
                return false;
            return new EmailAddressAttribute().IsValid(Email);
        }
    }
}
