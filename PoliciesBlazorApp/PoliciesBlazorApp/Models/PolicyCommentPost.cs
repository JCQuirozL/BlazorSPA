
//ViewModel para el post de comments
namespace PoliciesBlazorApp.Models
{
    using System.ComponentModel.DataAnnotations;
    public class PolicyCommentPost
    {
        public String Policy { get; set; }
        public String Invoice { get; set; }

        [Required(ErrorMessage = "El comentario no puede quedar vacío")]
        public String Comment { get; set; }
    }
}
