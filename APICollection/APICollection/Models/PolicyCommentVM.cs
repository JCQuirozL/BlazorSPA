using APICollection.Entities;

namespace APICollection.Models
{
    public class PolicyCommentVM
    {
        public String Comment { get; set; }
        public String User { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
