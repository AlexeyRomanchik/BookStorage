using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BookStorage.DbConfiguration;
using BookStorage.Interfaces;
using BookStorage.Models;

namespace BookStorage.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Book> FindAll()
        {
            return AppDbContext.Set<Book>()
                .Include(x => x.BookAuthors)
                .ThenInclude(t => t.Author)
                .Include(x => x.PublishingHouse)
                .AsNoTracking();
        }

        public override IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            return AppDbContext.Set<Book>().Where(expression)
                .Include(x => x.BookAuthors)
                .ThenInclude(x => x.Author)
                .Include(x => x.PublishingHouse)
                .AsNoTracking();
        }

        public IQueryable<Book> FindByPublishingHouse(string publishingHouse)
        {
            return AppDbContext.Set<Book>().Where(x => x.PublishingHouse.Name == publishingHouse)
                .Include(x => x.BookAuthors)
                .ThenInclude(x => x.Author)
                .Include(x => x.PublishingHouse)
                .AsNoTracking();
        }
    }
}
