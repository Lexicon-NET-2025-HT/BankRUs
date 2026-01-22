using BankRUs.Application.UseCases.OpenAccount;
using Microsoft.AspNetCore.Mvc;

namespace BankRUs.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly OpenAccountHandler _openAccountHandler;

    public AccountsController(OpenAccountHandler openAccountHandler)
    {
        _openAccountHandler = openAccountHandler;
    }

    // POST /api/accounts
    [HttpPost]
    public async Task<ActionResult> Create()
    {
        var command = new OpenAccountCommand
        {
            FirstName = "John",
            LastName = "Doe",
            SocialSecurityNumber = "19900101-2010",
            Email = "john@doe.com"
        };

        var result = await _openAccountHandler.HandleAsync(command);

        // 201 Create
        return Created("", new { result.CustomerId });
    }
}
