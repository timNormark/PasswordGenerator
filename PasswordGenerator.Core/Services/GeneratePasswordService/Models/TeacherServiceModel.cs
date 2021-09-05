namespace PasswordGenerator.Core.Services.GeneratePasswordService.Models
{
    public class TeacherServiceModel : PersonServiceModel
    {
        public TeacherServiceModel(string firstName, string lastName, string email)
            : base(firstName, lastName, email)
        {
        }
    }
}
