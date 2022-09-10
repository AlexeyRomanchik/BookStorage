using System;
using BookStorage.DbConfiguration;
using BookStorage.Interfaces;

namespace BookStorage.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _appDbContext;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IPublishingHouseRepository _publishingHouseRepository;
        private IBookAuthorRepository _bookAuthorRepository;

        public IBookRepository BookRepository
        {
            get => _bookRepository ??= new BookRepository(_appDbContext);
            set => throw new NotImplementedException();
        }

        public IAuthorRepository AuthorRepository
        {
            get => _authorRepository ??= new AuthorRepository(_appDbContext);
            set => throw new NotImplementedException();
        }

        public IPublishingHouseRepository PublishingHouseRepository
        {
            get => _publishingHouseRepository ??= new PublishingHouseRepository(_appDbContext);
            set => throw new NotImplementedException();
        }

        public IBookAuthorRepository BookAuthorRepository
        {
            get => _bookAuthorRepository ??= new BookAuthorRepository(_appDbContext);
            set => throw new NotImplementedException();
        }

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
