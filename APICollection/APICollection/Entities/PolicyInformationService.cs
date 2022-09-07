using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Entities
{
    public class PolicyInformationService
    {
        [Key]
        public int PolicyInfoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String Policy { get; set; } = null!;


        [Required]
        [Column(TypeName = "varchar(50)")]
        public String PaymentFolio { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(200)")]
        public String Bank { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String AccountNumber { get; set; } = null!;

        [Column(TypeName = "smalldatetime")]
        public DateTime DepositDate { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public Decimal DepositAmount { get; set; }

        //Campo auditoría
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime InfoDate { get; set; }


    }
}
