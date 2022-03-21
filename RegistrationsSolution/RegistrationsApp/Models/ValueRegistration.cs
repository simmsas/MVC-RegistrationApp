
namespace RegistrationsApp.Models
{
    public class ValueRegistration
    {
        public int RegValueId { get; set; }
        public RegValue RegValue { get; set; }
        public int FormedRegistrationId { get; set; }
        public FormedRegistration FormedRegistration { get; set; }
    }
}
