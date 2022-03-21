using Microsoft.EntityFrameworkCore;
using RegistrationsApp.Models;

namespace RegistrationsApp.Data
{
    public class DataContext :DbContext
    {
        public DbSet<RegAttribute> RegAttributes { get; set; }
        public DbSet<RegValue> RegValues { get; set; }
        public DbSet<FormedRegistration> FormedRegistrations { get; set; }
        public DbSet<ValueRegistration> ValueRegistrations { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValueRegistration>()
            .HasKey(bc => new { bc.FormedRegistrationId, bc.RegValueId });
        }
    }
}
