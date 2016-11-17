namespace _12_BillsPaymentSystem.Models
{
    public class BillingDetail
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Number { get; set; }

        public string Owner { get; set; }
    }
}