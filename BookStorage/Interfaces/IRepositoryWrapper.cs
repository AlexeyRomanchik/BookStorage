namespace BookStorage.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBookRepository BookRepository { get; set; }

        IAuthorRepository AuthorRepository { get; set; }

        IPublishingHouseRepository PublishingHouseRepository { get; set; }

        IBookAuthorRepository BookAuthorRepository { get; set; }

        void Save();
    }
}