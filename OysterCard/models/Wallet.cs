namespace OysterCard.models;

public class Wallet
{
    private decimal amount = 0;

    public void Recharge(decimal amount)
    {
        this.amount += amount;
    }

    public void UseWallet(decimal amount)
    {
        if (this.amount < amount)
            throw new Exception("Insufficient Fund in wallet");
        this.amount -= amount;
    }

    public decimal Balance => amount;
}