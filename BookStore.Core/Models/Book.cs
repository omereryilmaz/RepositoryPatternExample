using System;

namespace BookStore.Core.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
