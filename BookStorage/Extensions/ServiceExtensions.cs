using Microsoft.Extensions.DependencyInjection;
using BookStorage.Interfaces;
using BookStorage.Repository;
using BookStorage.Services;

namespace BookStorage.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureFileService(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
