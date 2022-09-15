namespace PoliciesBlazorApp.Models
{
    public class LeasingData
    {
        public DateTime? ValidationDate { get; set; }
        public String PaymentFolio { get; set; }

        public String ReferenceId { get; set; }
        public String Bank { get; set; }
        public String AccountNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public Decimal DepositAmount { get; set; }
    }
}
