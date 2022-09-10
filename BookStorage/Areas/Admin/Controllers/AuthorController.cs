using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookStorage.Interfaces;
using BookStorage.Models;

namespace BookStorage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AuthorController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _authorRepository = _repositoryWrapper.AuthorRepository;
        }

        public IActionResult Index()
        {
            var authors = _authorRepository.FindAll().ToList();

            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _authorRepository.Create(author);
            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _authorRepository.Update(author);
            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var author = _authorRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            return View(author);
        }

        public IActionResult Delete(Guid id)
        {
            var book = _authorRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            _authorRepository.Delete(book);
            _repositoryWrapper.Save();

            return RedirectToAction("Index");
        }
    }
}