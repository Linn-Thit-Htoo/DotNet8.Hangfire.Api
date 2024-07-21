namespace DotNet8.Hangfire.Api.Features.Blog;

public class BL_Blog
{
    private readonly IBlogRepository _blogRepository;

    public BL_Blog(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogListResponseModel> GetBlogs()
    {
        return await _blogRepository.GetBlogs();
    }
}
