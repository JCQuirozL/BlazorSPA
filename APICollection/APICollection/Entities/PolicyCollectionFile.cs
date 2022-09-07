using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Entities
{
    public class PolicyCollectionFile
    {
        [Key]
        public int PolicyFileId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String Policy { get; set; } = null!;


        [Required]
        [Column(TypeName = "decimal(14,2)")]
        public Decimal TotalPremium { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String Reference { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(15)")]
        public String Certificate { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(15)")]
        public String Invoice { get; set; } = null!;

        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime IssueDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public String EmmiterCenter { get; set; } = null!;


        //FEcha auditoría
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime InfoDate { get; set; }

    }
}
