using LibraryWithTests.Domain;

namespace LibraryWithTests.Services
{
    class UserBookFileStorage : FileStorageBase<UserBook>, IStore<UserBook>
    {
        public UserBookFileStorage(IFIleStorageSettings settings) : base(settings)
        {
        }    
    }
}
