using System.Threading.Tasks;
using PasswordGenerator.Core.Services.GeneratePasswordService.Models;

namespace PasswordGenerator.Core.Services.GeneratePasswordService
{
    public interface IGeneratePasswordService
    {
        public Task<(bool success, string errorMessage, string password)> GeneratePassword(PersonServiceModel personServiceModel);
    }
}
