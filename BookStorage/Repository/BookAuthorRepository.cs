using BookStorage.DbConfiguration;
using BookStorage.Interfaces;
using BookStorage.Models;

namespace BookStorage.Repository
{
    public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
