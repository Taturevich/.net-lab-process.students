namespace Demo_3.Tests
{
    using System;
    using System.Collections.Generic;

    using Demo_3;

    public class FakeRepository : IUserRepository
    {
        private IDictionary<string, User> inMemoryStorage;

        public FakeRepository()
        {
            this.inMemoryStorage = new Dictionary<string, User>();
        }

        public User GetByName(string userName)
        {
            return this.inMemoryStorage.ContainsKey(userName) ? this.inMemoryStorage[userName] : null;
        }

        public void Save(User user)
        {
            if (this.inMemoryStorage.ContainsKey(user.UserName))
            {
                throw new InvalidOperationException();
            }

            this.inMemoryStorage.Add(user.UserName, user);
        }
    }
}
