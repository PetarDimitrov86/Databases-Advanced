namespace _12_BillsPaymentSystem.Models
{
    public class BankAccount : BillingDetail
    {
        public string BankName { get; set; }

        public string SWIFTCode { get; set; }
    }
}