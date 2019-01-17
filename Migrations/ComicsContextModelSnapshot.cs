﻿// <auto-generated />
using ComicBooksAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComicBooksAPI.Migrations
{
    [DbContext(typeof(ComicsContext))]
    partial class ComicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("ComicBooksAPI.Comics.Comic", b =>
                {
                    b.Property<int>("ComicId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<uint>("Size");

                    b.HasKey("ComicId");

                    b.ToTable("Comics");
                });
#pragma warning restore 612, 618
        }
    }
}
