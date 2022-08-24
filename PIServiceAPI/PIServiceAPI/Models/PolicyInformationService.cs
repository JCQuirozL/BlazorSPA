using PIServiceAPI.NTTs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIServiceAPI.Models
{
    public class PolicyInformationService : Policies
    {
        [Key]
        public int PolicyInfoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string PaymentFolio { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Bank { get; set; } = null!;


    }
}
