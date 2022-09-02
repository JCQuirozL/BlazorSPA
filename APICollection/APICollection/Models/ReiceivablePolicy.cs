using APICollection.Entities;

namespace APICollection.Models
{
    public class ReiceivablePolicy
    {
        public String Policy { get; set; }
        public Decimal TotalPremium { get; set; }
        public DateTime ValidationDate { get; set; }
        public String PaymentFolio { get; set; }
        public String Bank { get; set; }
        public String AccountNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public Decimal DepositAmount { get; set; }
        public String Reference { get; set; }
        public String Certificate { get; set; }
        public String Invoice { get; set; }
        public DateTime InfoDate { get; set; }
        public String EmmiterCenter { get; set; }
        public List<PolicyCommentVM> Comments { get; set; }
        public Boolean Validated { get; set; }


    }
}
