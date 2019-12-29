using FluentAssertions;
using LibraryWithTests.Domain;
using LibraryWithTests.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LibraryWithTests.Tests.Unit
{
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void RentFunctionTest()
        {
            // Arrange 
            var userBooksMock = new Mock<IStore<UserBook>>();
            var userStoreMock = new Mock<IStore<User>>();
            var bookStoreMock = new Mock<IStore<Book>>();
            userBooksMock.Setup(m => m.GetAll()).Returns(new List<UserBook>
            {
                new UserBook {BookId = 1, UserId = 5},
                new UserBook {BookId = 3, UserId = 4},
                new UserBook {BookId = 7, UserId = 4},
            });
            var library = new Library(userStoreMock.Object, bookStoreMock.Object, userBooksMock.Object);

            // Act
            TestDelegate testAction = () => library.RentBook(new User {Id = 4}, new Book {Id = 3});

            // Assert
            Assert.Throws<InvalidOperationException>(testAction);
        }
    }
}
