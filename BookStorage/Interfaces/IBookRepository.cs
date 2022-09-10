using System.Linq;
using BookStorage.Models;

namespace BookStorage.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IQueryable<Book> FindByPublishingHouse(string publishingHouse);
    }
}