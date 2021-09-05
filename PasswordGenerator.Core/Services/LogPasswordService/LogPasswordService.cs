using System;
using System.Threading.Tasks;
using PasswordGenerator.Core.Repositories.PasswordLog;
using PasswordGenerator.Core.Repositories.PasswordLog.Factories;
using PasswordGenerator.Core.Services.LogPasswordService.Models;

namespace PasswordGenerator.Core.Services.LogPasswordService
{
    public class LogPasswordService : ILogPasswordService
    {
        private readonly IPasswordLogRepository _passwordLogRepository;

        public LogPasswordService(IPasswordLogRepository passwordLogRepository)
        {
            _passwordLogRepository = passwordLogRepository ?? throw new ArgumentNullException(nameof(passwordLogRepository));
        }

        public async Task LogPassword(LogPasswordServiceModel logPasswordServiceModel)
        {
            var logPasswordRepoModel = LogPasswordRepoModelFactory.Create(logPasswordServiceModel);
            await _passwordLogRepository.LogPassword(logPasswordRepoModel);
        }
    }
}
