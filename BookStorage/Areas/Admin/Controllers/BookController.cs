using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStorage.Areas.Admin.ViewModels;
using BookStorage.Interfaces;
using BookStorage.Models;
using BookStorage.ViewModels;

namespace BookStorage.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishingHouseRepository _publishingHouseRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IRepositoryWrapper repositoryWrapper, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _repositoryWrapper = repositoryWrapper;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
            _bookRepository = repositoryWrapper.BookRepository;
            _publishingHouseRepository = repositoryWrapper.PublishingHouseRepository;
        }

        public IActionResult Index(string publishingHouse = BooksViewModel.AllPublishingHouses)
        {
            var books = GetBooks(publishingHouse);
            

            var publishingHouses = _publishingHouseRepository.FindAll().Select(x => x.Name).ToList();
            publishingHouses.Add(BooksViewModel.AllPublishingHouses);

            var publishingHousesSelect = new SelectList(publishingHouses);

            var booksViewModel = new BooksViewModel
            {
                Books = books,
                PublishingHouses = publishingHousesSelect,
                SelectedPublishingHouse = publishingHouse
            };

            return View(booksViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _bookRepository.Update(book);
            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var book = _bookRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            AddPublishersListInViewBag();

            return View(book);
        }

        public IActionResult Delete(Guid id)
        {
            var book = _bookRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (book == null)
                return View("Error");

            _fileService.DeleteFile(_webHostEnvironment.WebRootPath + book.ImageLink);

            _bookRepository.Delete(book);
            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            AddPublishersListInViewBag();

            var createBookViewModel = new CreateBookViewModel();

            return View(createBookViewModel);
        }


        [HttpPost]
        public IActionResult Create(CreateBookViewModel createBookViewModel)
        {
            var guid = Guid.NewGuid();

            var filePath = string.Empty;

            if (createBookViewModel.UploadedFile != null)
            {
                var fileExtension = Path.GetExtension(createBookViewModel.UploadedFile.FileName);
                var fileName = Path.GetFileNameWithoutExtension(createBookViewModel.UploadedFile.FileName);
                filePath = "/images/" + fileName + guid + fileExtension;
                _fileService.SaveUploadedFile(createBookViewModel.UploadedFile, _webHostEnvironment.WebRootPath + filePath);
            }

            createBookViewModel.Book.Id = guid;
            createBookViewModel.Book.ImageLink = filePath;


            _bookRepository.Create(createBookViewModel.Book);
            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }

        private List<Book> GetBooks(string publishingHouse)
        {
            return publishingHouse != BooksViewModel.AllPublishingHouses
                ? _bookRepository.FindByPublishingHouse(publishingHouse).ToList()
                : _bookRepository.FindAll().ToList();
        }

        [HttpPost]
        public IActionResult AddAuthors(Guid id, List<Guid> authorsId)
        {

            var bookAuthorCurrent = _repositoryWrapper.BookAuthorRepository.FindByCondition(x => x.BookId == id).ToList();

            var removeBookAuthors = bookAuthorCurrent.Where(x =>!authorsId.Contains(x.AuthorId));

            var addBookAuthors = new List<BookAuthor>();

            foreach (var authorId in authorsId)
            {
                if(!bookAuthorCurrent.Exists(x => x.AuthorId == authorId))
                    addBookAuthors.Add(new BookAuthor{BookId = id, AuthorId = authorId});
            }

            foreach (var removeBookAuthor in removeBookAuthors)
            {
                _repositoryWrapper.BookAuthorRepository.Delete(removeBookAuthor);
            }

            foreach (var addBookAuthor in addBookAuthors)
            {
                _repositoryWrapper.BookAuthorRepository.Create(addBookAuthor);
            }

            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAuthors(Guid id)
        {
            var authors = _repositoryWrapper.AuthorRepository.FindAll().ToList();
            
            var book = _bookRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (book == null)
                return RedirectToAction("Index");

            var bookAuthors = new List<Author>();

            foreach (var bookAuthor in book.BookAuthors)
            {
                bookAuthors.Add(bookAuthor.Author);
            }

            var addAuthorsViewModel = new AddAuthorsViewModel
            {
                BookId = id,
                BookAuthors = bookAuthors,
                AllAuthors = authors
            };

            return View(addAuthorsViewModel);
        }


        private void AddPublishersListInViewBag()
        {
            var publisherList = new SelectList(
                _publishingHouseRepository.FindAll(), "Id", "Name"
                );

            var selectList = new List<SelectListItem>(publisherList)
            {
                new SelectListItem {Text = "None", Value = null, Selected = true}
            };

            ViewBag.PublishingHouses = selectList;
        }

    }
}