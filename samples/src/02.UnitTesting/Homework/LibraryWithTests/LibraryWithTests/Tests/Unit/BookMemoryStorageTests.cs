using FluentAssertions;
using LibraryWithTests.Domain;
using LibraryWithTests.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWithTests.Tests.Unit
{
    [TestFixture]
    public class BookMemoryStorageTests
    {
        [Test]
        public void GetAll_WhenBooksExist_ShouldReturnBookList()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings" },
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
            };
            var store = new BookMemoryStorage(books);

            // Act
            var result = store.GetAll();

            // Assert
            result.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings" },
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
            });
        }

        [Test]
        public void GetAll_WhenBooksNotProvide_ShouldReturnEmptyList()
        {
            // Arrange
            var store = new BookMemoryStorage(null);

            // Act
            var result = store.GetAll();

            // Assert
            result.Should().BeEmpty();
        }
    }
}
