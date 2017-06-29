﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreNewDb.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20170628132727_MaxLen2")]
    partial class MaxLen2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCore.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityFrameworkCore.MultiKey", b =>
                {
                    b.Property<int>("Session");

                    b.Property<int>("Version");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.HasKey("Session", "Version");

                    b.ToTable("MultiKey");
                });

            modelBuilder.Entity("EntityFrameworkCore.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("EntityFrameworkCore.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EntityFrameworkCore.Post", b =>
                {
                    b.HasOne("EntityFrameworkCore.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}