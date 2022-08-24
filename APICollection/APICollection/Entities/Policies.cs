using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Entities
{
    public abstract class Policies
    {
        [Required]
        [Column(TypeName ="varchar(10)")]
        public String Policy { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Certificate { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        public String Invoice { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }


        [Required]
        [Column(TypeName = "varchar(3)")]
        public String EmitterCenter { get; set; } = null!;

        
        [Required]
        public DateTime InfoDate { get; set; }


    }
}
