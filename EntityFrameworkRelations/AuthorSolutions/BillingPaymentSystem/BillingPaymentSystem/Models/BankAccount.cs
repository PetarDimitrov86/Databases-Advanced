namespace BillingPaymentSystem.Models
{
    class BankAccount : BilliingDetail
    {
        public string BankName { get; set; }

        public string SwiftCode { get; set; }
    }
}
