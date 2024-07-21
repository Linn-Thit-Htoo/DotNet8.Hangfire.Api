using DotNet8.Hangfire.Api.Mapper;

namespace DotNet8.Hangfire.Api.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogListResponseModel> GetBlogs()
        {
            try
            {
                var lst = await _context.Tbl_Blogs.AsNoTracking().OrderByDescending(x => x.BlogId).ToListAsync();
                return new BlogListResponseModel() { DataLst = lst.Select(x => x.Map()).ToList()};
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateBlog(BlogRequestModel requestModel)
        {
            try
            {
                await _context.Tbl_Blogs.AddAsync(requestModel.Map());
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
