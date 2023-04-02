namespace DWWExternalWebsite.Models
{
    public interface IContact
    {
        string? Company { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string? MarketingSource { get; set; }
        string Message { get; set; }
        string Phone { get; set; }
    }
}