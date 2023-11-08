namespace OysterCard.models
{
    public class Wallet
    {
        private decimal amount = 0;

        public void Recharge(decimal amount) {
            this.amount += amount;
        }

        public void UseWallet(decimal amount) {
            this.amount -= amount;
        }

        public decimal Balance => amount;
    }
}