namespace PoliciesBlazorApp.Models
{
    public class Author
    {
        public String Name { get; set; }
        public String Department { get; set; }
        public int Id { get; set; }
    }

    public class PolicyComment
    {
        public Author Author { get; set; } = new Author();
        public String Content { get; set; }
    }
}
