﻿namespace APICollection.ViewModels
{
    public class Policy
    {
        public String PolicyNumber { get; set; }

        public String PaymentFolio { get; set; }
        public String ReferenceId { get; set; }
        public String Bank { get; set; }
        public String Invoice { get; set; }
        public String AccountNumber { get; set; }

        public DateTime DocumentDate { get; set; }

        public Decimal DepositAmount { get; set; }

        public Boolean Validated { get; set; }

    }
}
