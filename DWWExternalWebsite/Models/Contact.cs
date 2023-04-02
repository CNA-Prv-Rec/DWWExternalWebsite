using System.Runtime.InteropServices;

namespace DWWExternalWebsite.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Company { get; set; }
        public string? MarketingSource { get; set; }

    }
}
