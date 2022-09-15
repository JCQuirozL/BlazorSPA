
namespace APICollection.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PolicyInformationService
    {
        [Key]
        public Int64 PolicyInfoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String Policy { get; set; } = null!;


        [Required]
        [Column(TypeName = "varchar(50)")]
        public String PaymentFolio { get; set; } = null!;


        [Required]
        [Column(TypeName = "varchar(50)")]
        public String ReferenceId { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(200)")]
        public String Bank { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String AccountNumber { get; set; } = null!;

       
        public DateTime DepositDate { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public Decimal DepositAmount { get; set; }

        //Campo auditoría
      
        public DateTime InfoDate { get; set; }


    }
}
