using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0JT666N;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }
        /* New Database
            Tools –> NuGet Package Manager –> Package Manager Console
            Run "Add-Migration MyFirstMigration" to scaffold a migration to create the initial set of tables for your model.
            Run "Update-Database" to apply the new migration to the database.Because your database doesn't exist yet, it will be created for you before the migration is applied.
        */
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}
