﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICollection.Entities
{
    public abstract class Policies
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public String Policy { get; set; } = null!;


        [Column(TypeName = "decimal(14,2)")]
        public Decimal TotalPremium { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String PaymentFolio { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(200)")]
        public String Bank { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String AccountNumber { get; set; } = null!;

        [Column(TypeName = "decimal(14,2)")]
        public Decimal DepositAmount { get; set; }

        public DateTime DepositDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public String ReferenceId { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(15)")]
        public String Certificate { get; set; } = null!;


        [Required]
        [Column(TypeName = "varchar(15)")]
        public String Invoice { get; set; } = null!;

        public DateTime IssueDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public String EmmiterCenter { get; set; } = null!;

        public Boolean Validated { get; set; } = false;


        public DateTime? ValidationDate { get; set; }

       
        public DateTime CreatedDate { get; set; }

        
        public DateTime? UpdatedDate { get; set; }


    }
}
