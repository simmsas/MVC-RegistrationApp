using System.Collections.Generic;

namespace RegistrationsApp.Models
{
    public class RegAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RegValue> RegistrationValues { get; set; }
    }
}
