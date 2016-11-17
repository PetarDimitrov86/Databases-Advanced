namespace BillingPaymentSystem.Models
{
    class CreditCard : BilliingDetail
    {
        public string CardType { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

    }
}
