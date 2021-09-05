namespace PasswordGenerator.Core.Services.GeneratePasswordService.Models
{
    public class PersonServiceModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public PersonServiceModel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
