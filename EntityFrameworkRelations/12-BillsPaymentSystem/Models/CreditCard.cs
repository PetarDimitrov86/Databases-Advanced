namespace _12_BillsPaymentSystem.Models
{
    public class CreditCard : BillingDetail
    {
        public string CardType { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }
    }
}