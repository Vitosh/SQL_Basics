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

            List<Users> users = blogDbContext.Users.Select(user => user)
                .Where(user => user.Posts.Count > 0)
                .ToList();

            foreach (Users user  in users)
            {
                Console.WriteLine("Username: {0}",user.UserName);
                Console.WriteLine("Full Name: {0}",user.FullName);
                Console.WriteLine("Posts Count: {0}",user.Posts.Count);
                Console.WriteLine();
            }
        }
    }
}