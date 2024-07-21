using DotNet8.Hangfire.Api.AppDbContexts;
using DotNet8.Hangfire.Api.Models;

namespace DotNet8.Hangfire.Api.Mapper
{
    public static class ChangeModel
    {
        public static Tbl_Blog Map(this BlogRequestModel requestModel)
        {
            return new Tbl_Blog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
        }

        public static BlogModel Map(this Tbl_Blog dataModel)
        {
            return new BlogModel
            {
                BlogId = dataModel.BlogId,
                BlogTitle = dataModel.BlogTitle,
                BlogAuthor = dataModel.BlogAuthor,
                BlogContent = dataModel.BlogContent
            };
        }
    }
}
