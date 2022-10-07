namespace PoliciesBlazorApp.Models
{
    public class PolicyCommentVM:PolicyCommentPost
    {
        public String CommentType { get; set; }
        public string User { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
