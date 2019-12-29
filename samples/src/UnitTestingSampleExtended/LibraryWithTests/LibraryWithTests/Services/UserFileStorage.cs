using LibraryWithTests.Domain;

namespace LibraryWithTests.Services
{
    class UserFileStorage : FileStorageBase<User>, IStore<User>
    {
        public UserFileStorage(IFIleStorageSettings settings) : base(settings)
        {
        }
    }
}
