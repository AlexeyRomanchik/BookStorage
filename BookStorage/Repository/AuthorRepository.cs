using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BookStorage.DbConfiguration;
using BookStorage.Interfaces;
using BookStorage.Models;

namespace BookStorage.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Author> FindAll()
        {
            return AppDbContext.Set<Author>()
                .Include(x => x.BookAuthors)
                .ThenInclude(t => t.Book)
                .AsNoTracking();
        }

        public override IQueryable<Author> FindByCondition(Expression<Func<Author, bool>> expression)
        {
            return AppDbContext.Set<Author>().Where(expression)
                .Include(x => x.BookAuthors)
                .ThenInclude(x => x.Book)
                .AsNoTracking();
        }
    }
}
