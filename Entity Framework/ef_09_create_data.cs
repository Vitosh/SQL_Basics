using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class MainTest
    {
        static void Main()
        {
            TestDbContext blogDbContext = new TestDbContext();

            Posts post = new Posts()
            {
                AuthorId = 2,
                Title = "Random Title",
                Body = "Random Content",
                Date = DateTime.Now
            };

            blogDbContext.Posts.Add(post);
            blogDbContext.SaveChanges();

            Console.WriteLine("Post #{0} created",post.Id);
        }
    }
}