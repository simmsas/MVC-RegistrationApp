using Microsoft.EntityFrameworkCore;
using RegistrationsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationsApp.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    }
}
