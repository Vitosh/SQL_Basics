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

            Posts postInfo = blogDbContext.Posts.Single(post => post.Id == 31);

            blogDbContext.Comments.RemoveRange(postInfo.Comments);
            postInfo.Tags.Clear();

            blogDbContext.Posts.Remove(postInfo);
            blogDbContext.SaveChanges();

            Console.WriteLine("Post #{0} deleted successfully",postInfo.Id);

        }
    }
}