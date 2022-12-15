using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Entities
{
    public class PolicyHeaderInfo
    {
        [Key]
        public int PolicyHeaderId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String PaymentFolio { get; set; } = null!;
        
        
        [Required]
        [Column(TypeName = "varchar(50)")]

        public String DepositDate { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(14,2)")]
        public Decimal DepositAmount { get; set; }

        public List<PolicyCollection> PoliciesCollection { get; set; } = null!;
    }
}
