

namespace APICollection.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TimeLimitConfiguration
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte ConfigId { get; set; }

        [Required]
        public Byte TimeLimit { get; set; }

        [Column(TypeName = "varchar(50)")]
        public String? Description { get; set; }
    }
}
