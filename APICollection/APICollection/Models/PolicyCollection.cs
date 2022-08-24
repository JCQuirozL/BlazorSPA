namespace APICollection.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PolicyCollection

    {
        [Key]
        public int PolicyCollectionId { get; set; }

        [ForeignKey("PolicyCollectionFile")]
        public int PolicyFileId { get; set; }
        public PolicyCollectionFile PolicyCollectionFile { get; set; } = null!;

        [ForeignKey("PolicyInformationService")]
        public int PolicyInfoId { get; set; }
        public PolicyInformationService PolicyInformationService { get; set; } = null!;

        public DateTime ValidationDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public String AccountNumber { get; set; } = null!;

        public DateTime DepositDate { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public Decimal DepositAmount { get; set; }

        public Boolean Validated { get; set; } = false;

    }
}
