using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStorage.Interfaces;
using BookStorage.Models;
using BookStorage.ViewModels;

namespace BookStorage.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishingHouseRepository _publishingHouseRepository;

        public BookController(IRepositoryWrapper repositoryWrapper)
        {
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

        public IActionResult Info(Guid id)
        {
            var book = _bookRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (book == null) return RedirectToAction("Index");

            return View(book);
        }

        private List<Book> GetBooks(string publishingHouse)
        {
            return publishingHouse != BooksViewModel.AllPublishingHouses
                ? _bookRepository.FindByPublishingHouse(publishingHouse).ToList()
                : _bookRepository.FindAll().ToList();
        }

    }
}