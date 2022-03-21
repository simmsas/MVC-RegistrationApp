using Microsoft.EntityFrameworkCore;
using RegistrationsApp.Data;
using RegistrationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationsApp.Repositories
{
    public class ValuesRepository : RepositoryBase<RegValue>
    {
        public ValuesRepository(DataContext context) : base(context) { }

        public List<RegValue> GetAll()
        {
            return _context.RegValues.Include(v => v.ValueRegistrations).ToList();
        }

        public List<RegValue> GetByIdsList(List<int> valuesIds)
        {
            return GetAll().Where(v => valuesIds.Contains(v.Id)).ToList();
        }
    }
}
