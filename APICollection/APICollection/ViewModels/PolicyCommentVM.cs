using APICollection.Entities;

namespace APICollection.ViewModels
{
    public class PolicyCommentVM
    {
        public string Comment { get; set; }
        public string User { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
