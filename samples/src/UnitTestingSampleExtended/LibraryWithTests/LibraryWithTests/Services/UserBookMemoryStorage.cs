using LibraryWithTests.Domain;
using System.Collections.Generic;

namespace LibraryWithTests.Services
{
    class UserBookMemoryStorage : MemoryBaseStorage<UserBook>, IStore<UserBook>
    {
        public UserBookMemoryStorage(List<UserBook> entities) : base(entities)
        {
        }
    }
}
