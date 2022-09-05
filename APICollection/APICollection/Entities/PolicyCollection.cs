

namespace APICollection.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using APICollection.Models;
    public class PolicyCollection

    {
        [Key]
        public int PolicyCollectionId { get; set; }

        [ForeignKey("PolicyCollectionFile")]
        public int PolicyFileId { get; set; }
        public PolicyCollectionFile PolicyCollectionFile { get; set; } = null!;


        //Relacion con tabla PolicyInformationService (Tabla dónde se guardan datos de la póliza del lado de leasing)
        [ForeignKey("PolicyInformationService")]
        public int PolicyInfoId { get; set; }
        public PolicyInformationService PolicyInformationService { get; set; } = null!;

        public DateTime ValidationDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string AccountNumber { get; set; } = null!;

        public DateTime DepositDate { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public decimal DepositAmount { get; set; }

        public bool Validated { get; set; } = false;

        [InverseProperty("PolicyCollectionId")]
        public List<PolicyComment> Comments { get; set; } = null!;
    }
}
