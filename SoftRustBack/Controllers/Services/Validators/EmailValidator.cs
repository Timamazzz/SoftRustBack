using System.ComponentModel.DataAnnotations;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class EmailValidator
    {
        public bool isEmail(string Email) 
        {
            return new EmailAddressAttribute().IsValid(Email);
        }
    }
}
