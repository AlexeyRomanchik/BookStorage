using System;
using System.Collections.Generic;
using BookStorage.Models;

namespace BookStorage.Areas.Admin.ViewModels
{
    public class AddAuthorsViewModel
    {
        public Guid BookId { get; set; }
        public List<Author> BookAuthors { get; set; }
        public List<Author> AllAuthors { get; set; }

        public AddAuthorsViewModel()
        {
            BookAuthors = new List<Author>();
            AllAuthors = new List<Author>();
        }
    }
}
