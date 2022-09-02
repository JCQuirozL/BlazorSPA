using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Entities
{
    public class PolicyComment
    {
        [Key]
        [Required]
        public int CommentId { get; set; }

        //[ForeignKey("PolicyCollection")]
        //public int PolicyColId { get; set; }
        //public PolicyCollection PolicyCollection { get; set; } = null!;


        [Column(TypeName = "varchar(10)")]
        public String UserName { get; set; } = null!;

        [Column(TypeName = "varchar(30)")]
        public String CommentType { get; set; }=null!;

        public DateTime CommentDate { get; set; }

        [Column(TypeName = "varchar(250)")]
        public String Comment { get; set; } = null!;
    }
}
