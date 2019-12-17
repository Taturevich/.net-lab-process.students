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
        public void GivenRent_WhenUserRentMoreTwoBooks_ShouldReturnException()
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
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not rent more than two Books!"));
        }


        [Test]
        public void GivenRent_WhenUserIsNull_ShouldReturnException()
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
            TestDelegate testAction = () => library.RentBook(null, new Book { Id = 3 });
                        
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Null user can not rent Book!"));
        }


        [Test]
        public void GivenRent_WhenUserRentsNullBook_ShouldReturnException()
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
            TestDelegate testAction = () => library.RentBook(new User { Id = 4 }, null);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not rent null Book!"));
        }


        [Test]
        public void RentBook_WhenRentBook_NewUserBookAdded()
        {
            // Arrange
            var userBookToAdd = new UserBook { BookId = 7, UserId = 7 };
            var userBooks = new List<UserBook>();

            var userBooksMock = new Mock<IStore<UserBook>>();
            var userStoreMock = new Mock<IStore<User>>();
            var bookStoreMock = new Mock<IStore<Book>>();
            userBooksMock.Setup(m => m.GetAll()).Returns(userBooks);
            userBooksMock.Setup(m => m.Add(It.IsAny<UserBook>())).Callback<UserBook>(ub => userBooks.Add(ub));
            
            var library = new Library(userStoreMock.Object, bookStoreMock.Object, userBooksMock.Object);

            // Act
            library.RentBook(new User { Id = 7}, new Book { Id = 7 } );

            // Assert
            userBooks.Should()
                .ContainSingle(ub => ub.UserId == 7 && ub.BookId == 7 && ub.RentDateStart >= DateTime.Now.AddSeconds(-1));
        }

        [Test]
        public void GivenRent_WhenRentBook_NewUserBookAddedWitnStartTimeRent()
        {
            // Arrange
            var userBookToAdd = new UserBook { BookId = 7, UserId = 7 };
            var userBooks = new List<UserBook>();

            var userBooksMock = new Mock<IStore<UserBook>>();
            var userStoreMock = new Mock<IStore<User>>();
            var bookStoreMock = new Mock<IStore<Book>>();
            userBooksMock.Setup(m => m.GetAll()).Returns(userBooks);
            userBooksMock.Setup(m => m.Add(It.IsAny<UserBook>())).Callback<UserBook>(ub => userBooks.Add(ub));

            var library = new Library(userStoreMock.Object, bookStoreMock.Object, userBooksMock.Object);

            // Act
            library.RentBook(new User { Id = 7 }, new Book { Id = 7 });

            // Assert
            var _userBokkTimeStart = userBooks.Find(ub => ub.UserId == 7 && ub.BookId == 7).RentDateStart;
            _userBokkTimeStart.Should().BeCloseTo(DateTime.Now);
        }


        [Test]
        public void GivenReturn_WhenReturnNonExistUserBook_ShouldReturnException()
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
            TestDelegate testAction = () => library.ReturnBook(new User { Id = 2 }, new Book { Id = 3 });

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("There is not this book for this user in the UserBook Storage!"));
        }

        [Test]
        public void GivenBookHistory_WhenReturnUserBookIsNull_ShouldReturnException()
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
            TestDelegate testAction = () => library.ReturnBookHistory(null);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(testAction);
            Assert.That(ex.Message, Is.EqualTo("Can not return history of null Book!"));
        }

        [Test]
        public void GivenBookHistory_WhenReturnUserBookHistory_ShouldReturnAllUserBookHistory()
        {
            // Arrange 
            var userBooksMock = new Mock<IStore<UserBook>>();
            var userStoreMock = new Mock<IStore<User>>();
            var bookStoreMock = new Mock<IStore<Book>>();
            userBooksMock.Setup(m => m.GetAll()).Returns(new List<UserBook>
            {
                new UserBook {BookId = 1, UserId = 5, IsArchive = true },
                new UserBook {BookId = 3, UserId = 4, IsArchive = false },
                new UserBook {BookId = 7, UserId = 4, IsArchive = true },
                new UserBook {BookId = 7, UserId = 6, IsArchive = true },
            });
            var library = new Library(userStoreMock.Object, bookStoreMock.Object, userBooksMock.Object);

            // Act
            var result = library.ReturnBookHistory(new Book { Id = 7 } );

            // Assert
            result.Should().BeEquivalentTo(new List<UserBook>
            {
                new UserBook {BookId = 7, UserId = 4, IsArchive = true },
                new UserBook {BookId = 7, UserId = 6, IsArchive = true }
            });
        }
    }
}
