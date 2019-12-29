using LibraryWithTests.Core;
using LibraryWithTests.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWithTests.Services
{
    public class BookMemoryStorage : IStore<Book>
    {
        private readonly List<Book> _books;

        public BookMemoryStorage(List<Book> books)
        {
            _books = new List<Book>(books ?? new List<Book>());
        }

        public void Add(Book item)
        {
            var calculatedId = _books.GetIncrementedId();
            item.Id = calculatedId;
            _books.Add(item);
        }

        public void Delete(Book item)
        {
            var itemToRemove = _books.FirstOrDefault(x => x.Id == item.Id);
            _books.Remove(itemToRemove);
        }

        public List<Book> GetAll()
        {
            return new List<Book>(_books);
        }
    }
}
