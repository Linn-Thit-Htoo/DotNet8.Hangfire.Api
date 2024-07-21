using DotNet8.Hangfire.Api.Features.Blog;

namespace DotNet8.Hangfire.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeatures(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            return services
                .AddDbContextService(builder)
                .AddHangfireService(builder)
                .AddRepositoryService()
                .AddBusinessLogicService();
        }

        private static IServiceCollection AddDbContextService(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            builder.Services.AddDbContext<AppDbContext>(
                opt =>
                {
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
                },
                ServiceLifetime.Transient
            );

            return services;
        }

        private static IServiceCollection AddHangfireService(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            builder.Services.AddHangfire(opt =>
            {
                opt.UseSqlServerStorage(builder.Configuration.GetConnectionString("DbConnection"))
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings();
            });

            builder.Services.AddHangfireServer();
            return services;
        }

        private static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            return services.AddScoped<IBlogRepository, BlogRepository>();
        }

        private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
        {
            return services.AddScoped<BL_Blog>();
        }
    }
}
