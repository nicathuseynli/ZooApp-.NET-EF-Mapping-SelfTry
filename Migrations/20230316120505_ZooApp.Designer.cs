﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooApp_EF.Data.Context;

#nullable disable

namespace ZooApp_EF.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    [Migration("20230316120505_ZooApp")]
    partial class ZooApp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Cage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZooId");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zoos");
                });

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Animal", b =>
                {
                    b.HasOne("ZooApp_EF.Data.Entity.Cage", "Cage")
                        .WithMany("Animals")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Cage", b =>
                {
                    b.HasOne("ZooApp_EF.Data.Entity.Zoo", "Zoo")
                        .WithMany("Cages")
                        .HasForeignKey("ZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Cage", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("ZooApp_EF.Data.Entity.Zoo", b =>
                {
                    b.Navigation("Cages");
                });
#pragma warning restore 612, 618
        }
    }
}
