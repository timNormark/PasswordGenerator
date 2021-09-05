using System.Threading.Tasks;
using PasswordGenerator.Core.Services.LogPasswordService.Models;

namespace PasswordGenerator.Core.Services.LogPasswordService
{
    public interface ILogPasswordService
    {
        public Task LogPassword(LogPasswordServiceModel logPasswordServiceModel);
    }
}
