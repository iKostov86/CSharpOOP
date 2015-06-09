using System;
using Banks;

public class Test
{
    protected static void Main()
    {
        Customer client = new Individual() { FullName = "Ivaylo Kostov" };

        Account account = new DepositAccount() { Client = client, Balance = 1000, InterestRate = 4 };

        Console.WriteLine(account.GetType());
        Console.WriteLine(account.Client);
    }
}
