using APICollection.ViewModels;

namespace APICollection.Responses
{
    public class BillingData
    {
        public String policy { get; set; }
        public LeasingData leasing { get; set; }

        public ClipertData clipert { get; set; }

        public Boolean validated { get; set; }

        public List<PolicyCommentVM> comments { get; set; }
    }
}
