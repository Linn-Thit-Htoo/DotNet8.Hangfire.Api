namespace DotNet8.Hangfire.Api.Repositories.Blog;

public interface IBlogRepository
{
    Task<BlogListResponseModel> GetBlogs();
    Task<int> CreateBlog(BlogRequestModel requestModel);
}
