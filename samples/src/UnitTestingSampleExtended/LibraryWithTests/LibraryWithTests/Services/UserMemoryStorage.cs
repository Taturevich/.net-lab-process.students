using LibraryWithTests.Domain;
using System.Collections.Generic;

namespace LibraryWithTests.Services
{
    class UserMemoryStorage : MemoryBaseStorage<User>, IStore<User>
    {
        public UserMemoryStorage(List<User> entities) : base(entities)
        {
        }
    }
}
