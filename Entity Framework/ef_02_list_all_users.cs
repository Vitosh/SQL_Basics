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

            List<Users> obj_users = blogDbContext.Users.Select(user => user).ToList();

            foreach (Users user in obj_users)
            {
                Console.WriteLine("ID: {0}",user.Id);
                Console.WriteLine("Name: {0}",user.FullName);
                Console.WriteLine("Comments Count {0}",user.Comments.Count);
                Console.WriteLine("Posts Count: {0}",user.Posts.Count);
                Console.WriteLine();
            }

        }
    }
}