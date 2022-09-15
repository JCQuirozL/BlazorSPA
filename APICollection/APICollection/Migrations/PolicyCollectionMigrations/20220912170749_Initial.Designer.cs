﻿// <auto-generated />
using System;
using APICollection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    [DbContext(typeof(PolicyCollectionDbContext))]
    [Migration("20220912170749_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APICollection.Entities.PolicyCollection", b =>
                {
                    b.Property<int>("PolicyCollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyCollectionId"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("EmmiterCenter")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Invoice")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("PaymentFolio")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<long>("PolicyFileId")
                        .HasColumnType("bigint");

                    b.Property<long>("PolicyInfoId")
                        .HasColumnType("bigint");

                    b.Property<string>("ReferenceId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("TotalPremium")
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Validated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ValidationDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("PolicyCollectionId");

                    b.HasIndex("PolicyFileId");

                    b.HasIndex("PolicyInfoId");

                    b.ToTable("PoliciesCollection");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollectionFile", b =>
                {
                    b.Property<long>("PolicyFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PolicyFileId"), 1L, 1);

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("EmmiterCenter")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<DateTime?>("InfoDate")
                        .IsRequired()
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Invoice")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("IssueDate")
                        .IsRequired()
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("TotalPremium")
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("PolicyFileId");

                    b.ToTable("PolicyCollectionFile");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollectionHistory", b =>
                {
                    b.Property<int>("PolicyCollectionHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyCollectionHistoryId"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("EmmiterCenter")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Invoice")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("PaymentFolio")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PolicyCollectionId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("TotalPremium")
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Validated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ValidationDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("PolicyCollectionHistoryId");

                    b.HasIndex("PolicyCollectionId");

                    b.ToTable("PoliciesCollectionHistory");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyComment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("CommentType")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PolicyCollectionId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("CommentId");

                    b.HasIndex("PolicyCollectionId");

                    b.ToTable("PolicyComments");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyInformationService", b =>
                {
                    b.Property<long>("PolicyInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PolicyInfoId"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("InfoDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("PaymentFolio")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("PolicyInfoId");

                    b.ToTable("PolicyInformationService");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollection", b =>
                {
                    b.HasOne("APICollection.Entities.PolicyCollectionFile", "PolicyCollectionFile")
                        .WithMany()
                        .HasForeignKey("PolicyFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICollection.Entities.PolicyInformationService", "PolicyInformationService")
                        .WithMany()
                        .HasForeignKey("PolicyInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PolicyCollectionFile");

                    b.Navigation("PolicyInformationService");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollectionHistory", b =>
                {
                    b.HasOne("APICollection.Entities.PolicyCollection", null)
                        .WithMany("PoliciesCollectionHistory")
                        .HasForeignKey("PolicyCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APICollection.Entities.PolicyComment", b =>
                {
                    b.HasOne("APICollection.Entities.PolicyCollection", null)
                        .WithMany("Comments")
                        .HasForeignKey("PolicyCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollection", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PoliciesCollectionHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
