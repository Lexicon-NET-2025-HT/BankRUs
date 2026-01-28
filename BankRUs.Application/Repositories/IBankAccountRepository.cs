using BankRUs.Domain.Entities;

namespace BankRUs.Application.Repositories;

public interface IBankAccountRepository
{
    Task<BankAccount> CreateBankAccount(BankAccount bankAccount);
}
