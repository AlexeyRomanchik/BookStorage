using System;
using System.Collections.Generic;

namespace BookStorage.Models
{
    public class PublishingHouse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
