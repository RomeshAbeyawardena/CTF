﻿// <auto-generated />
using System;
using CTF.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CTF.Api.Migrations
{
    [DbContext(typeof(CTFDbContext))]
    partial class CTFDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CTF.Features.Models.ActivityLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivityTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuditedActivityTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TransactionDefinitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TransactionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("AuditedActivityTypeId");

                    b.HasIndex("SessionId");

                    b.HasIndex("TransactionDefinitionId");

                    b.HasIndex("TransactionId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("CTF.Features.Models.ActivityType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("NVARCHAR(2000)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("CTF.Features.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(2000)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("CTF.Features.Models.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<Guid?>("OwnerTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(800)");

                    b.Property<DateTimeOffset?>("ValidFrom")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ValidTo")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("OwnerTransactionId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("CTF.Features.Models.SessionResourceAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ValidTo")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionResourceAccess");
                });

            modelBuilder.Entity("CTF.Features.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GeneratedBySessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(2000)");

                    b.Property<Guid?>("ParentTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<Guid?>("ProcessedBySessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ProcessedTimestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("TransactionDefinitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransactionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ValidFrom")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("GeneratedBySessionId");

                    b.HasIndex("ParentTransactionId");

                    b.HasIndex("ProcessedBySessionId");

                    b.HasIndex("TransactionDefinitionId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("CTF.Features.Models.TransactionDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(800)");

                    b.Property<DateTimeOffset?>("ValidFrom")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ValidTo")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("TransactionDefinition");
                });

            modelBuilder.Entity("CTF.Features.Models.TransactionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("NVARCHAR(2000)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(80)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("CTF.Features.Models.ActivityLog", b =>
                {
                    b.HasOne("CTF.Features.Models.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CTF.Features.Models.ActivityType", "AuditedActivityType")
                        .WithMany()
                        .HasForeignKey("AuditedActivityTypeId");

                    b.HasOne("CTF.Features.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CTF.Features.Models.TransactionDefinition", "TransactionDefinition")
                        .WithMany()
                        .HasForeignKey("TransactionDefinitionId");

                    b.HasOne("CTF.Features.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");

                    b.HasOne("CTF.Features.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId");

                    b.Navigation("ActivityType");

                    b.Navigation("AuditedActivityType");

                    b.Navigation("Session");

                    b.Navigation("Transaction");

                    b.Navigation("TransactionDefinition");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("CTF.Features.Models.Session", b =>
                {
                    b.HasOne("CTF.Features.Models.Transaction", "OwnerTransaction")
                        .WithMany()
                        .HasForeignKey("OwnerTransactionId");

                    b.Navigation("OwnerTransaction");
                });

            modelBuilder.Entity("CTF.Features.Models.SessionResourceAccess", b =>
                {
                    b.HasOne("CTF.Features.Models.Resource", "Resource")
                        .WithMany("SessionResourceAccess")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CTF.Features.Models.Session", "Session")
                        .WithMany("SessionResourceAccess")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("CTF.Features.Models.Transaction", b =>
                {
                    b.HasOne("CTF.Features.Models.Session", "GeneratedBySession")
                        .WithMany()
                        .HasForeignKey("GeneratedBySessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CTF.Features.Models.Transaction", "ParentTransaction")
                        .WithMany()
                        .HasForeignKey("ParentTransactionId");

                    b.HasOne("CTF.Features.Models.Session", "ProcessedBySession")
                        .WithMany()
                        .HasForeignKey("ProcessedBySessionId");

                    b.HasOne("CTF.Features.Models.TransactionDefinition", "TransactionDefinition")
                        .WithMany()
                        .HasForeignKey("TransactionDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CTF.Features.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeneratedBySession");

                    b.Navigation("ParentTransaction");

                    b.Navigation("ProcessedBySession");

                    b.Navigation("TransactionDefinition");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("CTF.Features.Models.Resource", b =>
                {
                    b.Navigation("SessionResourceAccess");
                });

            modelBuilder.Entity("CTF.Features.Models.Session", b =>
                {
                    b.Navigation("SessionResourceAccess");
                });
#pragma warning restore 612, 618
        }
    }
}
