using System;
using PasswordGenerator.Core.Services.GeneratePasswordService.Models;
using PasswordGenerator.Core.Services.LogPasswordService.Models;

namespace PasswordGenerator.Core.Services.LogPasswordService.Factories
{
    public static class LogPasswordServiceModelFactory
    {
        public static LogPasswordServiceModel Create(PersonServiceModel p, string password) =>
            new LogPasswordServiceModel(DateTime.Now, $"{p.FirstName} {p.LastName}", p.Email, password);
    }
}
