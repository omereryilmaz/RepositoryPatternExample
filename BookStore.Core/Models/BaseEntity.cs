using System;

namespace BookStore.Core.Models
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
