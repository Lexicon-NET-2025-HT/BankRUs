
using System.ComponentModel.DataAnnotations;

namespace BankRUs.Domain.Entities;

public class BankAccount
{
    // Det här är en entitet som inte finns i databasen
    public BankAccount(string accountNumber, string name, string userId)
    {
        Id = Guid.NewGuid();
        AccountNumber = accountNumber;
        Name = name;
        UserId = userId;
    }

    public Guid Id { get; protected set; }

    [MaxLength(25)]
    public string AccountNumber { get; protected set; }
    
    [MaxLength(25)]
    public string Name { get; protected set; }
    
    public decimal Balance { get; protected set; }
    public string UserId { get; protected set; }

    public void Deposit(decimal amount, string reference) { }
    public void Withdraw(decimal amount, string reference) { }
}

// Konstruktor
// Object initializer-syntax


