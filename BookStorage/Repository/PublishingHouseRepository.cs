using BookStorage.DbConfiguration;
using BookStorage.Interfaces;
using BookStorage.Models;

namespace BookStorage.Repository
{
    public class PublishingHouseRepository : RepositoryBase<PublishingHouse>, IPublishingHouseRepository
    {
        public PublishingHouseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
