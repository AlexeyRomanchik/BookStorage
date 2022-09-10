using Microsoft.AspNetCore.Http;
using BookStorage.Models;

namespace BookStorage.Areas.Admin.ViewModels
{
    public class CreateBookViewModel
    {
        public Book Book { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
