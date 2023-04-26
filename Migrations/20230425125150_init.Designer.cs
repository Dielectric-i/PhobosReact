﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhobosReact.API.Data;

#nullable disable

namespace PhobosReact.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230425125150_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PhobosReact.API.Data.Dto.BoxDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("BoxDtoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentBoxId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SpaceDtoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BoxDtoId");

                    b.HasIndex("SpaceDtoId");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("PhobosReact.API.Data.Dto.ItemDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("BoxDtoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("SpaceDtoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BoxDtoId");

                    b.HasIndex("SpaceDtoId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PhobosReact.API.Data.Dto.SpaceDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("PhobosReact.API.Data.Dto.BoxDto", b =>
                {
                    b.HasOne("PhobosReact.API.Data.Dto.BoxDto", null)
                        .WithMany("Boxes")
                        .HasForeignKey("BoxDtoId");

                    b.HasOne("PhobosReact.API.Data.Dto.SpaceDto", "SpaceDto")
                        .WithMany("Boxes")
                        .HasForeignKey("SpaceDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpaceDto");
                });

            modelBuilder.Entity("PhobosReact.API.Data.Dto.ItemDto", b =>
                {
                    b.HasOne("PhobosReact.API.Data.Dto.BoxDto", null)
                        .WithMany("Items")
                        .HasForeignKey("BoxDtoId");

                    b.HasOne("PhobosReact.API.Data.Dto.SpaceDto", null)
                        .WithMany("Items")
                        .HasForeignKey("SpaceDtoId");
                });

            modelBuilder.Entity("PhobosReact.API.Data.Dto.BoxDto", b =>
                {
                    b.Navigation("Boxes");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("PhobosReact.API.Data.Dto.SpaceDto", b =>
                {
                    b.Navigation("Boxes");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}