namespace Demo_3
{
    using System.Collections.Generic;

    public class User
    {

        private List<string> roles;

        public User(string userName, IEnumerable<string> roles)
        {
            this.UserName = userName;
            this.roles = new List<string>(roles);
        }

        public string UserName { get; set; }

        public bool IsInRole(string role)
        {
            return this.roles.Exists(x => x == role);
        }

        public string[] GetAllRoles()
        {
            return this.roles.ToArray();
        }

        public static User Get(IUserRepository dataStore, string userName)
        {
            return dataStore.GetByName(userName);
        }

        public void Save(IUserRepository dataStore)
        {
            dataStore.Save(this);
        }
    }
}
