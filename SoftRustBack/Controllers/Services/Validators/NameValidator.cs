using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SoftRustBack.Controllers.Services.Validators
{
    public class NameValidator
    {
        /// <summary>
        /// Валидация имени
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool isName(string? Name)
        {
            if (Name == null)
                return false;
            return Regex.Match(Name, @"(\S+){3}").Success;
        }
    }
}
