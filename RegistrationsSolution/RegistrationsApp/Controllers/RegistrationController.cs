using Microsoft.AspNetCore.Mvc;
using RegistrationsApp.Dtos;
using RegistrationsApp.Services;
namespace RegistrationsApp.Controllers
{
    public class RegistrationController :Controller
    {
        private readonly AttributesService _attributesService;
        private readonly RegistrationsService _registrationsService;
        private readonly ValueRegistrationService _valueRegistrationService;

        public RegistrationController(
            AttributesService attributesService,
            RegistrationsService registrationsService,
            ValueRegistrationService valueRegistrationService)
        {
            _attributesService = attributesService;
            _registrationsService = registrationsService;
            _valueRegistrationService = valueRegistrationService;
        }

        public IActionResult All()
        {
            DisplayAll allReg = _registrationsService.GetAll();
            return View(allReg);
        }

        public IActionResult Add()
        {
            Registration newRegistration = _attributesService.PrepareNewRegistration();
            return View(newRegistration);
        }

        [HttpPost]
        public IActionResult Add(Registration registration)
        {
            int regId = _registrationsService.Create();
            _valueRegistrationService.Create(regId, registration.SelectedValuesIds);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Update(int regId)
        {
            Registration update = _registrationsService.PrepareForUpdate(regId);
            return View(update);
        }

        [HttpPost]
        public IActionResult Update(Registration registration)
        {
            _valueRegistrationService.Update(registration.RegistrationId, registration.SelectedValuesIds);
            return RedirectToAction(nameof(All));
        }
    }
}

