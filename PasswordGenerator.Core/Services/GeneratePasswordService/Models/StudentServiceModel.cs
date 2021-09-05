namespace PasswordGenerator.Core.Services.GeneratePasswordService.Models
{
    public class StudentServiceModel : PersonServiceModel
    {
        public int SchoolYear { get; set; }

        public StudentServiceModel(string firstName, string lastName, string email, int schoolYear)
            : base(firstName, lastName, email)
        {
            SchoolYear = schoolYear;
        }
    }
}
