using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStorage.Models;

namespace BookStorage.ViewModels
{
    public class BooksViewModel
    {
        public const string AllPublishingHouses = "All";

        public List<Book> Books { get; set; }
        public SelectList PublishingHouses { get; set; }
        public string SelectedPublishingHouse { get; set; }
    }
}
