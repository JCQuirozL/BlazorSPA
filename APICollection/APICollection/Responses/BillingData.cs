﻿using APICollection.ViewModels;

namespace APICollection.Responses
{
    public class BillingData
    {
        public String Policy { get; set; }
        public LeasingData Leasing { get; set; }

        public ClipertData Clipert { get; set; }

        public Boolean Validated { get; set; }

        public List<PolicyCommentVM> Comments { get; set; }
    }
}
