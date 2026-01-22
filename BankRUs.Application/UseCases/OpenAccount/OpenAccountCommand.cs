
namespace BankRUs.Application.UseCases.OpenAccount;

public class OpenAccountCommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string Email { get; set; }
}
