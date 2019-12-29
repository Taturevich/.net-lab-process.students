using LibraryWithTests.Domain;
using System.Collections.Generic;

namespace LibraryWithTests.Services
{
    public class BookMemoryStorage : MemoryBaseStorage<Book>, IStore<Book>
    {     
        public BookMemoryStorage(List<Book> entities) : base(entities)
        {
        }               
    }
}
