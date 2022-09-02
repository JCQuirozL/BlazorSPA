using APICollection.Entities;

namespace APICollection.ViewModels
{
    public class ReiceivablePolicy
    {
        public string Policy { get; set; }
        public decimal TotalPremium { get; set; }
        public DateTime ValidationDate { get; set; }
        public string PaymentFolio { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal DepositAmount { get; set; }
        public string Reference { get; set; }
        public string Certificate { get; set; }
        public string Invoice { get; set; }
        public DateTime InfoDate { get; set; }
        public string EmmiterCenter { get; set; }
        public bool Validated { get; set; }

        public List<PolicyCommentVM> Comments { get; set; }

        public PolicyCollection collection { get; set; }


    }
}
