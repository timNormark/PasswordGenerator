using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PasswordGenerator.Core.Services.GeneratePasswordService.Models;
using PasswordGenerator.Core.Services.GeneratePasswordService.PasswordGenerators;
using PasswordGenerator.Core.Services.LogPasswordService;
using PasswordGenerator.Core.Services.LogPasswordService.Factories;

namespace PasswordGenerator.Core.Services.GeneratePasswordService
{
    public class GeneratePasswordService : IGeneratePasswordService
    {
        private readonly ILogPasswordService _logPasswordService;
        private readonly Func<PersonServiceModel, IPasswordGenerator> _passwordGeneratorChooser;
        private readonly PasswordGeneratorSettings _settings;

        public GeneratePasswordService(ILogPasswordService logPasswordService,
            Func<PersonServiceModel, IPasswordGenerator> passwordGeneratorChooser,
            PasswordGeneratorSettings settings)
        {
            _logPasswordService = logPasswordService ?? throw new ArgumentNullException(nameof(logPasswordService));
            _passwordGeneratorChooser = passwordGeneratorChooser ?? throw new ArgumentNullException(nameof(passwordGeneratorChooser));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<(bool success, string errorMessage, string password)> GeneratePassword(PersonServiceModel personServiceModel)
        {
            if (string.IsNullOrWhiteSpace(personServiceModel.FirstName))
                return (false, "Förnamn måste fyllas i", string.Empty);
            if (string.IsNullOrWhiteSpace(personServiceModel.LastName))
                return (false, "Efternamn måste fyllas i", string.Empty);
            if (string.IsNullOrWhiteSpace(personServiceModel.Email))
                return (false, "Email måste fyllas i", string.Empty);
            if(!new EmailAddressAttribute().IsValid(personServiceModel.Email))
                return (false, "Detta är inte en Emailadress", string.Empty);
            if (!personServiceModel.Email.EndsWith(_settings.ValidEmailPostfix))
                return (false, $"Email måste sluta med {_settings.ValidEmailPostfix}", string.Empty);
            if(personServiceModel is StudentServiceModel s && !_settings.ValidSchoolYears.ToList().Contains(s.SchoolYear))
                return (false, $"En ogiltlig årskurs har valts", string.Empty);

            var passwordGenerator = _passwordGeneratorChooser(personServiceModel);
            if (passwordGenerator == null)
                return (false, "There are no matching rules for password generation for this object", string.Empty);

            string password = passwordGenerator.Generate();

            var logPasswordRepoModel = LogPasswordServiceModelFactory.Create(personServiceModel, password);
            await _logPasswordService.LogPassword(logPasswordRepoModel);

            return (true, string.Empty, password);
        }
    }
}
