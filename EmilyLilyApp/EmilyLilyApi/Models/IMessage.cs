namespace EmilyLilyApi.Models
{
    public interface IMessage
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Message { get; set; }
    }
}
