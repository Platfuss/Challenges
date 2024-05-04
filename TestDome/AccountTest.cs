namespace Challenges.TestDome;

public class AccountToTest
{
    public double Balance { get; private set; }
    public double OverdraftLimit { get; private set; }
    public AccountToTest(double overdraftLimit)
    {
        this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
        this.Balance = 0;
    }
    public bool Deposit(double amount)
    {
        if (amount > 0)
        {
            this.Balance += amount;
            return true;
        }
        return false;
    }
    public bool Withdraw(double amount)
    {
        if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
        {
            this.Balance -= amount;
            return true;
        }
        return false;
    }
}