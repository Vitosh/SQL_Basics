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

            var users = blogDbContext.Users
                .SelectMany(user => user.Posts, (user, post) => new { user.UserName, post.Title });

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}",user.UserName);
                Console.WriteLine("Post Title: {0}",user.Title);
                Console.WriteLine();
            }

        }
    }
}