namespace PoliciesBlazorApp.Models
{
    public class Data
    {
        public int PolicyId { get; set; }
        public String Policy { get; set; }
        public LeasingData Leasing { get; set; }

        public ClipertData Clipert { get; set; }
        public int ConfigId { get; set; }
        public int Term { get; set; }
        public Boolean Validated { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<PolicyCommentVM> Comments { get; set; }
    }
}
