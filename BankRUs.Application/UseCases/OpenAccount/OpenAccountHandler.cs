using BankRUs.Application.Identity;
using BankRUs.Application.Repositories;
using BankRUs.Domain.Entities;

namespace BankRUs.Application.UseCases.OpenAccount;

public class OpenAccountHandler
{
    private readonly IIdentityService _identityService;
    private readonly IBankAccountRepository _bankAccountRepository;

    public OpenAccountHandler(
        IIdentityService identityService,
        IBankAccountRepository bankAccountRepository)
    {
        _identityService = identityService;
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task<OpenAccountResult> HandleAsync(OpenAccountCommand command)
    {
        // 1 - Validera indata

        // 2 - Skapa användarkonto
        var createUserResult = await _identityService.CreateUserAsync(new CreateUserRequest(
            FirstName: command.FirstName,
            LastName: command.LastName,
            SocialSecurityNumber: command.SocialSecurityNumber,
            Email: command.Email
         ));

        // 3 - Skapa ett första bankkonto åt kunden
        var bankAccount = new BankAccount(
            accountNumber: "100.200.300",
            name: "Standardkonto",
            userId: createUserResult.UserId.ToString());

        await _bankAccountRepository.CreateBankAccount(bankAccount);

        // 4 - Skicka välkomstmail till kund
        // _emailSender.Send("Ditt bankkonto är nu redo!");

        // 5 - Returnera resultatet av kommandot

        return new OpenAccountResult(UserId: createUserResult.UserId);
    }
}