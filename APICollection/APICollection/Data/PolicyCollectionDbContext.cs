﻿using APICollection.Entities;
using APICollection.Models;
using Microsoft.EntityFrameworkCore;

namespace APICollection.Data
{
    public class PolicyCollectionDbContext : DbContext
    {
        public PolicyCollectionDbContext(DbContextOptions<PolicyCollectionDbContext> options) : base(options)
        {

        }

        public DbSet<PolicyComment> PolicyComments { get; set; }
        public DbSet<PolicyCollection> PoliciesCollection { get; set; } = null!;
        public DbSet<PolicyInformationService>? PolicyInformationService { get; set; }
        public DbSet<PolicyCollectionFile>? PolicyCollectionFile { get; set; }


    }


}
