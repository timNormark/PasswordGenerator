using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Core;
using PasswordGenerator.Web.Models;

namespace PasswordGenerator.Web.Views.Shared.Components.PasswordGenerationForm
{
    public class PasswordGenerationFormViewComponent : ViewComponent
    {
        private readonly PasswordGeneratorSettings _settings;

        public PasswordGenerationFormViewComponent(PasswordGeneratorSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<IViewComponentResult> InvokeAsync(PasswordGenerationFormViewModel form)
        {

            if (form == null)
            {
                return View(new PasswordGenerationFormViewModel
                {
                    ValidSchoolYears = _settings.ValidSchoolYears
                });
            }

            form.ValidSchoolYears = _settings.ValidSchoolYears;
            return View(form);
        }
    }
}
