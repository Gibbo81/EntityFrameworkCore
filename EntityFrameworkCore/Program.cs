using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args) //https://docs.microsoft.com/en-us/ef/efcore-and-ef6/index
        {
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.First();    //before db.Blogs.Local.Count=0 e db.Posts.Local.Count=0 all entities are untracked 
                                                //after db.Blogs.Local.Count=1 e db.Posts.Local.Count=0 only Blogs are tracked and only its change can go to DB
                blog = db.Blogs.Include(o => o.Posts).First();//after db.Blogs.Local.Count=1 e db.Posts.Local.Count=2
                int ttt = 546;                                //using Include EFC will load in memory also the two Posts entities releted to Blog
                //if we remove the Blog in the first case EFC will send to the Db DELETE FROM [Blog] WHERE[BlogId] = @p0; Post are untracked "This relies on a corresponding cascade behavior being present in the database"
                //                      in the second case also DELETE FROM [Post] WHERE [PostId] = @p0; ... are sent in explicit manner

                db.Blogs.Add(new Blog() { Url = "https://www.benday.com" });
                db.Posts.Add(new Post()
                {
                    Title = "added from c#",
                    Content = "*-*-*-*-*-*-*-",
                    BlogId = 4
                });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                
                Console.WriteLine("");
                Console.WriteLine("All blog inside DB");
                foreach (var r in db.Blogs)
                    Console .WriteLine("- {0}", r.Url);

                var res = db.Blogs.FirstOrDefault(t => t.Url =="https://www.benday.com/2017/02/14/walkthrough-entity-framework-core-1-1-with-migrations/");
                Console.WriteLine("First: {0}", res.BlogId);

                Console.ReadLine();
            }
        }
    }
}