using Microsoft.EntityFrameworkCore;
using RegistrationsApp.Data;
using RegistrationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationsApp.Repositories
{
    public class AttributesRepository : RepositoryBase<RegAttribute>
    {
        public AttributesRepository(DataContext context) : base(context) { }

        public List<RegAttribute> GetAll()
        {
            return _context.RegAttributes.Include(a => a.RegistrationValues).ToList();
        }
    }
}
