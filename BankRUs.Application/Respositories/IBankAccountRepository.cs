using BankRUs.Domain.Entities;

namespace BankRUs.Application.Respositories;

public interface IBankAccountRepository
{
    Task<BankAccount> CreateBankAccount(BankAccount bankAccount);
}
