using FluentAssertions;
using LibraryWithTests.Domain;
using LibraryWithTests.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LibraryWithTests.Tests.Integration
{
    [TestFixture]
    public class BookFileStoreTests
    {
        private TestBookFileStorageSettings _settings;

        [SetUp]
        public void Init()
        {
            _settings = new TestBookFileStorageSettings();
        }

        [TearDown]
        public void RevertStorage()
        {
            string result;
            using (Stream stream = Assembly.GetAssembly(typeof(BookFileStoreTests)).GetManifestResourceStream("LibraryWithTests.Books_for_test.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            File.WriteAllText(_settings.FileNameData, result);
        }
        
        [Test]
        public void GivenGetAll_WhenBookExist_ShouldReturnBooksList()
        {
            // Arrange            
            var bookFileStorage = new BookFileStorage(_settings);

            // Act
            var books = bookFileStorage.GetAll();

            // Assert
            books.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings" },
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
                new Book { Id = 4, Name = "The Hobbit" },
            });
        }

        [Test]
        public void GivenAdd_WhenAddBook_ShouldReturnBooksListWithNewBook()
        {
            // Arrange
            Book bookToAdd = new Book { Name = "Herbert Schildt C#" };
                        
            var bookFileStorage = new BookFileStorage(_settings);

            // Act
            bookFileStorage.Add(bookToAdd);
            var books = bookFileStorage.GetAll();

            // Assert
            books.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings" },
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
                new Book { Id = 4, Name = "The Hobbit" },
                new Book { Id = 5, Name = "Herbert Schildt C#" }
            });
        }

        [Test]
        public void GivenAdd_WhenBookIsNull_ShouldReturnException()
        {
            // Arrange    
            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Add(null);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not add null object!"));
        }


        [Test]
        public void GivenDelete_WhenDeleteExistBook_ShouldReturnBookListWithoutDeletedBook()
        {
            // Arrange
            Book bookToDelete = new Book { Id = 4, Name = "The Hobbit" };

            var bookFileStorage = new BookFileStorage(_settings);

            // Act
            bookFileStorage.Delete(bookToDelete);
            var books = bookFileStorage.GetAll();

            // Assert
            books.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings" },
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
            });
        }

        [Test]
        public void GivenDelete_WhenDeleteNonExistBook_ShouldReturnException()
        {
            // Arrange
            var book = new Book { Id = 5, Name = "Herbert Schildt C#", IsArchive = false };

            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Delete(book);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("There is not this item in the Item Storage!"));
        }

        [Test]
        public void GivenDelete_WhenDeleteBookIsNull_ShouldReturnException()
        {
            // Arrange            
            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Delete(null);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not delete null object!"));
        }

        [Test]
        public void GivenUpdate_WhenUpdateExistBook_ShouldReturnBookListWithUpdatedBook()
        {
            // Arrange
            Book bookToDelete = new Book { Id = 1, Name = "The Lord of the Rings" };

            var bookFileStorage = new BookFileStorage(_settings);

            // Act
            bookFileStorage.Update(bookToDelete);
            var books = bookFileStorage.GetAll();

            // Assert
            books.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 2, Name = "Le Petit Prince" },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone" },
                new Book { Id = 4, Name = "The Hobbit" },
                new Book { Id = 1, Name = "The Lord of the Rings" }
            });
        }

        [Test]
        public void GivenUpdate_WhenUpdateNonExistBook_ShouldReturnException()
        {
            // Arrange
            var book = new Book { Id = 5, Name = "Herbert Schildt C#", IsArchive = false };
            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Update(book);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("There is not this item in the Item Storage!"));
        }

        [Test]
        public void GivenUpdate_WhenUpdateBookIsNull_ShouldReturnException()
        {
            // Arrange
            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Update(null);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not update null object!"));
        }

        [Test]
        public void GivenArchive_WhenArchiveExistBook_ShouldReturnBookListWithArchivedBook()
        {
            // Arrange
            Book book = new Book { Id = 1, Name = "The Lord of the Rings" };

            var bookFileStorage = new BookFileStorage(_settings);

            // Act
            bookFileStorage.Archive(book);
            var result = bookFileStorage.GetAll();

            // Assert
            result.Should().BeEquivalentTo(new List<Book>
            {
                new Book { Id = 1, Name = "The Lord of the Rings", IsArchive = true },
                new Book { Id = 2, Name = "Le Petit Prince", IsArchive = false },
                new Book { Id = 3, Name = "Harry Potter and the Philosopher's Stone", IsArchive = false },
                new Book { Id = 4, Name = "The Hobbit" , IsArchive = false }
            });
        }

        [Test]
        public void GivenArchive_WhenArchiveNonExistBook_ShouldReturnException()
        {
            // Arrange
            Book book = new Book { Id = 5, Name = "Herbert Schildt C#" };

            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Archive(book);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("There is not this item in the Item Storage!"));
        }

        [Test]
        public void GivenArchive_WhenArchiveBookIsNull_ShouldReturnException()
        {
            // Arrange
            var bookFileStorage = new BookFileStorage(_settings);

            //Act
            TestDelegate testAction = () => bookFileStorage.Archive(null);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not archive null object!"));
        }
    }
}
