using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStorage.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(1024, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Publication date")]
        public DateTime? PublicationDate { get; set; }

        [Range(1, 5)]
        public double? Rating { get; set; }

        public string ImageLink { get; set; }

        public Guid? PublishingHouseId { get; set; }

        public PublishingHouse PublishingHouse { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }

        public string GetPublicationDateByFormat(string format = "MM d, yyyy")
        {
            return PublicationDate?.ToString(format) ?? string.Empty;
        }

    }
}

