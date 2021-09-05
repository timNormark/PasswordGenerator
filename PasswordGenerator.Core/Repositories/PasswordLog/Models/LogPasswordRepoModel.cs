using System;
namespace PasswordGenerator.Core.Repositories.PasswordLog.Models
{
    public class LogPasswordRepoModel
    {
        public DateTime CreatedDate { get; set; }
        public string HolderName { get; set; }
        public string HolderEmail { get; set; }
        public string Password { get; set; }

        public LogPasswordRepoModel(DateTime createdDate, string holderName, string holderEmail, string password)
        {
            CreatedDate = createdDate;
            HolderName = holderName;
            HolderEmail = holderEmail;
            Password = password;
        }
    }
}
