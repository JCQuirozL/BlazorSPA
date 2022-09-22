﻿namespace PoliciesBlazorApp.Models
{
    public class Data
    {
        public String Policy { get; set; }
        public LeasingData Leasing { get; set; }

        public ClipertData Clipert { get; set; }

        public Boolean Validated { get; set; }

        public List<PolicyCommentVM> Comments { get; set; }
    }
}