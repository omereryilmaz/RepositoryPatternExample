using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace BookStore.Core.Models
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Books = new Collection<Book>();
        }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
