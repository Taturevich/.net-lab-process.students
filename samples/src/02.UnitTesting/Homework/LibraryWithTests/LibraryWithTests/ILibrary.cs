using LibraryWithTests.Domain;

namespace LibraryWithTests
{
    public interface ILibrary
    {
        void RentBook(User user, Book book);
    }
}
