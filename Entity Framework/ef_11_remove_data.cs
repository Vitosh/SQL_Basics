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

            Comments commentInfo = blogDbContext.Comments.Single(comment => comment.Id == 1);
            blogDbContext.Comments.Remove(commentInfo);
            blogDbContext.SaveChanges();

            Console.WriteLine("Comment #{0} deleted",commentInfo.Id);
        }
    }
}