using Microsoft.EntityFrameworkCore;
using RegistrationsApp.Data;
using RegistrationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationsApp.Repositories
{
    public class RegistrationsRepository : RepositoryBase<FormedRegistration>
    {
        public RegistrationsRepository(DataContext context) : base(context) { }
        public List<FormedRegistration> GetAll()
        {
            return _context.FormedRegistrations.ToList();
        }

        public int Create()
        {
            FormedRegistration newReg = new FormedRegistration();
            _context.Add(newReg);
            _context.SaveChanges();
            return newReg.Id;
        }

        public FormedRegistration GetById(int regId)
        {
            return _context.FormedRegistrations
                .Include(r => r.ValueRegistrations)
                .FirstOrDefault(r => r.Id == regId);
        }

        public List<ValueRegistration> GetAllRegValues(int regId)
        {
            return _context.ValueRegistrations
                    .Include(vr => vr.RegValue)
                    .Where(vr => vr.FormedRegistrationId == regId)
                    .ToList();
        }
    }
}
