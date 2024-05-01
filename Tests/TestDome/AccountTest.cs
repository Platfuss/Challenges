using Challenges.TestDome;

namespace Tests.TestDome;

/// <summary>
/// https://www.testdome.com/questions/c-sharp/account-test/96021
/// </summary>
[TestFixture]
public class Tests
{
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotDepositNegativeValue()
    {
        Account account = new Account(100);
        account.Deposit(-10);

        Assert.AreEqual(0, account.Balance, epsilon);
    }

    [Test]
    public void AccountCannotWithdrawNegativeValue()
    {
        Account account = new Account(100);
        account.Withdraw(-10);

        Assert.AreEqual(0, account.Balance, epsilon);
    }

    [Test]
    public void AccountCannotOverstepOverdraftLimit()
    {
        Account account = new Account(100);
        account.Withdraw(150);

        Assert.AreEqual(0, account.Balance, epsilon);
    }

    [Test]
    public void AccountDepositCorrectValue()
    {
        Account account = new Account(100);
        account.Deposit(10);

        Assert.AreEqual(10, account.Balance, epsilon);
    }

    [Test]
    public void AccountWithdrawCorrectValue()
    {
        Account account = new Account(100);
        account.Withdraw(10);

        Assert.AreEqual(-10, account.Balance, epsilon);
    }
}
