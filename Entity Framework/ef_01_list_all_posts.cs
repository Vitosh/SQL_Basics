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

            List<Posts> obj_posts = blogDbContext.Posts.Select(k => k).ToList();
            foreach (Posts post  in obj_posts)
            {
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("AuthorId: {0}",post.AuthorId);
                Console.WriteLine("Comments Count: {0}",post.Comments.Count);
                Console.WriteLine("Tags Count {0}",post.Tags.Count);
                Console.WriteLine();
            }
        }
    }
}