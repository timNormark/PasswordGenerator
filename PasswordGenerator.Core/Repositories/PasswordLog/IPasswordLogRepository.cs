using System.Threading.Tasks;
using PasswordGenerator.Core.Repositories.PasswordLog.Models;

namespace PasswordGenerator.Core.Repositories.PasswordLog
{
    public interface IPasswordLogRepository
    {
        public Task LogPassword(LogPasswordRepoModel logPasswordRepoModel);
    }
}
