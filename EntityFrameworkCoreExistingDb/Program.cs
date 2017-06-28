using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreExistingDb
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Existing DB 
             * run :
             Scaffold-DbContext "Server=DESKTOP-0JT666N;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Project EntityFrameworkCoreExistingDb 
            */
            using (var db = new BloggingContext())
            {
                db.Blog.Add(new Blog() {Url = "https://www.devart.com/dotconnect/sqlite/docs/EFCore-Database-First.html" });
                var result = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", result);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var x in db.Blog)
                    Console.WriteLine(" -  {0}", x.Url);
            }

            Console.ReadLine();
        }
    }
}
