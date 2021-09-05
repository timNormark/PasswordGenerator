namespace PasswordGenerator.Web.Models
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public PersonType PersonType { get; set; }
        public int SchoolYear { get; set; }


        public PersonViewModel()
        {
        }

        public PersonViewModel(string firstName, string lastName, string email, PersonType personType, int schoolYear)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PersonType = personType;
            SchoolYear = schoolYear;
        }
    }
}
