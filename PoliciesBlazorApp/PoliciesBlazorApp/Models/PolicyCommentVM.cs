﻿namespace PoliciesBlazorApp.Models
{
    public class PolicyCommentVM
    {
        public String Comment { get; set; }
        public String CommentType { get; set; }
        public string User { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
