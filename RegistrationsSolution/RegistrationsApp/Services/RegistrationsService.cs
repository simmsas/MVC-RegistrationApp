using RegistrationsApp.Dtos;
using RegistrationsApp.Models;
using RegistrationsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationsApp.Services
{
    public class RegistrationsService
    {
        private RegistrationsRepository _registrationsRepository;
        private AttributesRepository _attributesRepository;
        private ValuesRepository _valuesRepository;

        public RegistrationsService(
            RegistrationsRepository registrationsRepository
            , AttributesRepository attributesRepository
            , ValuesRepository valuesRepository)
        {
            _registrationsRepository = registrationsRepository;
            _attributesRepository = attributesRepository;
            _valuesRepository = valuesRepository;
        }

        public DisplayAll GetAll()
        {
            DisplayAll result = new DisplayAll()
            {
                RegsIds = _registrationsRepository.GetAll().Select(r => r.Id).ToList()
            };

            return result;
        }

        public int Create()
        {
            return _registrationsRepository.Create();
        }

        public Registration PrepareForUpdate(int regId)
        {
            FormedRegistration formedReg = _registrationsRepository.GetById(regId);
            List<int> selectedValuesIds =
                _registrationsRepository.GetAllRegValues(regId).Select(x => x.RegValueId).ToList();
            List<RegValue> selectedValues = _valuesRepository.GetByIdsList(selectedValuesIds);

            Registration reg = new Registration()
            {
                RegistrationId = regId,
                Attributes = _attributesRepository.GetAll()
            };

            reg.AttributesIds = reg.Attributes.Select(a => a.Id).ToList();
            reg.AttributesSelectedValues = GetOrderedValues(reg.Attributes, selectedValues);
            reg.SelectedValuesIds = GetOrderedValuesIds(reg.AttributesSelectedValues);

            return reg;
        }

        private List<RegValue> GetOrderedValues(List<RegAttribute> attributes, List<RegValue> selectedValues)
        {
            List<RegValue> result = new List<RegValue>();

            foreach (var attribute in attributes)
            {
                RegValue value = selectedValues.FirstOrDefault(v => v.RegistrationAttributeId == attribute.Id);

                result.Add(value);
            }

            return result;
        }

        private List<int> GetOrderedValuesIds(List<RegValue> orderedValues)
        {
            List<int> result = new List<int>();

            foreach (var val in orderedValues)
            {
                if (val != null)
                {
                    result.Add(val.Id);
                }
                else
                {
                    result.Add(0);
                }
            }

            return result;
        }
    }
}
