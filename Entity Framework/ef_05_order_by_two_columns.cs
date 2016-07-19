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

            var users = blogDbContext.Users.Select(user => new
            {
                user.UserName,
                user.FullName
            })
            .OrderByDescending(user => user.UserName)
            .ThenByDescending(user=> user.FullName)
            .ToList();

            foreach (var user in users)
            {
                Console.WriteLine("Username:{0}", user.UserName);
                Console.WriteLine("Full Name:{0}",user.FullName);
                Console.WriteLine();
            }
        }
    }
}
