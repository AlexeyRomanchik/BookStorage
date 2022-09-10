using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStorage.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Surname { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }

    }
}
