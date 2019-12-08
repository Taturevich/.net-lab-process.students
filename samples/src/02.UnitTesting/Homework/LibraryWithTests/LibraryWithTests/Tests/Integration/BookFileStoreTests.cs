using FluentAssertions;
using LibraryWithTests.Domain;
using LibraryWithTests.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibraryWithTests.Tests.Integration
{
    [TestFixture]
    public class BookFileStoreTests
    {
        [Test]
        public void GetAll_WhenBookExist_ShouldReturnBooksList()
        {
            // Arrange
            var settings = new TestBookFileStorageSettings();
            var storage = new BookFileStore(settings);

            // Act
            var books = storage.GetAll();

            // Assert
            books.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings" },
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
                new Book { Id = 4, Name = "The Hobbit" },
            });
        }
    }
}
