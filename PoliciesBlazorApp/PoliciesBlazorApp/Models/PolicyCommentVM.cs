namespace PoliciesBlazorApp.Models
{
    //ViewModel para el get de comments
    public class PolicyCommentVM
    {
        public String Comment { get; set; }
        public String CommentType { get; set; }
        public string User { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
