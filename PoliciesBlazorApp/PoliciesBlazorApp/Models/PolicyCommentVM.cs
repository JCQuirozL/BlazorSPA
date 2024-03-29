﻿using System.ComponentModel.DataAnnotations;

namespace PoliciesBlazorApp.Models
{
    //ViewModel para el get de comments
    public class PolicyCommentVM
    {
        [Required(ErrorMessage = "El comentario no puede quedar vacío")]
        public String Comment { get; set; }
        public String CommentType { get; set; }
        public string User { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
