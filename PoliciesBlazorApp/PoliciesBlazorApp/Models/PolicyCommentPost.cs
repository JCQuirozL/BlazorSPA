using System.ComponentModel.DataAnnotations;

namespace PoliciesBlazorApp.Models
{
    public class PolicyCommentPost
    {
        public String Policy { get; set; }
        public String Invoice { get; set; }

        [Required(ErrorMessage = "El comentario no puede quedar vacío")]
        public String Comment { get; set; }
    }
}
