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

            var author = blogDbContext.Users
                .SelectMany(user => user.Posts, (user, posts) => new { user.UserName, user.FullName, posts.Id })
                .Single(post => post.Id == 4);

            Console.WriteLine("Username: {0}", author.UserName);
            Console.WriteLine("Full name {0}",author.FullName);
            Console.WriteLine();
        }
    }
}