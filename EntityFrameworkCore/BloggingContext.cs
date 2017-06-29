using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<MultiKey> MultiKey { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0JT666N;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }
        /* New Database
            Tools –> NuGet Package Manager –> Package Manager Console
            Run "Add-Migration MyFirstMigration" to scaffold a migration to create the initial set of tables for your model.
            Run "Update-Database" to apply the new migration to the database.Because your database doesn't exist yet, it will be created for you before the migration is applied.
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MultiKey>().HasKey(x => new {x.Session, x.Version});
            modelBuilder.Entity<MultiKey>().Property(x => x.Description).HasMaxLength(200)
                                                                        .HasDefaultValue(" x-O-x");
        }
    }

    public class MultiKey
    {
        public int Session { get; set; }
        public int Version { get; set; }
        public string Description{ get; set; }
    }

    public class Place
    {
        public int PlaceId { get; set; }
        public string Code { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        [ConcurrencyCheck] //If a property is configured as a concurrency token then EF will check that no other user has modified that value in the database when saving changes to that record using an optimistic concurrency patter
        public string Content { get; set; }

        public int BlogId { get; set; } //used for the field of the foreign key 
        public Blog Blog { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}
