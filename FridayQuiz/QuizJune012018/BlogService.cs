using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizJune012018
{
    public class BlogService
    {
        private BloggingContext _context;

        public BlogService(BloggingContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            IQueryable<Blog> query = from b in _context.Blogs
                               orderby b.Name
                               select b;

            return await query.ToListAsync();
        }
    }
}
