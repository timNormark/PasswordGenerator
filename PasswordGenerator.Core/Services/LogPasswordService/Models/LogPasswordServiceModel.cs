using System;
namespace PasswordGenerator.Core.Services.LogPasswordService.Models
{
    public class LogPasswordServiceModel
    {
        public DateTime CreatedDate { get; set; }
        public string HolderName { get; set; }
        public string HolderEmail { get; set; }
        public string Password { get; set; }

        public LogPasswordServiceModel(DateTime createdDate, string holderName, string holderEmail, string password)
        {
            CreatedDate = createdDate;
            HolderName = holderName;
            HolderEmail = holderEmail;
            Password = password;
        }
    }
}
