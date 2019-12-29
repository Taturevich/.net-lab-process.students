using LibraryWithTests.Domain;

namespace LibraryWithTests.Services
{
    public class BookFileStorage : FileStorageBase<Book>, IStore<Book>
    {    
        public BookFileStorage(IFIleStorageSettings settings) : base(settings)
        {            
        }
    }
}
