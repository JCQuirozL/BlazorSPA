namespace PoliciesBlazorApp.Models
{
    public class PoliciesCollectionVM
    {
        public String policy { get; set; } = null!;
        public Decimal totalPremium { get; set; }
        public DateTime validationDate { get; set; }
        public String paymentFolio { get; set; } = null!;
        public String bank { get; set; } = null!;
        public String accountNumber { get; set; } = null!;
        public DateTime issueDate { get; set; }
        public Decimal depositAmount { get; set; } 
        public String reference { get; set; } = null!;
        public String certificate { get; set; } = null!;
        public String invoice { get; set; } = null!;
        public DateTime infoDate { get; set; }
        public String emmiterCenter { get; set; } = null!;

        public Boolean validated { get; set; }
    }
}
