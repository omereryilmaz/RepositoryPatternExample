using System;

namespace BookStore.Core.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
