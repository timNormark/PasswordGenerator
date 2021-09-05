using PasswordGenerator.Core.Repositories.PasswordLog.Models;
using PasswordGenerator.Core.Services.LogPasswordService.Models;

namespace PasswordGenerator.Core.Repositories.PasswordLog.Factories
{
    public static class LogPasswordRepoModelFactory
    {
        public static LogPasswordRepoModel Create(LogPasswordServiceModel p) =>
            new LogPasswordRepoModel(p.CreatedDate, p.HolderName, p.HolderEmail, p.Password);
    }
}
