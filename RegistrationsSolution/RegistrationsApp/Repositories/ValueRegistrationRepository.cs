using RegistrationsApp.Data;
using RegistrationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationsApp.Repositories
{
    public class ValueRegistrationRepository : RepositoryBase<ValueRegistration>
    {
        public ValueRegistrationRepository(DataContext context) : base(context) { }
        public List<ValueRegistration> GetAll(int? regId)
        {
            List<ValueRegistration> result = new List<ValueRegistration>();

            if (regId == null)
            {
                result = _context.ValueRegistrations.ToList();
            }
            else
            {
                result = _context.ValueRegistrations.Where(vr => vr.FormedRegistrationId == regId).ToList();
            }

            return result;
        }
        public void Create(List<ValueRegistration> valuesRegistration)
        {
            _context.ValueRegistrations.AddRange(valuesRegistration);
            _context.SaveChanges();
        }

        public void Delete(List<ValueRegistration> valsReg)
        {
            _context.ValueRegistrations.RemoveRange(valsReg);
            _context.SaveChanges();
        }
    }
}
