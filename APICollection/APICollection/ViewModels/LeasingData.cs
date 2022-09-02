namespace APICollection.ViewModels
{
    public class LeasingData
    {
        public DateTime ValidationDate { get; set; }
        public String PaymentFolio { get; set; }
        public String Bank { get; set; }
        public String AccountNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public Decimal DepositAmount { get; set; }

    }
}
