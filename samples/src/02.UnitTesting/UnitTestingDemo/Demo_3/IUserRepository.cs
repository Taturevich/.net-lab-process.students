namespace Demo_3
{
    public interface IUserRepository
    {
        User GetByName(string userName);

        void Save(User user);
    }
}
