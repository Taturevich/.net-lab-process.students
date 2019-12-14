using System;
using System.Linq;
using LibraryWithTests.Domain;
using LibraryWithTests.Services;

namespace LibraryWithTests
{
    public class Library : ILibrary
    {
        private readonly IStore<User> _users;
        private readonly IStore<Book> _books;
        private readonly IStore<UserBook> _userBooks;

        public Library(
            IStore<User> users,
            IStore<Book> books,
            IStore<UserBook> userBooks)
        {
            _users = users;
            _books = books;
            _userBooks = userBooks;
        }

        public void RentBook(User user, Book book)
        {
            var canRentBook = _userBooks
                .GetAll()
                .Count(x => x.UserId == user.Id) < 2;
            if (!canRentBook)
            {
                throw new InvalidOperationException();
            }

            _userBooks.Add(new UserBook { BookId = book.Id, UserId = user.Id });
        }
    }
}
