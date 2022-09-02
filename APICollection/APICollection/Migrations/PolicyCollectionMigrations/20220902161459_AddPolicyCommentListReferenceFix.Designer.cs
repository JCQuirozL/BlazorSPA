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
    [Migration("20220902161459_AddPolicyCommentListReferenceFix")]
    partial class AddPolicyCommentListReferenceFix
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
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("decimal(14,2)");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolicyFileId")
                        .HasColumnType("int");

                    b.Property<int>("PolicyInfoId")
                        .HasColumnType("int");

                    b.Property<bool>("Validated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ValidationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PolicyCollectionId");

                    b.HasIndex("PolicyFileId");

                    b.HasIndex("PolicyInfoId");

                    b.ToTable("PoliciesCollection");
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
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentType")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PolicyColId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("CommentId");

                    b.HasIndex("PolicyColId");

                    b.ToTable("PolicyComments");
                });

            modelBuilder.Entity("APICollection.Models.PolicyCollectionFile", b =>
                {
                    b.Property<int>("PolicyFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyFileId"), 1L, 1);

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmitterCenter")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime>("InfoDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Invoice")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("varchar(38)");

                    b.Property<decimal>("TotalPremium")
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("PolicyFileId");

                    b.ToTable("PolicyCollectionFile");
                });

            modelBuilder.Entity("APICollection.Models.PolicyInformationService", b =>
                {
                    b.Property<int>("PolicyInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyInfoId"), 1L, 1);

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmitterCenter")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime>("InfoDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Invoice")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentFolio")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("PolicyInfoId");

                    b.ToTable("PolicyInformationService");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollection", b =>
                {
                    b.HasOne("APICollection.Models.PolicyCollectionFile", "PolicyCollectionFile")
                        .WithMany()
                        .HasForeignKey("PolicyFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICollection.Models.PolicyInformationService", "PolicyInformationService")
                        .WithMany()
                        .HasForeignKey("PolicyInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PolicyCollectionFile");

                    b.Navigation("PolicyInformationService");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyComment", b =>
                {
                    b.HasOne("APICollection.Entities.PolicyCollection", "PolicyCollection")
                        .WithMany("Comments")
                        .HasForeignKey("PolicyColId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PolicyCollection");
                });

            modelBuilder.Entity("APICollection.Entities.PolicyCollection", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
