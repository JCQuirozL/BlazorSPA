using APICollection.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Models
{
    public class PolicyInformationService:Policies
    {
        [Key]
        public int PolicyInfoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public String PaymentFolio { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(30)")]
        public String Bank { get; set; } = null!;

    
    }
}
