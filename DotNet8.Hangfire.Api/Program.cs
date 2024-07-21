using DotNet8.Hangfire.Api;
using DotNet8.Hangfire.Api.AppDbContexts;
using DotNet8.Hangfire.Api.Features.Blog;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFeatures(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<IBlogRepository>(
    Guid.NewGuid().ToString(),
    x =>
        x.CreateBlog(
            new BlogRequestModel()
            {
                BlogTitle = "Recurring Job",
                BlogAuthor = "Recurring Job",
                BlogContent = "Recurring Job"
            }
        ),
    Cron.Minutely
);

BackgroundJob.Schedule<IBlogRepository>(
    x =>
        x.CreateBlog(
            new BlogRequestModel()
            {
                BlogTitle = "Delay Job",
                BlogAuthor = "Delay Job",
                BlogContent = "Delay Job"
            }
        ),
    TimeSpan.FromMinutes(1)
);

app.UseAuthorization();

app.MapControllers();

app.Run();
