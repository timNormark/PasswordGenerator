using System;
using System.IO;
using System.Threading.Tasks;
using PasswordGenerator.Core.Repositories.PasswordLog;
using PasswordGenerator.Core.Repositories.PasswordLog.Models;

namespace PasswordGenerator.Infrastructure.Repositories
{
    public class PasswordLogRepository : IPasswordLogRepository
    {
        public async Task LogPassword(LogPasswordRepoModel l)
        {
            string line = $"<{l.CreatedDate}>,<{l.HolderName}>,<{l.HolderEmail}>,<{l.Password}>\n";
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}/passwords.log";
            await File.AppendAllTextAsync(path, line);
        }
    }
}
