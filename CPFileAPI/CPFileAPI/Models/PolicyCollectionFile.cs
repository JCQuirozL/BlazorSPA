using BCWebAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCWebAPI.Models
{
    public class PolicyCollectionFile:Policies
    {
        [Key]
        public int PolicyFileId { get; set; }

        [Required]
        [Column(TypeName = "decimal(14,2)")]

        public Decimal TotalPremium { get; set; }

        [Required]
        [Column(TypeName="varchar(38)")]
        [StringLength(38)]
        public string Reference { get; set; } = null!;

    }
}
