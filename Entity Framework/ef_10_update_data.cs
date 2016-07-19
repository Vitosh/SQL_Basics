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

            Users userInfo = blogDbContext.Users.Single(user => user.UserName == "GBotev");
            string oldName = userInfo.FullName;

            userInfo.FullName = "Georgi K. Botev";
            blogDbContext.SaveChanges();

            Console.WriteLine("User '{0}' has been renamed to '{1}'.",oldName,userInfo.FullName);
        }
    }
}