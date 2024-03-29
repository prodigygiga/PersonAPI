﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonDirectory.Infrastructure.Persistence;

#nullable disable

namespace PersonDirectory.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220307194755_seedDataAdded")]
    partial class seedDataAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.CityAggregate.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City", "Common");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 3, 7, 23, 47, 55, 311, DateTimeKind.Local).AddTicks(7544),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeletedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "ქუთაისი"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 3, 7, 23, 47, 55, 311, DateTimeKind.Local).AddTicks(7560),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeletedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "თბილისი"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 3, 7, 23, 47, 55, 311, DateTimeKind.Local).AddTicks(7562),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeletedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "ბათუმი"
                        });
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PrivateNumber")
                        .IsUnique();

                    b.ToTable("People", "Person");
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.PersonRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedPersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RelatedPersonId");

                    b.ToTable("PersonRelation", "Person");
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PhoneNumbers", "Person");
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Person", b =>
                {
                    b.HasOne("PersonDirectory.Core.Domain.Aggregates.CityAggregate.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Gender", "Gender", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId");

                            b1.ToTable("People", "Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("City");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.PersonRelation", b =>
                {
                    b.HasOne("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Person", "Person")
                        .WithMany("Relations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.RelationType", "RelationType", b1 =>
                        {
                            b1.Property<int>("PersonRelationId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonRelationId");

                            b1.ToTable("PersonRelation", "Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonRelationId");
                        });

                    b.Navigation("Person");

                    b.Navigation("RelatedPerson");

                    b.Navigation("RelationType");
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.PhoneNumber", b =>
                {
                    b.HasOne("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.PhoneNumberType", "PhoneNumberType", b1 =>
                        {
                            b1.Property<int>("PhoneNumberId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PhoneNumberId");

                            b1.ToTable("PhoneNumbers", "Person");

                            b1.WithOwner()
                                .HasForeignKey("PhoneNumberId");
                        });

                    b.Navigation("Person");

                    b.Navigation("PhoneNumberType");
                });

            modelBuilder.Entity("PersonDirectory.Core.Domain.Aggregates.PersonAggregate.Person", b =>
                {
                    b.Navigation("PhoneNumbers");

                    b.Navigation("Relations");
                });
#pragma warning restore 612, 618
        }
    }
}
