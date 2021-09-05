using System.Collections.Generic;

namespace PasswordGenerator.Web.Models
{
    public class PasswordGenerationFormViewModel
    {
        public IEnumerable<int> ValidSchoolYears { get; set; }
        public PersonViewModel Person { get; set; } = new PersonViewModel();
        public string GeneratedPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
