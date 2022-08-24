using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIServiceAPI.NTTs
{
    public abstract class Policies
    {
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Policy { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Certificate { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Invoice { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }


        [Required]
        [Column(TypeName = "varchar(3)")]
        public string EmitterCenter { get; set; } = null!;


        [Required]
        public DateTime InfoDate { get; set; }


    }
}
