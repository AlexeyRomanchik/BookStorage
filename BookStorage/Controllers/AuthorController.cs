using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookStorage.Interfaces;

namespace BookStorage.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IRepositoryWrapper repositoryWrapper)
        {
            _authorRepository = repositoryWrapper.AuthorRepository;
        }

        public IActionResult Index()
        {
            var authors = _authorRepository.FindAll().ToList();

            return View(authors);
        }

        public IActionResult Info(Guid id)
        {
            var author = _authorRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (author == null) return RedirectToAction("Index");

            return View(author);
        }
    }
}