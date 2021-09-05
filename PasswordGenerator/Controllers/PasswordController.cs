using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Core.Services.GeneratePasswordService;
using PasswordGenerator.Web.Factories;
using PasswordGenerator.Web.Models;

namespace PasswordGenerator.Web.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IGeneratePasswordService _generatePasswordService;

        public PasswordController(IGeneratePasswordService generatePasswordService)
        {
            _generatePasswordService = generatePasswordService ?? throw new ArgumentNullException(nameof(generatePasswordService));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GeneratePassword(PasswordGenerationFormViewModel form)
        {
            ModelState.Clear();
            var personServiceModel = PersonServiceModelFactory.Create(form.Person);
            var (success, errorMessage, password) = await _generatePasswordService.GeneratePassword(personServiceModel);
            if(success)
            {
                form.GeneratedPassword = password;
                return ViewComponent("PasswordGenerationForm", new { form });
            }
            else
            {
                form.ErrorMessage = errorMessage;
                return ViewComponent("PasswordGenerationForm", new { form });
            }
        }
    }
}
