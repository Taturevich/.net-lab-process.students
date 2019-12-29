using LibraryWithTests.Domain;

namespace LibraryWithTests
{
    public interface ILibrary
    {
        void RentBook(User user, Book book);

        void ReturnBook(User user, Book book);

        UserBook[] ReturnBookHistory(Book book);
    }    
}
