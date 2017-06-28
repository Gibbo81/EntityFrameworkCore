using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var x = db.Database;

                db.Blogs.Add(new Blog() {Url = "https://www.benday.com/2017/02/14/walkthrough-entity-framework-core-1-1-with-migrations/" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine("");
                Console.WriteLine("All blog inside DB");
                foreach (var r in db.Blogs)
                    Console .WriteLine("- {0}", r.Url);

            }





            Console.ReadLine();
        }
    }
}