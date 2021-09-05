using PasswordGenerator.Core.Services.GeneratePasswordService.Models;
using PasswordGenerator.Web.Models;

namespace PasswordGenerator.Web.Factories
{
    public static class PersonServiceModelFactory
    {
        public static PersonServiceModel Create(PersonViewModel p) =>
            p.PersonType switch
            {
                PersonType.Student => new StudentServiceModel(p.FirstName, p.LastName, p.Email, p.SchoolYear),
                PersonType.Teacher => new TeacherServiceModel(p.FirstName, p.LastName, p.Email),
                _ => null
            };
    }
}
